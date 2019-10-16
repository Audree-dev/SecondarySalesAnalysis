using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Data;
using Audree.SSA.AppException;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userService;
        private IRoleRepository _roleService;
        private IMapper _mapper;
        private readonly ISSADbContexts _dataContext;
        private readonly AppSettings _appSettings;
        public UsersController(
            IUserRepository userService,
            IRoleRepository roleService,
            IMapper mapper,
            IOptions<AppSettings> appSettings, ISSADbContexts dataContext)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
            _dataContext = dataContext;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost ("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDTO userDto)
        {
            var user = await _userService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
                return Unauthorized();
            //var claims = GetRoleClaims()
            //new List<Claim>;
            //var role = _roleService.GetRolesByUserID(user.Id);
            List<UsersInRoles> role =   _roleService.GetRolesByUserID(user.Id);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var userroles =  await _dataContext.UsersInRoleses.Where(w => w.UserId == user.Id).ToListAsync();

           //List<Submenu> submenus= _dataContext.Submenus.Where(x => userroles.Contains(x.RoleId)).Include("MenuMaster").ToList();

            //getting role names
            var q = (from Ur in _dataContext.UsersInRoleses
                     join ro in _dataContext.roles on Ur.RoleId equals ro.Id
                     select new
                     {
                         ro.RoleDescription,
                     }).ToList();
            // To Get Menus and submenus

            var MenuandSubmenus = (from a in _dataContext.MenuMasters
                                   join b in _dataContext.Submenus on a.Id equals b.MenuMasterId
                                   //join c in _dataContext.Roles on b.RoleId equals c.Id
                                   select new
                                   {
                                       a.Menu,
                                       b.Name,
                                       //c.Id, //Role Id
                                       b.RoleId // submenu table role id
                                   }).ToList();

            // To filter menus based on roles

            var rolebasedMenus = (from a in MenuandSubmenus
                                  join b in role on a.RoleId equals b.Id
                                  select new
                                  {
                                      a.Menu,
                                      a.Name
                                  }).ToList();


            List<Claim> obj = new List<Claim>();

            foreach (var item in q)
            {
                //var rolename = _dataContext.UsersInRoles.Where(w => w.UserId == item.RoleId).ToList();
                obj.Add(new Claim(ClaimTypes.Role, item.RoleDescription));

            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(obj),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                menusubmens = MenuandSubmenus,
                submenus = rolebasedMenus
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDTO userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);
            try
            {
                // save 
               await _userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()


        {
            var users =await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IList<UserDTO>>(users);
            return Ok(userDtos);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UserDTO userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
               await _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
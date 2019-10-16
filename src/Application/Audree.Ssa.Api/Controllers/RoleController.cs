using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.SSA.AppException;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
   
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _Mapper;
        private readonly AppSettings _appSettings;

        public RoleController(IRoleRepository roleRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _roleRepository = roleRepository;
            _Mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _roleRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<RoleDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, RoleDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleRepository.GetByIdAsync(id);
            var cto = _Mapper.Map<RoleDTO>(role);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }
        // POST: api/Role
        [HttpPost]
        public IActionResult Create([FromBody]RoleDTO roleDto)
        {
            // map dto to entity
            var role = _Mapper.Map<Role>(roleDto);
            try
            {
                // save 
                _roleRepository.Create(role);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoleDTO dto)
        {
            // map dto to entity and set id
            var role = _Mapper.Map<Role>(dto);
            role.Id = id;

            try
            {
                // save 
                _roleRepository.UpdateAsync(role, id);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleRepository.DeleteById(id);
            return Ok();
        }
    }
}
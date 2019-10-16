using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.SSA.AppException;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Model.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMasterController : ControllerBase
    {
        private IMenuMasterRepository _MenuMasterRepository;
        private IMapper _Mapper;

        public MenuMasterController(IMenuMasterRepository menuMasterRepository, IMapper mapper)
        {
            _MenuMasterRepository = menuMasterRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _MenuMasterRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<MenuMasterDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? Userid, MenuMasterDTO dto)
        {
            if (Userid == null)
            {
                return NotFound();
            }

            var Master = await _MenuMasterRepository.GetMenuByUserID(Userid);
            var cto = _Mapper.Map<CountryDTO>(Master);
            if (Master == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] MenuMasterDTO dto)
        {

            var res = _Mapper.Map<MenuMaster>(dto);
            try
            {
                var Menu = _MenuMasterRepository.Create(res);
                return Ok(Menu);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


      
    }
}
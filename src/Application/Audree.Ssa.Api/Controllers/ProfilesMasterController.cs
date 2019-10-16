using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Infrastructure.Repositories.Admin;
using Audree.SSA.AppException;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesMasterController : ControllerBase
    {
        private readonly IProfilesMastersRepository _profilesmasterRepository;
        private readonly IMapper _Mapper;

        public ProfilesMasterController(IProfilesMastersRepository profilesmasterRepository, IMapper mapper)
        {
            _profilesmasterRepository = profilesmasterRepository;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _profilesmasterRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<ProfileMasterDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, ProfileMasterDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profilesmaster = await _profilesmasterRepository.GetByIdAsync(id);
            var cto = _Mapper.Map<ProfileMasterDTO>(profilesmaster);
            if (profilesmaster == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] ProfileMasterDTO dto)
        {

            var Res = _Mapper.Map<ProfilesMaster>(dto);
            try
            {
                var profilesmaster = _profilesmasterRepository.SaveOrUpdateAsync(Res);
                return Ok(profilesmaster);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProfileMasterDTO dto)
        {
            // map dto to entity and set id
            var Profile = _Mapper.Map<ProfilesMaster>(dto);
            Profile.Id = id;

            try
            {
                // save 
                _profilesmasterRepository.UpdateAsync(Profile, id);
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
            _profilesmasterRepository.DeleteById(id);
            return Ok();
        }
    }
}

    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Master;
using Audree.SSA.AppException;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonForRejectionController : ControllerBase
    {
        private readonly IReasonForRejectionRepository _reasonForRejection;
        private readonly IMapper _Mapper;

        public ReasonForRejectionController(IReasonForRejectionRepository reasonForRejection, IMapper mapper)
        {
            _reasonForRejection = reasonForRejection;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _reasonForRejection.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<ReasonForRejectionDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, ReasonForRejectionDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _reasonForRejection.GetByIdAsync(id);
            var cto = _Mapper.Map<CountryDTO>(country);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] ReasonForRejectionDTO dto)
        {

            var Res = _Mapper.Map<ReasonForRejection>(dto);
            try
            {
                var country = _reasonForRejection.SaveOrUpdateAsync(Res);
                return Ok(country);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReasonForRejectionDTO dto)
        {
            // map dto to entity and set id
            var rsofre = _Mapper.Map<ReasonForRejection>(dto);
            rsofre.Id = id;

            try
            {
                // save 
                _reasonForRejection.UpdateAsync(rsofre, id);
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
            _reasonForRejection.DeleteById(id);
            return Ok();
        }
    }
}
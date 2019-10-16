using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.SSA.AppException;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOMController : ControllerBase
    {
        private readonly IUOMRepository _uomRepository;
        private readonly IMapper _mapper;

        public UOMController(IUOMRepository IuomRepository, IMapper mapper)
        {
            _uomRepository = IuomRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _uomRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<UOMDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, UOMDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uom = await _uomRepository.GetByIdAsync(id);
            var cto = _mapper.Map<CountryDTO>(uom);
            if (uom == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] UOMDTO dto)
        {

            var Res = _mapper.Map<UOM>(dto);
            try
            {
                var country = _uomRepository.SaveOrUpdateAsync(Res);
                return Ok(country);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UOMDTO dto)
        {
            // map dto to entity and set id
            var uom = _mapper.Map<UOM>(dto);
            uom.Id = id;

            try
            {
                // save 
                _uomRepository.UpdateAsync(uom, id);
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
            _uomRepository.DeleteById(id);
            return Ok();
        }
    }
}

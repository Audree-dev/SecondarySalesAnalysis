using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Contracts;
using Audree.Ssa.Core.Model.Master;
using Audree.SSA.AppException;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _Mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _countryRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<CountryDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, CountryDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id);
            var cto = _Mapper.Map<CountryDTO>(country);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] CountryDTO dto)
        {

            var res = _Mapper.Map<Country>(dto);
            try
            {
                var country = _countryRepository.SaveOrUpdateAsync(res);
                return Ok(country);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CountryDTO dto)
        {
            // map dto to entity and set id
            var country = _Mapper.Map<Country>(dto);
            country.Id = id;

            try
            {
                // save 
                _countryRepository.UpdateAsync(country, id);
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
            _countryRepository.DeleteById(id);
            return Ok();
        }
    }
}

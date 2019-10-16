using System.Collections.Generic;
using System.Threading.Tasks;
using Audree.Ssa.Api.DTOs;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Master;
using Audree.SSA.AppException;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalutationController : ControllerBase
    {
        private readonly ISalutationRepository _salutationRepository;
        private readonly IMapper _Mapper;

        public SalutationController(ISalutationRepository salutationRepository, IMapper mapper)
        {
            _salutationRepository = salutationRepository;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _salutationRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<SalutationDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, SalutationDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _salutationRepository.GetByIdAsync(id);
            var sal = _Mapper.Map<SalutationDTO>(salutation);
            if (salutation == null)
            {
                return NotFound();
            }
            return Ok(sal);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] SalutationDTO dto)
        {

            var Res = _Mapper.Map<Salutation>(dto);
            try
            {
                var salutation = _salutationRepository.SaveOrUpdateAsync(Res);
                return Ok(salutation);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SalutationDTO dto)
        {
            // map dto to entity and set id
            var salutation = _Mapper.Map<Salutation>(dto);
            salutation.Id = id;

            try
            {
                // save 
                _salutationRepository.UpdateAsync(salutation, id);
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
            _salutationRepository.DeleteById(id);
            return Ok();
        }
    }
}

    

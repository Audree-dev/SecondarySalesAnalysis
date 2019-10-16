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
   
    public class MaterialController : ControllerBase
    {

        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _Mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _materialRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<MaterialDTO>>(res);
            return Ok(model);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, MaterialDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _materialRepository.GetByIdAsync(id);
            var cto = _Mapper.Map<MaterialDTO>(material);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] MaterialDTO dto)
        {

            var Res = _Mapper.Map<Material>(dto);
            try
            {
                var role = _materialRepository.SaveOrUpdateAsync(Res);
                return Ok(role);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }



        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MaterialDTO dto)
        {
            // map dto to entity and set id
            var material = _Mapper.Map<Material>(dto);
            material.Id = id;

            try
            {
                // save 
                _materialRepository.UpdateAsync(material, id);
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
            _materialRepository.DeleteById(id);
            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
  
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _Mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _Mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _customerRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<CustomerDTO>>(res);
            return Ok(model);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id, CustomerDTO dto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(id);
            var cto = _Mapper.Map<CustomerDTO>(customer);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(cto);

        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] CustomerDTO dto)
        {

            var Res = _Mapper.Map<Customer>(dto);
            try
            {
                var role = _customerRepository.SaveOrUpdateAsync(Res);
                return Ok(role);

            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerDTO dto)
        {
            // map dto to entity and set id
            var customer = _Mapper.Map<Customer>(dto);
            customer.Id = id;

            try
            {
                // save 
                _customerRepository.UpdateAsync(customer, id);
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
            _customerRepository.DeleteById(id);
            return Ok();
        }
    }
}
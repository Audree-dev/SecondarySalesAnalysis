using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Model.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository materialRepository)
        {
            _menuRepository = materialRepository;
        }

        // GET: Menus
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var res = await _menuRepository.GetAllAsync();
           // res = Session["MenuList"] as List<Menu>;
            return Ok(res.OrderBy(o => o.MenuId));
        }
        [HttpGet("{id}")]
        public void Details()
        {

        }
        [HttpPost]
        public void Create()
        {

        }

        [HttpPut]
        public void Update()
        {

        }
        [HttpDelete]
        public void Delete()
        {

        }
    }
}
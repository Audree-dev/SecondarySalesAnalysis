using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Master;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _RoleRepository = roleRepository;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            //return View(await _RoleRepository.GetAllAsync());
            return View();
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _RoleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,RoleDescription")] Role role)
        {
            if (ModelState.IsValid)
            {
             //   await _RoleRepository.SaveOrUpdateAsync(role);
            }
            return RedirectToAction("Index");
            //return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }
    }
    //public class RoleController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

}
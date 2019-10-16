using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using Audree.Ssa.Core.Model.Master;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Web.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _MaterialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _MaterialRepository = materialRepository;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
            return View(await _MaterialRepository.GetAllAsync());
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _MaterialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Materialcode,MaterialDescription,MaterialGroupName")] Material material)
        {
            if (ModelState.IsValid)
            {
                await _MaterialRepository.SaveOrUpdateAsync(material);
            }
            return RedirectToAction("Index");
            //return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

    }
}
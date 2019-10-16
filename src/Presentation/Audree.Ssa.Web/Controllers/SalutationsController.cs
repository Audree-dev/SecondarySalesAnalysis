using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using AutoMapper;
using Audree.Ssa.Core.ViewModel;

namespace Audree.Ssa.Web.Controllers
{
    public class SalutationsController : Controller
    {
        private readonly IMapper _Mapper;
        private readonly ISalutationRepository _salutationRepository;

        public SalutationsController(ISalutationRepository salutationRepository,IMapper mapper)
        {
            _Mapper = mapper;
            _salutationRepository = salutationRepository;
        }

        // GET: Salutations
        public async Task<IActionResult> Index()
        {
            var res = await _salutationRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<SalutationViewmodel>>(res);
            return View(model);

        }

        // GET: Salutations/Details/5
        public async Task<IActionResult> Details(int? id,SalutationViewmodel vm)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _salutationRepository.GetByIdAsync(id);
            _Mapper.Map(vm, salutation);
            if (salutation == null)
            {
                return NotFound();
            }
            return View(_Mapper.Map<SalutationViewmodel>(salutation));
        }

        // GET: Salutations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salutations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] SalutationViewmodel vm)
        {
            if (ModelState.IsValid)
            {
                var Res = _Mapper.Map<Salutation>(vm);
                await _salutationRepository.SaveOrUpdateAsync(Res);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);

        }

        // GET: Salutations/Edit/5
        public async Task<IActionResult> Edit(int? id,SalutationViewmodel vm)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salutation = await _salutationRepository.GetByIdAsync(id);
            _Mapper.Map(vm, salutation);
            if (salutation == null)
            {
                return NotFound();
            }
            return View(_Mapper.Map<SalutationViewmodel>(salutation));
        }

  
 


       
    }
}

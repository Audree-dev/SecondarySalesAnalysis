using System.Collections.Generic;
using System.Threading.Tasks;
using Audree.Ssa.Core.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Contracts.Repositories.Admin;

namespace Audree.Ssa.Web.Controllers
{
    public class ProfilesMasterController : Controller
    {
        private readonly IProfilesMastersRepository _profilesMaterRepository;
        private readonly IMapper _Mapper;

        public ProfilesMasterController(IProfilesMastersRepository profilesMasterRepository, IMapper mapper)
        {
            _profilesMaterRepository = profilesMasterRepository;
            _Mapper = mapper;
        }
        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var res = await _profilesMaterRepository.GetAllAsync();
            var Model = _Mapper.Map<IEnumerable<ProfilesMasterViewmodel>>(res);
            return View(Model);
        }
        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id, ProfilesMasterViewmodel vm)
        {
            if (id == null)
                return NotFound();

            var profile = await _profilesMaterRepository.GetByIdAsync(id);
            _Mapper.Map(vm, profile);
            if (profile == null)
                return NotFound();

            return View(_Mapper.Map<ProfilesMasterViewmodel>(profile));
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Icon")] ProfilesMasterViewmodel Vm)
        {
            if (ModelState.IsValid)
            {
                var Res = _Mapper.Map<ProfilesMaster>(Vm);
                await _profilesMaterRepository.SaveOrUpdateAsync(Res);
                return RedirectToAction(nameof(Index));
            }
            return View(Vm);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id, ProfilesMasterViewmodel vm)
        {
            if (id == null)
                return NotFound();

            var profile = await _profilesMaterRepository.GetByIdAsync(id);
            _ = _Mapper.Map(vm, profile);
            if (profile == null)
                return NotFound();

            return View(vm);
        }
    }
}
        
    

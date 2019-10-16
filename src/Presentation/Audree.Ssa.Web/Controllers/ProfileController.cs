using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Audree.Ssa.Core.ViewModel;
using System.Collections.Generic;
using Audree.Ssa.Core.Model.Admin;


namespace Audree.Ssa.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _Mapper;

        public ProfileController(IProfileRepository profileRepository,IMapper mapper)
        {
            _profileRepository = profileRepository;
            _Mapper = mapper;
        }
        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var res = await _profileRepository.GetAllAsync();
            var Model = _Mapper.Map<IEnumerable<ProfileViewmodel>>(res);
            return View(Model);
        }
        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id,ProfileViewmodel vm)
        {
            if (id == null)
                return NotFound();

            var profile = await _profileRepository.GetByIdAsync(id);
            _Mapper.Map(vm, profile);
            if (profile == null)
                return NotFound();

            return View(_Mapper.Map<ProfileViewmodel>(profile));
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Icon")] ProfileViewmodel Vm)
        {
            if (ModelState.IsValid)
            {
                var Res = _Mapper.Map<ProfilesMaster>(Vm);
               // await _profileRepository.SaveOrUpdateAsync(Res);
                return RedirectToAction(nameof(Index));
            }
            return View(Vm);

        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id,ProfileViewmodel vm)
        {
            if (id == null)
                return NotFound();

            var profile = await _profileRepository.GetByIdAsync(id);
            _Mapper.Map(vm, profile);
            if (profile == null)
                return NotFound();

            return View(profile);
        }

    }
}
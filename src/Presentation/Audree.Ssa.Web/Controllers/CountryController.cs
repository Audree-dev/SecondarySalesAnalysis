using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Audree.Ssa.Core.Contracts;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Core.ViewModel;
using System.Collections.Generic;
using  AutoMapper;

namespace Audree.Ssa.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _Mapper;

        public CountryController(ICountryRepository countryRepository,IMapper mapper )
        {
            _countryRepository = countryRepository;
            _Mapper = mapper;
        }
        // GET: Countries
        public async Task<IActionResult> Index()
        {
            var res = await _countryRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<CountryViewmodel>>(res);
            return View(model);
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id,CountryViewmodel vm)
        {
            if (id == null)
                return NotFound();
            
            var country = await _countryRepository.GetByIdAsync(id);
            _Mapper.Map(vm, country);
            if (country == null)
                return NotFound();
            
            return View(_Mapper.Map<CountryViewmodel>(country));
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryCode,CountryName")] CountryViewmodel Vm)
        {
           


            if (ModelState.IsValid)
            {
                var Res = _Mapper.Map<Country>(Vm);
                await _countryRepository.SaveOrUpdateAsync(Res);

                return RedirectToAction(nameof(Index));
            }
            return View(Vm);
            //return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id,CountryViewmodel vm)
        {
            if (id == null)
                return NotFound();

            var country = await _countryRepository.GetByIdAsync(id);
            _Mapper.Map(vm, country);
            if (country == null)
                return NotFound();
            var model = _Mapper.Map<CountryViewmodel>(country);

            return View(model);
        }  
       
    }
}
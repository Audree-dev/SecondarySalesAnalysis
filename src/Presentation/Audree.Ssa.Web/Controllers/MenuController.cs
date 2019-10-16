using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Web.Controllers
{
    public class MenuController : Controller
    {

        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository materialRepository)
        {
            _menuRepository = materialRepository;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _menuRepository.GetAllAsync());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
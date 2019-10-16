using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Model.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Web.Controllers
{
    public class ChangepasswordController : Controller
    {
        private IChangepasswordRepository _changepasswordRepository;

        public ChangepasswordController(IChangepasswordRepository changepasswordRepository)
        {
            _changepasswordRepository = changepasswordRepository;
        }


        // GET: UOMs
       

        // GET: Changepassword/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Changepassword/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,oldPassword,newPassword,confirmPassword")] Changepassword changepassword)
        {
            if (ModelState.IsValid)
            {
                await _changepasswordRepository.SaveChangepassword(changepassword);
                return RedirectToAction(nameof(Create));
            }
            return View(changepassword);
        }
    }
}

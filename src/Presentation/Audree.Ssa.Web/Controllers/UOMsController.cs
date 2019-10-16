using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Audree.Ssa.Core.Model.Master;
using Audree.Ssa.Infrastructure.Data;
using Audree.Ssa.Core.Contracts.Repositories.Master;
using AutoMapper;
using Audree.Ssa.Core.ViewModel;

namespace Audree.Ssa.Web.Controllers
{
    public class UOMsController : Controller
    {
        private readonly IUOMRepository _uOMRepository;
        private readonly IMapper _Mapper;

        public UOMsController(IUOMRepository uOMRepository,IMapper mapper)
        {
            _uOMRepository = uOMRepository;
            _Mapper = mapper;
        }

        // GET: UOMs
        public async Task<IActionResult> Index()
        {
            var res = await _uOMRepository.GetAllAsync();
            var model = _Mapper.Map<IEnumerable<UOMViewmodel>>(res);
            return View(model);
        }

        // GET: UOMs/Details/5
        public async Task<IActionResult> Details(int? id ,UOMViewmodel vm)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UOM = await _uOMRepository.GetByIdAsync(id);
            _Mapper.Map(vm, UOM);

            if (UOM == null)
            {
                return NotFound();
            }

            return View(_Mapper.Map<UOMViewmodel>(UOM));
        }

        // GET: UOMs/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SlNo,FullName,Code,UOMStatus")] UOMViewmodel vm)
        {
            if (ModelState.IsValid)
            {
                var UOM = _Mapper.Map<UOM>(vm);
                await _uOMRepository.SaveOrUpdateAsync(UOM);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: UOMs/Edit/5
        public async Task<IActionResult> Edit(int? id , UOMViewmodel vm)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UOM = await _uOMRepository.GetByIdAsync(id);
            _Mapper.Map(vm, UOM);
            if (UOM == null)
            {
                return NotFound();
            }
            return View(_Mapper.Map<UOMViewmodel>(UOM));
        }

        //// POST: UOMs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,SlNo,FullName,Code,UOMStatus,Status,IsActive,CreatedBy,CreatedIP,CreatedDate,ModifiedBy,ModifiedDate,ModifiedIP,ApprovedBy,ApprovedDate,ApprovedIP")] UOM uOM)
        //{
        //    if (id != uOM.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _uOMRepository.Update(uOM);
        //            await _uOMRepository.SaveOrUpdateAsync(id);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UOMExists(uOM.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(uOM);
        //}

        //// GET: UOMs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var uOM = await _context.UOMs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (uOM == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(uOM);
        //}

        //// POST: UOMs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var uOM = await _context.UOMs.FindAsync(id);
        //    _context.UOMs.Remove(uOM);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UOMExists(int id)
        //{
        //    return _context.UOMs.Any(e => e.Id == id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;
using Microsoft.AspNetCore.Mvc;

namespace Audree.Ssa.Web.Controllers
{
    public class SmtpConfigController : Controller
    {
        //#region SMTPCONFIG
        //public ActionResult SmtpConfig()
        //{
        //    SmtpPasswordConfig _SmtpConfig = db.SmtpPasswordConfig.FirstOrDefault();
        //    List<Menu> _menuList = Session["MenuList"] as List<Menu>;
        //    ViewBag.LinkText = _menuList.Where(w => w.Action == "SmtpConfig" && w.Controller == "Admin").Select(s => s.LinkText).FirstOrDefault();
        //    return View(_SmtpConfig);
        //}


        //public ActionResult SmtpConfigSave(SmtpPasswordConfig smtpPasswordConfig)
        //{
        //    try
        //    {
        //        int _Luser = Convert.ToInt32(User.Identity.Name);

        //        if (smtpPasswordConfig.Id == 0)
        //        {
        //            smtpPasswordConfig.CreatedById = _Luser;
        //            smtpPasswordConfig.CreatedDate = DateTime.Now;
        //        }
        //        else
        //        {
        //            smtpPasswordConfig.ModifiedById = _Luser;
        //            smtpPasswordConfig.ModifiedDate = DateTime.Now;
        //        }

        //        string _Flag = adminBll._SmtpConfigSave(smtpPasswordConfig, db);
        //        if (_Flag != null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, _Flag);
        //        }
        //        return Json("Saved Successfully", JsonRequestBehavior.AllowGet);


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}

        //#endregion

        //public IActionResult Index()
        //{
        //    return View();
        //}

    }
}
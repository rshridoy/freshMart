using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using freshMart.Models;

namespace freshMart.Controllers
{
    public class AdminController : Controller
    {
        FreshMartEntities1 db = new FreshMartEntities1();
        // GET: Admin

        [HttpGet]
        public ActionResult adminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminlogin(tbl_admin avm)
        {
            tbl_admin ad = db.tbl_admin.Where(x => x.admin_username == avm.admin_username && x.admin_password == avm.admin_password).SingleOrDefault();
            if (ad != null)
            {

                Session["ad_id"] = ad.admin_id.ToString();
                return RedirectToAction("Proudct","Product");

            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }

            return View();
        }
        public ActionResult create()
        {
            return View();
        }
    }
}
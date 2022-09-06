using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using freshMart.Models;

namespace freshMart.Controllers
{
    public class MainHomeController : Controller
    {

        FreshMartEntities1 db = new FreshMartEntities1();
        // GET: MainHome
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_admin log)
        {
            var user = db.tbl_admin.Where(x => x.admin_username == log.admin_username && x.admin_password == log.admin_password).Count();
            if (user > 0)
            {
                return RedirectToAction("Dashboard");

            }
            else
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {

            return View();
        }


    }
}
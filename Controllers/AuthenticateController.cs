using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using freshMart.Models;

namespace freshMart.Controllers
{
    public class AuthenticateController : Controller
    {

        FreshMartEntities1 entity = new FreshMartEntities1();
        // GET: Authenticate
        public ActionResult Login()
        {
            return View();
        }
    
        public ActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {

            bool userExist = entity.customer_table.Any(x=> x.customer_username == credentials.UserName && x.customer_password == credentials.Password);
            customer_table c = entity.customer_table.FirstOrDefault(x => x.customer_username == credentials.UserName && x.customer_password == credentials.Password);

            if(userExist)
            {
                FormsAuthentication.SetAuthCookie(c.customer_username, false);
                return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError("", "Username or Password is wrong");


            return View();
        }
        [HttpPost]
        public ActionResult Signup(customer_table custometInfo)
        {

            entity.customer_table.Add(custometInfo);
            entity.SaveChanges();


            return RedirectToAction("Login");
        }

        
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Login");
        }
    }
}
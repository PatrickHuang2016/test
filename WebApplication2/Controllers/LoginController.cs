using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string ReturnUrl)
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
           
            MockData.MockData md = MockData.MockData.GetMockData();
           if( md.GetPassword(email) == password)
            {
                Session["UserName"] = email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
                    
        }

        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInfo _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // throw new Exception();
                    MockData.MockData md = MockData.MockData.GetMockData();
                    if (md.AddData(_user))
                    {
                        return RedirectToAction("Index","Login");
                    }
                    else
                    {
                        ViewBag.error = "This email address is already in use. If you’ve forgoten your password click  <a href=\"/Retrieve\">here</a> to retrieve it.";
                        return View();
                    }


                }
                return View();
            }
            catch
            {
                TempData["errormsg"] = "We’re sorry but we were unable to create your account at this time. Please try.";
                return RedirectToAction("Index","Error");
            }
            


        }
    }
}
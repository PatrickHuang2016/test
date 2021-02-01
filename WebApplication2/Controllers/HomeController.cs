using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : CheckLoginController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginError()
        {
            return View();
        }
    }
}
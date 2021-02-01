using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CheckLoginController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var userName = Session["UserName"] as String;
            if (String.IsNullOrEmpty(userName))
            {
               
                filterContext.Result = RedirectToAction("Index", "Login", new { url = Request.RawUrl });
                return;
            }

        }

      
    }
}
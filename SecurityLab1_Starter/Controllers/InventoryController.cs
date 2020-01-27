using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {

        // GET: Inventory
        
        [Authorize (Users = "testuser2")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GenError()
        {
            throw new DivideByZeroException();
            return View();
        }

        [Authorize]
        protected override void OnException(ExceptionContext filterContext)
        {

            filterContext.ExceptionHandled = true;
            //Log the error!!
            Logger.Log(filterContext.Exception.ToString());
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Error");
        }
    }
}
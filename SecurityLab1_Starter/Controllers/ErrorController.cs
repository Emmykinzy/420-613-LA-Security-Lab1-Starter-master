using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            string faultyUrl = Request.QueryString["aspxerrorpath"];

            ViewBag.url = faultyUrl;
            return View();
        }

        public ActionResult NotFound()
        {
            string faultyUrl = Request.QueryString["aspxerrorpath"];
            
            ViewBag.url = faultyUrl;
            return View();
        }

        public ActionResult ServerError()
        {
            string faultyUrl = Request.QueryString["aspxerrorpath"];

            ViewBag.url = faultyUrl;
            return View();
        }
    }
}
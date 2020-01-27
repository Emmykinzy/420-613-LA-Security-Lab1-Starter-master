
using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    Session["auth"] = authProvider.Authenticate(model.UserName, model.Password);
                    Logger.UserLoginLogout(model.UserName, "Logged In");
                    if(returnUrl == null)
                    {
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logoff(string username)
        {
            Session["auth"] = null;
            Logger.UserLoginLogout(username, "Logged Out");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
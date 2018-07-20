using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers
{
    public class LoginController : Controller
    {
        ICustomerBO CustomerBO = new CustomerBO();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(CustomerTO user, string returnUrl)
        {
            var userTO = CustomerBO.ValidateCustomer(user);

            if (userTO != null)
            {
                var userData   = Newtonsoft.Json.JsonConvert.SerializeObject(userTO);
                var authTicket = new FormsAuthenticationTicket(1, userTO.Name, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);
                var encTicket  = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                Response.Cookies.Add(authCookie);

                GenericIdentity identity   = new GenericIdentity(userTO.Login);
                GenericPrincipal principal = new GenericPrincipal(identity, null);
                HttpContext.User           = principal;

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password is incorrect.");
            }
            return View("Index", user);
        }

        [HttpPost]
        public ActionResult Logoff(string user, string password, bool remember)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return View("~/");
        }
    }
}

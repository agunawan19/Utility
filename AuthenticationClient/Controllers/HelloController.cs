using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using AuthenticationClient.Models;

namespace AuthenticationClient.Controllers
{
    public class HelloController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index(Models.HelloClient helloClient)
        {
            const string accessDenied = "Access Denied";
            const string firstTimeMessage = "Please enter username and password";
            string message = string.IsNullOrEmpty(helloClient.UserName)
                             && string.IsNullOrEmpty(helloClient.Password)
                ? firstTimeMessage
                : accessDenied;

            ViewBag.Result = $"{helloClient.HelloWorld() ?? message}, {helloClient.UserName}";
            return View();
        }
    }
}
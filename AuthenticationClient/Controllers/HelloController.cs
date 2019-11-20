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
        public ActionResult Index()
        {
            const string accessDenied = "Access Denied";
            var helloClient = new HelloClient();
            ViewBag.Result = helloClient.HelloWorld() ?? accessDenied;
            return View();
        }
    }
}
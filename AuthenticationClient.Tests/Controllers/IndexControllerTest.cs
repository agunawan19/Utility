using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthenticationClient;
using AuthenticationClient.Controllers;

namespace AuthenticationClient.Tests.Controllers
{
    [TestClass]
    public class IndexControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HelloController controller = new HelloController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Result()
        {
            // Arrange
            HelloController controller = new HelloController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Access Denied", result.ViewBag.Result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication11;
using WebApplication11.Controllers;

namespace WebApplication11.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var session = Mock.Of<HttpSessionStateBase>();
            session["Center"] = "center1";
            var mockSession = Mock.Get(session);
            mockSession.Setup(m => m["Center"]).Returns("center2");

            var httpcontext = Mock.Of<HttpContextBase>();
            var httpcontextSetup = Mock.Get(httpcontext);
            httpcontextSetup.Setup(m => m.Session).Returns(session);

            // Arrange
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpcontext,
                Controller = controller
            };
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

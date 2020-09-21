using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Tests
{
    [TestClass]
    public class SalesTests
    {
        [TestMethod]
        public void GetAsyncReturnsOK()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);

            var result = salesController.GetAsync("1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);

            var result = salesController.GetAsync("4").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}

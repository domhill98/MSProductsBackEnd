using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSProductsBackEnd.API.Controllers;
using System.Collections.Generic;
using MSProductsBackEnd.Data;
using System;
using System.Net.Http;
using System.Web.Http;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MSProductsBackEnd.UnitTests
{
    [TestClass]
    public class BrandsTests
    {

        [TestMethod]
        public async Task GetBrands_ShouldOKObjects()
        {
            //Arrange
            var brands = new List<Brand>()
            {
                new Brand { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "Brand1" },
                new Brand { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Brand2"}
            };

            var mock = new Mock<MSProductsDB>(MockBehavior.Strict);
            mock.Setup(repo => repo.Brands.AddRange(brands));

            var brandCTRL = new BrandsController(mock.Object);

            //ACt
            var result = brandCTRL.GetBrands();


            //Assert
            Assert.IsNotNull(result);
            
            var objResult = result as ActionResult<IEnumerable<Brand>>;
            Assert.IsNotNull(objResult);


            var resultData = objResult.Value as IEnumerable<Brand>;
            Assert.IsNotNull(resultData);
            var resultList = resultData.ToList();

            Assert.AreEqual(brands.Count, resultList.Count);
            for (int i=0; i < brands.Count; i++) 
            {
                Assert.AreEqual(brands[i].Id, resultList[i].Id);
                Assert.AreEqual(brands[i].Name, resultList[i].Name);
            }

        }


    }
}

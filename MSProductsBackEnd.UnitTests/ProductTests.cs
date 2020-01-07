using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSProductsBackEnd.API.Controllers;
using MSProductsBackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductsBackEnd.UnitTests
{
    [TestClass]
    class ProductTests
    {
        //[TestMethod]
        //public async Task GetProducts_ShouldOKObjects()
        //{
        //    //Arrange
        //    var mock = new Mock<MSProductsDB>();

        //    var prodCTRL = new ProductsController(mock.Object);

        //    //ACt
        //    var result = prodCTRL.GetProducts();


        //    //Assert
        //    Assert.IsNotNull(result);

        //    var objResult = result as ActionResult<IEnumerable<Product>>;
        //    Assert.IsNotNull(objResult);


        //    var resultData = objResult.Value as IEnumerable<Product>;
        //    Assert.IsNotNull(resultData);
        //    var resultList = resultData.ToList();

        //    Assert.AreEqual(brands.Count, 3);
        //    for (int i = 0; i < brands.Count; i++)
        //    {
        //        Assert.AreEqual(brands[i].Id, resultList[i].Id);
        //        Assert.AreEqual(brands[i].Name, resultList[i].Name);
        //    }
        //}



        //[TestMethod]
        //public async Task GetProduct_ShouldNotFound()
        //{
        //    //Arrange
        //    var mock = new Mock<MSProductsDB>();

        //    var prodCTRL = new ProductsController(mock.Object);

        //    //ACt
        //    var result = prodCTRL.GetProduct(Guid.Empty);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    var notResult = result.Result as NotFoundResult;

            
        //}





    }
}

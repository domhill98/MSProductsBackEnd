using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSProductsBackEnd.API.Controllers;

namespace MSProductsBackEnd.UnitTests
{
    [TestClass]
    public class BrandsTests
    {
        private Data.MSProductsDB _context;

        public BrandsTests(Data.MSProductsDB context) 
        {
            _context = context;
        }

        [TestMethod]
        public void GetBrands()
        {
            //Arrange
            BrandsController brandCT = new BrandsController(_context);

            //ACt
           var result =  brandCT.GetBrands();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

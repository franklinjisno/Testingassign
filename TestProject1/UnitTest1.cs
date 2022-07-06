using Moq;
using ProductsAPI.Business;
using ProductsAPI.Models;
using ProductsAPI.StorageManager;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails { Name = "Samsung", Category = "Mobile", Rate = "20", Description = "Mobile Phone"};
            storageMock.Setup(x => x.Add(It.IsAny<ProductDetails>())).Returns(true);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.AddProduct(productDetails);
            Assert.NotNull(result);
            Assert.Equal(true,result.Response);
        }
        [Fact]
        public void Test2()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails ();
            storageMock.Setup(x => x.Add(It.IsAny<ProductDetails>())).Returns(false);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.AddProduct(productDetails);
            Assert.NotNull(result);
            Assert.Equal(false, result.Response);
        }
        [Fact]
        public void Test3()
        {
            var storageMock = new Mock<IProductStorageManager>();
            List<ProductListItem> productList = new List<ProductListItem>();
            storageMock.Setup(x => x.GetAll()).Returns(productList);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(productList, result.Response);
        }
        [Fact]
        public void Test4()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails { Name = "Samsung", Category = "Mobile", Rate = "20", Description = "Mobile Phone" };
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.AddProduct(productDetails);
            Assert.NotNull(result);
            Assert.Equal(false, result.Response);
        }
    }
}
using Moq;
using ProductsAPI.Business;
using ProductsAPI.Models;
using ProductsAPI.StorageManager;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddReturnTrue()
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
        public void AddReturnFalse()
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
        public void GetAllReturnProducts()
        {
            var storageMock = new Mock<IProductStorageManager>();
            List<ProductListItem> productList = new List<ProductListItem>();
            var item = new ProductListItem();
            item.Id = "1";
            item.Name = "Samsung";
            productList.Add(item);
            storageMock.Setup(x => x.GetAll()).Returns(productList);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(1, result.Response.Count); ;
        }
        [Fact]
        public void GetAllReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            List<ProductListItem> productList = new List<ProductListItem>();
            storageMock.Setup(x => x.GetAll()).Returns(productList);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound,result.StatusCode);
        }
        [Fact]
        public void GetReturnProduct()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails { Name = "Samsung", Category = "Mobile", Rate = "20", Description = "Mobile Phone" };
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string TestId = "1";
            var result = productBusiness.GetProductDetails(TestId);
            Assert.NotNull(result);
            Assert.Equal("Samsung", result.Response.Name);
        }
        [Fact]
        public void GetReturnBadRequest()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails ();
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string TestId = "";
            var result = productBusiness.GetProductDetails(TestId);
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Fact]
        public void GetReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = null;
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string TestId = "5";
            var result = productBusiness.GetProductDetails(TestId);
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
        [Fact]
        public void DeleteReturnTrue()
        {
            var storageMock = new Mock<IProductStorageManager>();
            storageMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(true);
            ProductDetails productDetails = new ProductDetails { Name = "Samsung", Category = "Mobile", Rate = "20", Description = "Mobile Phone" };
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string testId = "1";
            var result = productBusiness.DeleteProduct(testId);
            Assert.NotNull(result);
            Assert.Equal(true, result.Response);
        }
        [Fact]
        public void DeleteReturnBadRequest()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = null;
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string TestId = "";
            var result = productBusiness.GetProductDetails(TestId);
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Fact]
        public void DeleteReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = null;
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);
            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string TestId = "5";
            var result = productBusiness.GetProductDetails(TestId);
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
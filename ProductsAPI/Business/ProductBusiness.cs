using ProductsAPI.Models;
using ProductsAPI.StorageManager;

namespace ProductsAPI.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductStorageManager productstorage;
        public ProductBusiness(IProductStorageManager productstorage)
        {
            this.productstorage = productstorage;
        }
        public BusinessResponse<bool> AddProduct(ProductDetails product)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            int count = DataHelper.GetAll().Count;
            product.Id = Convert.ToString(count + 1);
            if(product == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            response.Response = productstorage.Add(product);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        public BusinessResponse<List<ProductListItem>> GetAllProducts()
        {
            BusinessResponse<List<ProductListItem>> response = new BusinessResponse<List<ProductListItem>>();
            var products = productstorage.GetAll();
            if (products.Count > 0)
            {
                response.StatusCode=System.Net.HttpStatusCode.OK;
                response.Response = products;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Message = "No Product Exists";
                return response;
            }
        }
        public BusinessResponse<ProductDetails> GetProductDetails(string Id)
        {
            BusinessResponse<ProductDetails> response = new BusinessResponse<ProductDetails>();
            if (string.IsNullOrEmpty(Id))
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Id cannot be null";
                return response;
            }
            response.Response = productstorage.GetProduct(Id);
            if(response.Response != null)
            {
                 response.StatusCode = System.Net.HttpStatusCode.OK;
                 response.Message = "Success";
                 return response;
            }
            else
            {
                 response.StatusCode = System.Net.HttpStatusCode.NotFound;
                 response.Message = "No Product Exists";
                 return response;
            }
        }

        public BusinessResponse<bool> DeleteProduct(string Id)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            if (string.IsNullOrEmpty(Id))
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(Id);
            if (existingProduct.Response == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Message = "No Product Exists";
                return response;
            }
            response.Response = productstorage.Delete(Id);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

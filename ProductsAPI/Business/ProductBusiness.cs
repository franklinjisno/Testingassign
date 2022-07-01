using ProductsAPI.Models;
using ProductsAPI.StorageManager;

namespace ProductsAPI.Business
{
    public class ProductBusiness : IProductBusiness
    {
        ProductStorageManager productstorage = new ProductStorageManager();
        public BusinessResponse<bool> AddProduct(ProductDetails product)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            if(product == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(product.Id);
            if (existingProduct != null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product Exists";
                return response;
            }
            response.Response = productstorage.Add(product);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        public List<ProductListItem> GetAllProducts()
        {
            List<ProductListItem> products = new List<ProductListItem>();
            if (DataHelper.GetAll().Count > 0)
            {
                return productstorage.GetAll();
            }
            else
                return null;
        }
        public BusinessResponse<ProductDetails> GetProductDetails(string Id)
        {
            if (Id != null)
            {
                return productstorage.GetProduct(Id);
            }
            else
                return null;
        }

        public BusinessResponse<bool> DeleteProduct(string Id)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            if (Id == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Product cannot be null";
                return response;
            }
            var existingProduct = GetProductDetails(Id);
            if (existingProduct != null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "No Product Exists";
                return response;
            }
            response.Response = productstorage.Delete(Id);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

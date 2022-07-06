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
            if (DataHelper.GetAll().Count > 0)
            {
                response.StatusCode=System.Net.HttpStatusCode.OK;
                response.Response =  productstorage.GetAll();
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
            if (Id == null)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = "Id cannot be null";
                return response;
            }
            if(Id != null)
            {
                response.Response = productstorage.GetProduct(Id);
                if(response.Response != null)
                {
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Message = "Success";
                    return response;
                }
                else
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Message = "No Product Exists";
                    return response;
                }
            }
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
            if (existingProduct.Response == null)
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

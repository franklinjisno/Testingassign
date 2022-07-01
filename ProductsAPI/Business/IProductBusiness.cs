
using ProductsAPI.Models;

namespace ProductsAPI.Business
{
    public interface IProductBusiness
    {
        BusinessResponse<bool> AddProduct(ProductDetails product);
        List<ProductListItem> GetAllProducts();
        BusinessResponse<ProductDetails> GetProductDetails(string Id);
        BusinessResponse<bool> DeleteProduct(string Id);
    }
}

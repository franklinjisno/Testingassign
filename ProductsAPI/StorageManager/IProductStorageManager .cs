using ProductsAPI.Models;

namespace ProductsAPI.StorageManager
{
    public interface IProductStorageManager
    {
        bool Add(ProductDetails product);
        ProductDetails GetProduct(string Id);
        List<ProductListItem> GetAll();
        bool Delete(string Id);
    }
}

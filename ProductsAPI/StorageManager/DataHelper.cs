using ProductsAPI.Models;

namespace ProductsAPI.StorageManager
{
    public class DataHelper
    {
        public static List<ProductDetails> products = new List<ProductDetails>();

        public static bool Add(ProductDetails productDetails)
        {
            products.Add(productDetails);
            return true;
        }

        public static ProductDetails GetProduct(string Id)
        {
            ProductDetails product = products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
                return null;
        }
        public static List<ProductListItem> GetAll()
        {
            List<ProductListItem> list = products.Select(x => new ProductListItem { Id = x.Id, Name = x.Name }).ToList();


            return list;
        }
        public static bool Delete(string Id)
        {
            products.Remove(GetProduct(Id));
            return true;
        }
    }
}

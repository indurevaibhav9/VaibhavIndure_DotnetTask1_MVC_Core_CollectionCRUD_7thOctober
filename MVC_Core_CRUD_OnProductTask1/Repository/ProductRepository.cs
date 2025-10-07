using MVC_Core_CRUD_OnProductTask1.Models;

namespace MVC_Core_CRUD_OnProductTask1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();
        public bool DeleteById(int id)
        {
            Product product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;
            _products.Remove(product);
            return true;   
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void InsertProduct(Product product)
        {
            _products.Add(product);
            
        }

        public int UpdateProduct(int id, decimal price)
        {
            Product product = _products.FirstOrDefault(product => product.Id == id);    
            product.Price = price;
            return product.Id;
        }
    }
}

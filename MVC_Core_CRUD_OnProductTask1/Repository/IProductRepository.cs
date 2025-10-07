using MVC_Core_CRUD_OnProductTask1.Models;

namespace MVC_Core_CRUD_OnProductTask1.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetById(int id);
        public bool DeleteById(int id);
        public void InsertProduct(Product product);
        public int UpdateProduct(int id, decimal price);
    }
}

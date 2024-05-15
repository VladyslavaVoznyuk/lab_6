using ClassLibrary1.Domain;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        public Product? GetById(int id)
        {
            return this._repository.GetById(id);
        }

        public List<Product> GetProducts()
        {
            return _repository.GetAll().ToList();
        }

        public void AddProduct(Product product)
        {
            this._repository.Add(product);
        }

        public void RemoveProduct(int productId)
        {
            this._repository.Delete(productId);
        }

        public void UpdateProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            this._repository.Update(product);
        }
    }
}
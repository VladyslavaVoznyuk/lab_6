using ClassLibrary1.Domain;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Services
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new();

        public Product? GetById(int id)
        {
            return this._products.FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyList<Product> GetAll()
        {
            return this._products;
        }

        public void Add(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            this._products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = this._products.FirstOrDefault(p => p.Id == product.Id)
                ?? throw new InvalidOperationException("Product was not found.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
        }

        public void Delete(int id)
        {
            var productToRemove = this._products.FirstOrDefault(p => p.Id == id)
                ?? throw new InvalidOperationException("Product not found.");

            this._products.Remove(productToRemove);
        }
    }
}
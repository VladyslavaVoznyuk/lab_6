using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class ProductRepository : IRepository<Product>
    {
        private List<Product> _products = new List<Product>();

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
            }
            else
            {
                ProductNotFound();
            }
        }

        public void Delete(int id)
        {
            _products.RemoveAll(p => p.Id == id);
            if (!_products.Any())
            {
                ProductNotFound();
            }
        }

        private void ProductNotFound()
        {
            throw new InvalidOperationException("Product not found.");
        }
    }

    public class ProductConsolePrinter
    {
        public void DisplayAllProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("All Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
            }
        }
    }
}

using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
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
                throw new InvalidOperationException("Product not found.");
            }
        }

        public void Delete(int id)
        {
            var productToRemove = GetById(id);
            
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("All Products:");
            foreach (var product in _products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }
    }
}

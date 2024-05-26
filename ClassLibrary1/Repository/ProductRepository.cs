using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Products;

namespace ClassLibrary1.Repository
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
                Console.WriteLine($"Product '{product.Name}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product with ID '{productId}' not found.");
            }
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void DisplayAllProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("All Products:");
                foreach (var product in _products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
            }
        }
    }
}

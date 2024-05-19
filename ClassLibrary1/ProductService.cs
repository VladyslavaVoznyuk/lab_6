using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            _products.Add(product);
            PrintProductAddedMessage(product.Name);
        }

        public void RemoveProduct(int productId)
        {
            int initialCount = _products.Count;
            _products.RemoveAll(p => p.Id == productId);
            if (_products.Count < initialCount)
            {
                Product removedProduct = _products.FirstOrDefault(p => p.Id == productId);
                PrintProductRemovedMessage(removedProduct?.Name ?? $"Product with ID '{productId}'");
            }
            else
            {
                Console.WriteLine($"Product with ID '{productId}' not found.");
            }
        }

        private void ValidateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(product));
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero.", nameof(product));
            }

            if (product.Quantity < 0)
            {
                throw new ArgumentException("Product quantity must be non-negative.", nameof(product));
            }
        }

        private void PrintProductAddedMessage(string productName)
        {
            Console.WriteLine($"Product '{productName}' added successfully.");
        }

        private void PrintProductRemovedMessage(string productName)
        {
            Console.WriteLine($"Product '{productName}' removed successfully.");
        }
    }
}
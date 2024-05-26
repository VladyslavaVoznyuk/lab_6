﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Products;

namespace ClassLibrary1.MenuServices
{
    public class ProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            ValidateProduct(product);
            _products.Add(product);
            Console.WriteLine($"Product '{product.Name}' added successfully.");
        }

        public void RemoveProduct(int productId)
        {
            var productToRemove = _products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
                Console.WriteLine($"Product '{productToRemove.Name}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Product with ID '{productId}' not found.");
            }
        }

        private void ValidateProduct(Product product)
        {
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
                throw new ArgumentException("Product quantity cannot be negative.", nameof(product));
            }
        }
    }
}

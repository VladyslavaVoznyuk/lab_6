using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Notifications;
using ClassLibrary1.Products;
using ClassLibrary1.Repository;

namespace ClassLibrary1.MenuServices
{
    public class ProductCreationService
    {
        private readonly ProductService _productService;
        private readonly EmailNotificationService _notificationService;
        private readonly ProductRepository _productRepository;

        public ProductCreationService(ProductService productService, EmailNotificationService notificationService, ProductRepository productRepository)
        {
            _productService = productService;
            _notificationService = notificationService;
            _productRepository = productRepository;
        }

        public void AddNewProduct(ref int idCounter)
        {
            Product product = CreateProduct(idCounter);
            _productService.AddProduct(product);
            _notificationService.SendNotification(product);
            _productRepository.Add(product);

            Console.WriteLine("Product added successfully!");
            idCounter++;
        }

        private Product CreateProduct(int idCounter)
        {
            string name;
            do
            {
                Console.Write("Enter product name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            double price;
            do
            {
                Console.Write("Enter product price: ");
            } while (!double.TryParse(Console.ReadLine(), out price) || price <= 0);

            int quantity;
            do
            {
                Console.Write("Enter product quantity: ");
            } while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0);

            return new Product { Id = idCounter, Name = name, Price = price, Quantity = quantity };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Repository;

namespace ClassLibrary1.MenuServices
{
    public class ReportService
    {
        private readonly ProductRepository _productRepository;
        private readonly Inventory _inventory;

        public ReportService(ProductRepository productRepository, Inventory inventory)
        {
            _productRepository = productRepository;
            _inventory = inventory;
        }

        public void GenerateReport()
        {
            Console.WriteLine("Generating Report...");

            // Загальний звіт про всі продукти
            _productRepository.DisplayAllProducts();

            // Звіт про продукти в інвентарі
            if (_inventory.Products.Count == 0)
            {
                Console.WriteLine("No products found in the inventory.");
            }
            else
            {
                Console.WriteLine("Inventory Report:");
                foreach (var item in _inventory.Products)
                {
                    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                }
            }
        }
    }
}

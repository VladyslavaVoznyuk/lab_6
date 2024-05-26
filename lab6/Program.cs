using ClassLibrary1.MenuServices;
using ClassLibrary1.Notifications;
using ClassLibrary1.Repository;
using System;

class Program
{
    static void Main(string[] args)
    {
        ProductService productService = new ProductService();
        Inventory inventory = new Inventory();
        EmailNotificationService notificationService = new EmailNotificationService();
        ProductRepository productRepository = new ProductRepository();
        ReportService reportService = new ReportService(productRepository, inventory);
        ProductCreationService productCreationService = new ProductCreationService(productService, notificationService, productRepository);
        InventoryService inventoryService = new InventoryService(inventory, productRepository);
        ProductDeletionService productDeletionService = new ProductDeletionService(productService, inventory, productRepository);
        DisplayService displayService = new DisplayService(productRepository, inventory);

        int idCounter = 0;

        while (true)
        {
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    productCreationService.AddNewProduct(ref idCounter);
                    break;
                case "2":
                    inventoryService.AddProductToInventory();
                    break;
                case "3":
                    inventoryService.UpdateInventory();
                    break;
                case "4":
                    productDeletionService.DeleteProduct();
                    break;
                case "5":
                    displayService.DisplayAllProducts();
                    break;
                case "6":
                    displayService.DisplayInventory();
                    break;
                case "7":
                    reportService.GenerateReport();
                    break;
                case "8":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("1. Create Product");
        Console.WriteLine("2. Add Product to Inventory");
        Console.WriteLine("3. Update Inventory Product QTY");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. View All Products");
        Console.WriteLine("6. View Inventory");
        Console.WriteLine("7. Generate Report");
        Console.WriteLine("8. Exit");
        Console.Write("Enter your choice: ");
    }
}

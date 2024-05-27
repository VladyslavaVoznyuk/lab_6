using ClassLibrary1;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ProductService productService = new ProductService();
        Inventory inventory = new Inventory();
        EmailNotificationService notificationService = new EmailNotificationService();
        ProductRepository productRepository = new ProductRepository();

        int idCounter = 0;

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewProduct(productService, notificationService, productRepository, ref idCounter);
                    break;
                case "2":
                    AddProductToInventory(inventory, productRepository);
                    break;
                case "3":
                    UpdateInventory(inventory, productRepository);
                    break;
                case "4":
                    DeleteProduct(productService, inventory, productRepository);
                    break;
                case "5":
                    productRepository.DisplayAllProducts();
                    break;
                case "6":
                    DisplayInventory(inventory);
                    break;
                case "7":
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
        Console.WriteLine("7. Exit");
        Console.Write("Enter your choice: ");
    }

    static void AddNewProduct(ProductService productService, EmailNotificationService notificationService, ProductRepository productRepository, ref int idCounter)
    {
        Product product = CreateProduct(idCounter);

        productService.AddProduct(product);
        notificationService.SendNotification(product);
        productRepository.Add(product);

        Console.WriteLine("Product added successfully!");
        idCounter++;
    }

    static Product CreateProduct(int idCounter)
    {
        string name = PromptString("Enter product name: ");
        double price = PromptDouble("Enter product price: ");
        int quantity = PromptInt("Enter product quantity: ");

        return new Product { Id = idCounter, Name = name, Price = price, Quantity = quantity };
    }

    static void AddProductToInventory(Inventory inventory, ProductRepository productRepository)
    {
        int productId = PromptInt("Enter product ID to add to inventory: ");
        Product product = productRepository.GetById(productId);

        if (product != null)
        {
            inventory.AddProductToInventory(product);
            Console.WriteLine("Product added to inventory successfully!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void UpdateInventory(Inventory inventory, ProductRepository productRepository)
    {
        int productId = PromptInt("Enter product ID to update inventory: ");
        int newQuantity = PromptInt("Enter new quantity: ");

        Product product = productRepository.GetById(productId);

        if (product != null)
        {
            inventory.UpdateInventory(product, newQuantity);
            Console.WriteLine("Inventory updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void DeleteProduct(ProductService productService, Inventory inventory, ProductRepository productRepository)
    {
        int productId = PromptInt("Enter product ID to delete: ");
        Product product = productRepository.GetById(productId);

        if (product != null)
        {
            productService.RemoveProduct(productId);
            inventory.RemoveProductFromInventory(product);
            productRepository.Delete(productId);

            Console.WriteLine("Product deleted successfully!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void DisplayInventory(Inventory inventory)
    {
        if (inventory.Products.Count == 0)
        {
            Console.WriteLine("No products found in the inventory.");
        }
        else
        {
            Console.WriteLine("Inventory:");
            foreach (var item in inventory.Products)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
        }
    }

    static string PromptString(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    static int PromptInt(string message)
    {
        int result;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }

    static double PromptDouble(string message)
    {
        double result;
        do
        {
            Console.Write(message);
        } while (!double.TryParse(Console.ReadLine(), out result));
        return result;
    }
}

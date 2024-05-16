using ClassLibrary1;
using System;

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
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Add Product to Inventory");
            Console.WriteLine("3. Update Inventory Product QTY");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. View Inventory");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Product product = null;
                    do
                    {
                        product = CreateProduct(idCounter);
                    } while (product == null);

                    productService.AddProduct(product);
                    notificationService.SendNotification(product);
                    productRepository.Add(product);

                    Console.WriteLine("Product added successfully!");
                    idCounter++;
                    break;

                case "2":
                    int productIdToAddToInventory;
                    do
                    {
                        Console.Write("Enter product ID to add to inventory: ");
                    } while (!int.TryParse(Console.ReadLine(), out productIdToAddToInventory));

                    Product productToAddToInventory = productRepository.GetById(productIdToAddToInventory);
                    if (productToAddToInventory != null)
                    {
                        inventory.AddProductToInventory(productToAddToInventory);
                        Console.WriteLine("Product added to inventory successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;

                case "3":
                    int productIdToUpdateInventory;
                    do
                    {
                        Console.Write("Enter product ID to update inventory: ");
                    } while (!int.TryParse(Console.ReadLine(), out productIdToUpdateInventory));

                    int newQuantity;
                    do
                    {
                        Console.Write("Enter new quantity: ");
                    } while (!int.TryParse(Console.ReadLine(), out newQuantity));

                    Product productToUpdateInventory = productRepository.GetById(productIdToUpdateInventory);
                    if (productToUpdateInventory != null)
                    {
                        inventory.UpdateInventory(productToUpdateInventory, newQuantity);
                        Console.WriteLine("Inventory updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;

                case "4":
                    int productIdToDelete;
                    do
                    {
                        Console.Write("Enter product ID to delete: ");
                    } while (!int.TryParse(Console.ReadLine(), out productIdToDelete));

                    Product productToDelete = productRepository.GetById(productIdToDelete);
                    if (productToDelete != null)
                    {
                        productService.RemoveProduct(productIdToDelete);
                        inventory.RemoveProductFromInventory(productToDelete);
                        productRepository.Delete(productIdToDelete);

                        Console.WriteLine("Product deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;

                case "5":
                    Console.WriteLine("All Products:");
                    productRepository.DisplayAllProducts();
                    break;

                case "6":
                    Console.WriteLine("Inventory:");
                    foreach (var item in inventory.Products)
                    {
                        Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                    }
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

    static Product CreateProduct(int idCounter)
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
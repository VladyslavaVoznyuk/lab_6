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
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter product quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Product product = new Product {Id = idCounter, Name = name, Price = price, Quantity = quantity };
                    productService.AddProduct(product);
                    notificationService.SendNotification(product);
                    productRepository.Add(product);

                    Console.WriteLine("Product added successfully!");
                    idCounter++;

                    break;

                case "2":
                    Console.Write("Enter product id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    inventory.AddProductToInventory(productRepository.GetById(id));
                    notificationService.SendNotification(productRepository.GetById(id));

                    Console.WriteLine("Product successfully added to inventory!");
                    idCounter++;

                    break;

                case "3":
                    Console.Write("Enter product ID to update: ");
                    int productIdToUpdate = Convert.ToInt32(Console.ReadLine());
                    int changeQTY = 0;
                    Product productToUpdate = productRepository.GetById(productIdToUpdate);
                    if (productToUpdate != null)
                    {
                        Console.Write("Enter how to change product quantity: ");
                        changeQTY = Convert.ToInt32(Console.ReadLine());

                       // productService.UpdateProduct(productToUpdate);
                        inventory.UpdateInventory(productToUpdate, changeQTY);
                       // productRepository.Update(productToUpdate);

                        Console.WriteLine("Product updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;

                case "4":
                    Console.Write("Enter product ID to delete: ");
                    int productIdToDelete = Convert.ToInt32(Console.ReadLine());
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
}

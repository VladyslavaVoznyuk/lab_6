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
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
<<<<<<< HEAD
                    AddNewProduct(productService, notificationService, productRepository, ref idCounter);
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183
                    break;
                case "2":
<<<<<<< HEAD
                    AddProductToInventory(inventory, productRepository);
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183
                    break;
                case "3":
<<<<<<< HEAD
                    UpdateInventory(inventory, productRepository);
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183
                    break;
                case "4":
<<<<<<< HEAD
                    DeleteProduct(productService, inventory, productRepository);
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183
                    break;
                case "5":
                    productRepository.DisplayAllProducts();
                    break;
                case "6":
<<<<<<< HEAD
                    DisplayInventory(inventory);
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183
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

<<<<<<< HEAD
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
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        double price;
        while (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price format. Please enter a valid number.");
            Console.Write("Enter product price: ");
        }
        Console.Write("Enter product quantity: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid quantity format. Please enter a valid number.");
            Console.Write("Enter product quantity: ");
        }

        Product product = new Product { Id = idCounter, Name = name, Price = price, Quantity = quantity };
        productService.AddProduct(product);
        notificationService.SendNotification(product);
        productRepository.Add(product);

        Console.WriteLine("Product added successfully!");
        idCounter++;
    }

    static void AddProductToInventory(Inventory inventory, ProductRepository productRepository)
    {
        Console.Write("Enter product id: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
            Console.Write("Enter product id: ");
        }

        Product product = productRepository.GetById(id);
        if (product != null)
        {
            inventory.AddProductToInventory(product);
            Console.WriteLine("Product successfully added to inventory!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void UpdateInventory(Inventory inventory, ProductRepository productRepository)
    {
        Console.Write("Enter product ID to update: ");
        int productIdToUpdate;
        while (!int.TryParse(Console.ReadLine(), out productIdToUpdate))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
            Console.Write("Enter product ID to update: ");
        }

        int changeQTY;
        Console.Write("Enter how to change product quantity: ");
        while (!int.TryParse(Console.ReadLine(), out changeQTY))
        {
            Console.WriteLine("Invalid quantity format. Please enter a valid number.");
            Console.Write("Enter how to change product quantity: ");
        }

        Product productToUpdate = productRepository.GetById(productIdToUpdate);
        if (productToUpdate != null)
        {
            inventory.UpdateInventory(productToUpdate, changeQTY);
            Console.WriteLine("Product updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void DeleteProduct(ProductService productService, Inventory inventory, ProductRepository productRepository)
    {
        Console.Write("Enter product ID to delete: ");
        int productIdToDelete;
        while (!int.TryParse(Console.ReadLine(), out productIdToDelete))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
            Console.Write("Enter product ID to delete: ");
        }

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
    }

    static void DisplayInventory(Inventory inventory)
    {
        Console.WriteLine("Inventory:");
        foreach (var item in inventory.Products)
        {
            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
        }
    }
}
=======
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
>>>>>>> 5694886d103966f1423c07f50c3edd9d44639183

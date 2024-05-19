using ClassLibrary1;
using System;

class Program
{
    static void Main(string[] args)
    {
        var productService = new ProductService();
        var inventory = new Inventory();
        var notificationService = new EmailNotificationService();
        var productRepository = new ProductRepository();
        var menuService = new MenuService(productService, inventory, notificationService, productRepository);

        menuService.RunMenu();
    }
}

public class MenuService
{
    private readonly ProductService _productService;
    private readonly Inventory _inventory;
    private readonly EmailNotificationService _notificationService;
    private readonly ProductRepository _productRepository;

    public MenuService(ProductService productService, Inventory inventory, EmailNotificationService notificationService, ProductRepository productRepository)
    {
        _productService = productService;
        _inventory = inventory;
        _notificationService = notificationService;
        _productRepository = productRepository;
    }

    public void RunMenu()
    {
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
                    _productService.AddProduct(CreateProduct(idCounter++));
                    break;

                case "2":
                    _inventory.AddProductToInventory(_productRepository.GetById(GetProductIdFromUser()));
                    break;

                case "3":
                    int productIdToUpdateInventory = GetProductIdFromUser();
                    int newQuantity = GetNewQuantityFromUser();
                    _inventory.UpdateInventory(_productRepository.GetById(productIdToUpdateInventory), newQuantity);
                    break;

                case "4":
                    int productIdToDelete = GetProductIdFromUser();
                    _productService.RemoveProduct(productIdToDelete);
                    _inventory.RemoveProductFromInventory(_productRepository.GetById(productIdToDelete));
                    break;

                case "5":
                    _productRepository.DisplayAllProducts();
                    break;

                case "6":
                    _inventory.DisplayInventory();
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

    private int GetProductIdFromUser()
    {
        int productId;
        do
        {
            Console.Write("Enter product ID: ");
        } while (!int.TryParse(Console.ReadLine(), out productId));

        return productId;
    }

    private int GetNewQuantityFromUser()
    {
        int newQuantity;
        do
        {
            Console.Write("Enter new quantity: ");
        } while (!int.TryParse(Console.ReadLine(), out newQuantity));

        return newQuantity;
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
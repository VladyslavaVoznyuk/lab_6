using ClassLibrary1.Domain;

namespace ClassLibrary1.Services
{
    public class Inventory
    {
        private readonly ProductService _productService;
        private readonly EmailNotificationService _emailNotificationService;
        public Inventory(ProductService productService, EmailNotificationService emailNotificationService)
        {
            this._productService = productService;
            this._emailNotificationService = emailNotificationService;
        }

        public List<Product> Products =>
            this._productService.GetProducts();

        public Product? GetProduct(int id)
        {
            return this._productService.GetById(id);
        }

        public void AddProductToInventory(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            this._productService.AddProduct(product);

            this._emailNotificationService.SendNotification(product);

            Console.WriteLine($"Product '{product.Name}' added to inventory.");
        }

        public void RemoveProductFromInventory(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            this._productService.RemoveProduct(product.Id);
            Console.WriteLine($"Product '{product.Name}' removed from inventory.");
        }

        public void UpdateInventory(Product product, int quantityChange)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            product.Quantity += quantityChange;
            this._productService.UpdateProduct(product);

            Console.WriteLine($"Inventory updated for product '{product.Name}'. New quantity: {product.Quantity}");
        }
    }
}

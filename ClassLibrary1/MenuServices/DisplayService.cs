using ClassLibrary1.Repository;

namespace ClassLibrary1.MenuServices
{
    public class DisplayService
    {
        private readonly ProductRepository _productRepository;
        private readonly Inventory _inventory;

        public DisplayService(ProductRepository productRepository, Inventory inventory)
        {
            _productRepository = productRepository;
            _inventory = inventory;
        }

        public void DisplayAllProducts()
        {
            _productRepository.DisplayAllProducts();
        }

        public void DisplayInventory()
        {
            if (_inventory.Products.Count == 0)
            {
                Console.WriteLine("No products found in the inventory.");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (var item in _inventory.Products)
                {
                    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                }
            }
        }
    }
}

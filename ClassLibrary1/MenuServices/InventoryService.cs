using ClassLibrary1.Products;
using ClassLibrary1.Repository;

namespace ClassLibrary1.MenuServices
{
    public class InventoryService
    {
        private readonly Inventory _inventory;
        private readonly ProductRepository _productRepository;

        public InventoryService(Inventory inventory, ProductRepository productRepository)
        {
            _inventory = inventory;
            _productRepository = productRepository;
        }

        public void AddProductToInventory()
        {
            int id = GetProductIdFromUser("Enter product ID to add to inventory: ");
            Product product = _productRepository.GetById(id);

            if (product != null)
            {
                _inventory.AddProductToInventory(product);
                Console.WriteLine("Product added to inventory successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        public void UpdateInventory()
        {
            int productIdToUpdate = GetProductIdFromUser("Enter product ID to update inventory: ");
            int newQuantity = GetProductQuantityFromUser("Enter new quantity: ");

            Product productToUpdateInventory = _productRepository.GetById(productIdToUpdate);
            if (productToUpdateInventory != null)
            {
                _inventory.UpdateInventory(productToUpdateInventory, newQuantity);
                Console.WriteLine("Inventory updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private int GetProductIdFromUser(string prompt)
        {
            int productId;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out productId));

            return productId;
        }

        private int GetProductQuantityFromUser(string prompt)
        {
            int quantity;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0);

            return quantity;
        }
    }
}

using ClassLibrary1.Products;
using ClassLibrary1.Repository;

namespace ClassLibrary1.MenuServices
{
    public class ProductDeletionService
    {
        private readonly ProductService _productService;
        private readonly Inventory _inventory;
        private readonly ProductRepository _productRepository;

        public ProductDeletionService(ProductService productService, Inventory inventory, ProductRepository productRepository)
        {
            _productService = productService;
            _inventory = inventory;
            _productRepository = productRepository;
        }

        public void DeleteProduct()
        {
            int productIdToDelete = GetProductIdFromUser("Enter product ID to delete: ");
            Product productToDelete = _productRepository.GetById(productIdToDelete);

            if (productToDelete != null)
            {
                _productService.RemoveProduct(productIdToDelete);
                _inventory.RemoveProductFromInventory(productToDelete);
                _productRepository.Delete(productIdToDelete);

                Console.WriteLine("Product deleted successfully!");
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
    }
}

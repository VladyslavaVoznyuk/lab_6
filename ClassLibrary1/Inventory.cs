using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Inventory
    {

        private List<Product> _products = new List<Product>();

        public List<Product> Products
        {
            get { return _products; }
        }

        public void AddProductToInventory(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            _products.Add(product);

            Console.WriteLine($"Product '{product.Name}' added to inventory.");
        }

        public void RemoveProductFromInventory(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            if (_products.Contains(product))
            {
                _products.Remove(product);
                Console.WriteLine($"Product '{product.Name}' removed from inventory.");
            }
            else
            {
                Console.WriteLine($"Product '{product.Name}' not found in inventory.");
            }
        }

        public void UpdateInventory(Product product, int newQuantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            product.Quantity += newQuantity;
            Console.WriteLine($"Inventory updated for product '{product.Name}'. New quantity: {product.Quantity}");
        }
    }

}

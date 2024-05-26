using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Products
{
    public class ClothingProduct : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }

        public ClothingProduct(string name, double price, int quantity, string size, string color, string material)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Size = size;
            Color = color;
            Material = material;
        }
    }
}

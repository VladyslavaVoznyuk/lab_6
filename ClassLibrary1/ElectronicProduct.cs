using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ElectronicProduct : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

        
        public ElectronicProduct(string name, double price, int quantity, string brand, string model, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Brand = brand;
            Model = model;
            Type = type;
        }
    }

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

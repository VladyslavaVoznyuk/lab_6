using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Products
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
}

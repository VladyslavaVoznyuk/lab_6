using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class ElectronicProduct : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        //уникнення дублювання логіки ініціалізації
        public ElectronicProduct(int id, string name, double price, int quantity, string brand, string model, string type)
        : base(id, name, price, quantity)
        {
            Brand = brand;
            Model = model;
            Type = type;
        }
    }
}

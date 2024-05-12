using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class ClothingProduct : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        //уникнення дублювання логіки ініціалізації
        public ClothingProduct(int id, string name, double price, int quantity, string size, string color, string material)
        : base(id, name, price, quantity)
        {
            Size = size;
            Color = color;
            Material = material;
        }
    }

}

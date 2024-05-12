using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Factories
{
    public class ElectronicProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new ElectronicProduct(1,"Smartphone", 499.99, 10, "Samsung", "Galaxy S20", "Smartphone");
        }
    }
}

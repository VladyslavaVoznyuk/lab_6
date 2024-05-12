using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct();
    }


    public class ElectronicProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            
            return new ElectronicProduct("Smartphone", 499.99, 10, "Samsung", "Galaxy S20", "Smartphone");
        }
    }

    public class ClothingProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new ClothingProduct("T-shirt", 19.99, 50, "L", "Black", "Cotton");
        }
    }



}

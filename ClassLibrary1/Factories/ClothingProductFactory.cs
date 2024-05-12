using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Factories
{
    public class ClothingProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new ClothingProduct(1,"T-shirt", 19.99, 50, "L", "Black", "Cotton");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Factories
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct();
    }
}

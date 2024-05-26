using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Products
{
    public interface IObserver
    {
        void Update(Product product);
    }

}

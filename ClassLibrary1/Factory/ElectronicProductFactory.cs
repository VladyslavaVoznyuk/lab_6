using ClassLibrary1.Domain;

namespace ClassLibrary1.Factory
{
    public class ElectronicProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {

            return new ElectronicProduct("Smartphone", 499.99, 10, "Samsung", "Galaxy S20", "Smartphone");
        }
    }
}
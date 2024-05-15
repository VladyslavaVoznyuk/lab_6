using ClassLibrary1.Domain;

namespace ClassLibrary1.Factory
{
    public class ClothingProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new ClothingProduct("T-shirt", 19.99, 50, "L", "Black", "Cotton");
        }
    }
}
namespace ClassLibrary1.Domain
{
    public class ClothingProduct : Product
    {
        public string Size { get; private set; }
        public string Color { get; private set; }
        public string Material { get; private set; }

        public ClothingProduct(
            string name,
            double price,
            int quantity,
            string size,
            string color,
            string material)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Size = size;
            this.Color = color;
            this.Material = material;
        }
    }

}

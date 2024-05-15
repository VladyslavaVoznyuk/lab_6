namespace ClassLibrary1.Domain
{
    public class ElectronicProduct : Product
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Type { get; private set; }

        public ElectronicProduct(
            string name,
            double price,
            int quantity,
            string brand,
            string model,
            string type)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Brand = brand;
            this.Model = model;
            this.Type = type;
        }
    }

}

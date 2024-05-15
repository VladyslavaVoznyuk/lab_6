namespace ClassLibrary1.Domain
{
    public class Product
    {
        private static int currentId = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        protected Product() { }

        public static Product Create(string name, double price, int quantity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            }

            if (double.IsNaN(price) || price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Invalid value for product price was provided. Price must have positive value.");
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Invalid value for product quantity was provided. Quantoty must have non-negative value.");
            }

            return new Product 
            { 
                Id = ++currentId, 
                Name = name, 
                Price = price, 
                Quantity = quantity 
            };
        }
    }
}
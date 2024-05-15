using ClassLibrary1.Domain;
using ClassLibrary1.Services;
using Spectre.Console;

namespace lab6
{
    public class ConsoleUI
    {
        private readonly Menu.Menu _mainMenu = new();
        private bool _eventLoop = true;

        private readonly Inventory _inventory;

        public ConsoleUI(Inventory inventory)
        {
            InitMainMenu();
            this._inventory = inventory;
        }

        public void InitMainMenu()
        {
            this._mainMenu.AddItem("Create Product", this.CreateProduct);
            this._mainMenu.AddItem("Update Inventory Product Quantity", this.UpdateInventory);
            this._mainMenu.AddItem("Delete Product", this.DeleteProduct);
            this._mainMenu.AddItem("View Inventory", this.PrintInventory);
            this._mainMenu.AddItem("Exit", () => this._eventLoop = false);
        }

        public void Run()
        {
            while (this._eventLoop)
            {
                try
                {
                    this._mainMenu.Show()?.Invoke();
                }
                catch (Exception ex)
                {
                    ConsoleExtension.PrintError($"{ex.GetType().Name}: ${ex.Message}\n{ex.StackTrace}");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        private void CreateProduct()
        {
            string name = AnsiConsole.Prompt(new TextPrompt<string>("Enter product name: "));
            double price = AnsiConsole.Prompt(new TextPrompt<double>("Enter product price: "));
            int quantity = AnsiConsole.Prompt(new TextPrompt<int>("Enter product quantity: "));

            var product = Product.Create(name, price, quantity);

            this._inventory.AddProductToInventory(product);

            ConsoleExtension.PrintSuccess("Product was added successfully!");
        }

        private void UpdateInventory()
        {
            int productIdToUpdate = AnsiConsole.Prompt(new TextPrompt<int>("Enter product Id to update: "));


            var productToUpdate = this._inventory.GetProduct(productIdToUpdate);

            if (productToUpdate is null)
            {
                ConsoleExtension.PrintWarning("Product was not found");
                return;
            }

            int changeQuantity = AnsiConsole.Prompt(new TextPrompt<int>("Enter how to change product quantity: "));

            this._inventory.UpdateInventory(productToUpdate, changeQuantity);

            ConsoleExtension.PrintSuccess("Product was updated successfully!");
        }

        private void DeleteProduct()
        {
            int productIdToDelete = AnsiConsole.Prompt(new TextPrompt<int>("Enter product Id to delete: "));

            var productToDelete = this._inventory.GetProduct(productIdToDelete);

            if (productToDelete is null)
            {
                ConsoleExtension.PrintWarning("Product was not found");
                return;
            }

            this._inventory.RemoveProductFromInventory(productToDelete);

            ConsoleExtension.PrintSuccess("Product deleted successfully!");
        }

        private void PrintInventory()
        {
            var table = new Table
            {
                Title = new TableTitle("Products", new Style(Color.Blue, null, Decoration.Bold)),
                Border = TableBorder.Ascii
            };

            table.AddColumn(new TableColumn("Id").Centered());
            table.AddColumn(new TableColumn("Name"));
            table.AddColumn(new TableColumn("Price"));
            table.AddColumn(new TableColumn("Quantity"));

            foreach (var product in this._inventory.Products)
            {
                table.AddRow(
                    product.Id.ToString(),
                    product.Name,
                    product.Price.ToString(),
                    product.Quantity.ToString());
            }

            AnsiConsole.Write(table);
        }

    }
}
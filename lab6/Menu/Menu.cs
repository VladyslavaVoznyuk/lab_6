using Spectre.Console;

namespace lab6.Menu
{
    internal class Menu
    {
        private readonly List<MenuItem> _menuItems = new();
        private MenuItem? _currentParent = null;
        public Action? Show()
        {
            string key;
            Action? result = null;
            while (true)
            {
                var elements = this._menuItems.Where(i => i.Parent == this._currentParent).Select(i => i.Title).ToArray();
                var prompt = new SelectionPrompt<string>().AddChoices<string>(elements);
                if (this._currentParent is not null)
                    prompt.AddChoice("..");
                AnsiConsole.Clear();
                key = AnsiConsole.Prompt(prompt);
                var item = this._menuItems.Where(i => i.Title == key).FirstOrDefault();
                if (item is null)
                {
                    this._currentParent = this._currentParent?.Parent;
                    continue;
                }
                if (item.Action is null)
                {
                    this._currentParent = item;
                    continue;
                }
                result = item.Action;
                break;
            }
            return result;
        }
        
        public MenuItem? AddItem(string title, Action? action = null, MenuItem? parent = null)
        {
            if (title == ".." || string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Unable to add new menu item. The title provided can not be used");
            this._menuItems.Add(new MenuItem(title, action: action, parent: parent) { Id = this._menuItems.Count });
            return this._menuItems.LastOrDefault();
        }
    }
}

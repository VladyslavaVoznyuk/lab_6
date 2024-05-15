namespace lab6.Menu
{
    internal class MenuItem
    {
        public int Id { get; set; }
        public MenuItem? Parent { get; set; }
        public string Title { get; }
        public Action? Action { get; set; }
        public MenuItem(string title, Action? action = null, MenuItem? parent = null)
        {
            this.Parent = parent;
            this.Title = title;
            this.Action = action;
        }
    }
}
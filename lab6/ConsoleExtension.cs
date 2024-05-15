namespace lab6
{
    public static class ConsoleExtension
    {
        private static void PrintMessageWithColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void PrintError(string msg)
        {
            PrintMessageWithColor(msg, ConsoleColor.Red);
        }

        public static void PrintWarning(string msg)
        {
            PrintMessageWithColor(msg, ConsoleColor.Yellow);
        }

        public static void PrintSuccess(string msg)
        {
            PrintMessageWithColor(msg, ConsoleColor.Green);
        }
    }
}

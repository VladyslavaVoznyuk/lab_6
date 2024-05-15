using ClassLibrary1.Domain;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Services;
using lab6;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        new ServiceCollection()
            .AddTransient<IRepository<Product>, ProductRepository>()
            .AddSingleton<EmailNotificationService>()
            .AddSingleton<ProductService>()
            .AddSingleton<Inventory>()
            .AddSingleton<ConsoleUI>()
            .BuildServiceProvider()
            .GetRequiredService<ConsoleUI>()
            .Run();
    }
}
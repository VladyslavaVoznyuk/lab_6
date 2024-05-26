using System;
using ClassLibrary1.Products;

namespace ClassLibrary1.Notifications
{
    public abstract class NotificationService
    {
        public abstract void SendNotification(Product product);

        protected void SendEmailNotification(Product product)
        {
            Console.WriteLine($"Sending email notification for product '{product.Name}'...");

            Console.WriteLine("Email notification sent successfully.");
        }
    }
}

using System;

namespace ClassLibrary1
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

    public class EmailNotificationService : NotificationService, IObserver
    {
        public override void SendNotification(Product product)
        {
            SendEmailNotification(product);
        }

        public void Update(Product product)
        {
            SendEmailNotification(product);
        }
    }

}

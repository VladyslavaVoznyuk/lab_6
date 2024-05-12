using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected void SendSMSNotification(Product product)
        {
            Console.WriteLine($"Sending SMS notification for product '{product.Name}'...");
            Console.WriteLine("SMS notification sent successfully.");
        }
    }

    public class EmailNotificationService : NotificationService
    {
        public override void SendNotification(Product product)
        {
            SendEmailNotification(product);
        }
    }

    public class SMSNotificationService : NotificationService
    {
        public override void SendNotification(Product product)
        {
            SendSMSNotification(product);
        }
    }

}

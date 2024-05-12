using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1
{
    public abstract class NotificationService
    {
        //можливо додати додаткові класи у вигляді патерну Strategy, щоб покращити логіку коду
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
}

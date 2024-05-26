using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Products;

namespace ClassLibrary1.Notifications
{
    public class EmailNotificationService
    {
        public void SendNotification(Product product)
        {
            // Send notification logic
            Console.WriteLine($"Notification sent for product: {product.Name}");
        }
    }
}

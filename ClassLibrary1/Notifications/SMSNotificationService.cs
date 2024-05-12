using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Notifications
{
    public class SMSNotificationService : NotificationService
    {
        public override void SendNotification(Product product)
        {
            SendSMSNotification(product);
        }
    }
}

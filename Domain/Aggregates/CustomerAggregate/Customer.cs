using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Customer()
        { }

        public Customer(string code, string name) : this()
        {
            Code = code;
            Name = name;
        }

        public void SendNotification(string message, string title = null)
        {
            if (message == String.Empty || message == null)
            {
                return;
            }

            if (title == String.Empty || title == null)
            {
                title = "Notification";
            }

            string notificationContent = $">>>> {title} <<<< \n{message}";
            Console.WriteLine(notificationContent);
        }
    }
}

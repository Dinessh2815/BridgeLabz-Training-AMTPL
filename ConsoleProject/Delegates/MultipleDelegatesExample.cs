using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Delegates
{
    internal class MultipleDelegatesExample
    {
        public delegate void Notifier(string message);
        public class NotificationService
        {
            public void SendEmail(string message)
            {
                Console.WriteLine("Email Sent: " + message);
            }
            public void SendSMS(string message)
            {
                Console.WriteLine("SMS Sent: " + message);
            }
        }

        public static void Main(string[] args)
        {
            NotificationService service = new NotificationService();
            Notifier Notify = service.SendEmail;
            Notify += service.SendSMS;

            Notify("Hello from multicast Delegate");


            
        }
    }
}

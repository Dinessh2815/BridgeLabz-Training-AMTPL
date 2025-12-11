using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleProject.Delegates
{
    internal class SingleDelegatesEmaple
    {
        public delegate void Notifier(string message);

        public class NotificationService
        {
            public void SendEmail(string message)
            {
                Console.WriteLine("Email sent: " + message);
            }
            public void SendSms(string message)
            {
                Console.WriteLine("SMS sent: " + message);
            }
            public void Process(Notifier CallBack)
            {
                Console.WriteLine("Processed");
            }

            
        }
        public static void Main(string[] args)
        {
            // Single Cast Direct delegate

            NotificationService service = new NotificationService();
            Notifier Notify = service.SendEmail;
            Notify += service.SendSms;
            Notify("Hello from direct delegate");

            // Single Cast Ananymous Delegate

            Notifier AnanymousNotify = delegate (string message)
            {
                Console.WriteLine("Anonymous Delegate says: " + message);
            };

            AnanymousNotify("Hello from ananymous delegate");

            // Single Cast Lambda Delegate

            Notifier LambdaNotify = msg => Console.WriteLine("Lambda Delegate :" + msg);
            LambdaNotify("hi from Lambda delegate");

            // Single Cast Lambda Delegate using .Invoke()

            Notifier InvokeNotify = msg => Console.WriteLine("Invoke Delegate :" + msg);
            InvokeNotify.Invoke("hi using Invoke");
        }
    }
}

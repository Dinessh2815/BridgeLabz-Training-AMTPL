using System;

namespace ConsoleProject.Events
{

    public delegate void Notify();

    class Payment
    {
        public event Notify OnPaymentDone;

        public void Pay()
        {
            Console.WriteLine("Processing payment...");
            OnPaymentDone?.Invoke();
        }
    }

    class User
    {
        public void SendEmail()
        {
            Console.WriteLine("Email sent to user.");
        }

        public void SendSMS()
        {
            Console.WriteLine("SMS sent to user.");
        }
    }

    class Program
    {
        static void Main()
        {
            Payment payment = new Payment();
            User user = new User();

            payment.OnPaymentDone += user.SendEmail;
            payment.OnPaymentDone += user.SendSMS;

            payment.Pay();
        }
    }
}

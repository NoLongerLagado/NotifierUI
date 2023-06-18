using NotificationInterface.BLL;
using System;

namespace InterfaceNotification
{


    public class Program
    {
        private static NotificationManagement _notificationManagement;

        static void Main()
        {
            _notificationManagement = new NotificationManagement();

            Console.WriteLine("Notification System!");

            while (true)
            {
                Console.WriteLine("Enter sender name:");
                string senderName = Console.ReadLine();

                Console.WriteLine("Enter receiver name:");
                string receiverName = Console.ReadLine();

                Console.WriteLine("Enter notification content:");
                string content = Console.ReadLine();

                _notificationManagement.SendNotification(senderName, receiverName, content);

                Console.WriteLine("Notification sent successfully!");
                Console.WriteLine("Press Enter to send another notification or press any other key to exit.");

                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;

                Console.WriteLine();
            }
        }
    }

}
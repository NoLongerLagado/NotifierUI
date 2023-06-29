using NotificationInterface.BLL;
using System;

namespace InterfaceNotification
{


    public class Program
    {
        private static NotificationManagement _notificationManagement;
      static void 

        static void Main()
        {
            _notificationManagement = new NotificationManagement();

            Console.WriteLine("Notification System!");

            while (true)
            {

                if (NotificationManagement.NotificationMarketPlace(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now();}";
                    Console.WriteLine(receiverName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();

                }
                else if (NotificationManagement.ReactPost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}";
                    Console.WriteLine(senderName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiver);
                }
                else if (NotificationManagement.NewPost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}";
                    Console.WriteLine(sender);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiver);
                }
                else if (NotificationManagement.SharePost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}";
                    Console.WriteLine(sender);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiver);
                }
                else if (NotificationManagement.Attendance(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}";
                    Console.WriteLine(sender);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiver);
                }




                /*Console.WriteLine("Enter sender name:");
                string senderName = Console.ReadLine();

                Console.WriteLine("Enter receiver name:");
                string receiverName = Console.ReadLine();

                Console.WriteLine("Enter notification content:");
                string content = Console.ReadLine();*/

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
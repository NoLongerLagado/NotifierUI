using Notif_BLL;
using Notif_DLL;
using Notif_Models;
using System;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NotificationInterface
{
    internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Send the Notification ");

                NotificationManagement notificationManagement = new NotificationManagement();
                InMemoryNotifData inMemoryNotifData = new InMemoryNotifData();

            // Create a notification survey
            //Console.WriteLine($"Date : {DateTime.Now}");
            //Console.Write("Enter sender name: ");
                        Console.Write("Enter student ID: ");
                        string studentId = Console.ReadLine();

                        Console.Write("Enter sender name: ");
                        string senderName = Console.ReadLine();

                        Console.Write("Enter receiver name: ");
                        string receiverName = Console.ReadLine();

                        Console.Write("Enter notification content: ");
                        string content = Console.ReadLine();

               

                notificationManagement.SendNotification(studentId ,senderName, receiverName, content);

                // Connect to database and save notifications
                SqlNotif sqlNotif = new SqlNotif();

                var notification = new Notification
                {
                    StudentID = studentId,
                    senderName = new User { Name = senderName },
                    receiverName = new User { Name = receiverName },
                    Content = content,
                    DateModified = DateTime.Now,
                    IsRead = false
                };
                sqlNotif.StoreNotifications(notification);

                // Display saved notifications
                Console.WriteLine("\nNotification saved successfully!\n");

                Console.WriteLine("List of notifications:");
                foreach (var savedNotification in sqlNotif.GetSaveNotifications())
                {
                    Console.WriteLine($"Student ID: {savedNotification.StudentID}");
                    Console.WriteLine($"Sender Name: {savedNotification.senderName.Name}");
                    Console.WriteLine($"Receiver Name: {savedNotification.receiverName.Name}");
                    Console.WriteLine($"Content: {savedNotification.Content}");
                    Console.WriteLine($"Date and Time: {savedNotification.DateModified}");
                    Console.WriteLine($"Is Read: {savedNotification.IsRead}");
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
   







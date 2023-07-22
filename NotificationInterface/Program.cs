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
                Console.WriteLine("Welcome to the Notification Survey App!");

                NotificationManagement notificationManagement = new NotificationManagement();
                InMemoryNotifData inMemoryNotifData = new InMemoryNotifData();

            // Create a notification survey
            Console.WriteLine($"Date : {DateTime.Now}");
            Console.Write("Enter sender name: ");
                string senderName = Console.ReadLine();

                Console.Write("Enter receiver name: ");
                string receiverName = Console.ReadLine();

                Console.Write("Enter notification content: ");
                string content = Console.ReadLine();

                Console.Write("Enter student ID: ");
                string studentId = Console.ReadLine();

                notificationManagement.SendNotification(senderName, receiverName, content, studentId);

                // Connect to database and save notifications
                SqlNotif sqlNotif = new SqlNotif();
                var notification = new Notification
                {
                    StudentID = studentId,
                    senderName = new User { Name = senderName },
                    receiverName = new User { Name = receiverName },
                    Content = content,
                    DateTime = DateTime.Now,
                    IsRead = false
                };
                sqlNotif.StoreNotifications(notification);

                // Display saved notifications
                Console.WriteLine("\nSurvey saved successfully!\n");

                Console.WriteLine("List of notifications:");
                foreach (var savedNotification in sqlNotif.GetSaveNotifications())
                {
                    Console.WriteLine($"Student ID: {savedNotification.StudentID}");
                    Console.WriteLine($"Sender Name: {savedNotification.senderName.Name}");
                    Console.WriteLine($"Receiver Name: {savedNotification.receiverName.Name}");
                    Console.WriteLine($"Content: {savedNotification.Content}");
                    Console.WriteLine($"Date and Time: {savedNotification.DateTime}");
                    Console.WriteLine($"Is Read: {savedNotification.IsRead}");
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
   






    //    static NotificationManagement notificationManager = new NotificationManagement();
    //    static InMemoryNotifData inMemoryNotifData = new InMemoryNotifData();

    //    static void Main(string[] args)
    //    {
    //        DisplayMenu();
    //    }

    //    static void DisplayMenu()
    //    {
    //        Console.WriteLine("Welcome to Notification Console App");
    //        Console.WriteLine("1. Send Notification");
    //        Console.WriteLine("2. View Notifications");
    //        Console.WriteLine("3. Exit");

    //        Console.Write("Enter your choice: ");
    //        string choice = Console.ReadLine();

    //        switch (choice)
    //        {
    //            case "1":
    //                SendNotification();
    //                break;
    //            case "2":
    //                ViewNotifications();
    //                break;
    //            case "3":
    //                Console.WriteLine("Goodbye!");
    //                return;
    //            default:
    //                Console.WriteLine("Invalid choice. Please try again.");
    //                break;
    //        }

    //        DisplayMenu();
    //    }

    //    static void SendNotification()
    //    {
    //        Console.WriteLine($"Date : {DateTime.Now}");
    //        Console.Write("Enter Student ID: ");
    //        string studentid = Console.ReadLine();

    //        Console.Write("Enter sender name: ");
    //        string senderName = Console.ReadLine();

    //        Console.Write("Enter receiver name: ");
    //        string receiverName = Console.ReadLine();

    //        Console.Write("Enter content: ");
    //        string content = Console.ReadLine();



    //        notificationManager.SendNotification(studentid ,senderName, receiverName, content );
    //        Console.WriteLine("Notification sent successfully!");
    //    }

    //    static void ViewNotifications()
    //    {
    //        Console.WriteLine("List of Notifications:");
    //        var notifications = inMemoryNotifData.GetNotifications();
    //        foreach (var notification in notifications)
    //        {
    //            Console.WriteLine($"Student ID: {notification.StudentID}");
    //            Console.WriteLine($"Sender Name: {notification.senderName.Name}");
    //            Console.WriteLine($"Receiver Name: {notification.receiverName.Name}");
    //            Console.WriteLine($"Content: {notification.Content}");
    //            Console.WriteLine($"DateTime: {notification.DateTime}");
    //            Console.WriteLine($"Is Read: {notification.IsRead}");
    //            Console.WriteLine("------------------------");
    //        }
    //    }
    //}



using Notif_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Notif_DLL
{
    public class InMemoryNotifData
    {
        public InMemoryNotifData() 
        { 
            CreateNotification();
        
        }
        private List<Notification> sendNotif = new List<Notification>();

    

        public void CreateNotificationPath(User sname, User rname, string cnt, string stuid)

        {

            sendNotif.Add(new Notification { 
                senderName = sname, 
                receiverName = rname,
                Content = cnt,
                DateModified = DateTime.Now,
                StudentID = stuid
            });

        }

        public void CreateNotification()
        {

            User senderUser = new User { Name = "Lagado" };
            User receiverUser = new User { Name = "Abuan" };
            string content = "umay par nagsisilos ako :<";
            string studentId = "2021001";
            CreateNotificationPath(senderUser, receiverUser, content, studentId);
        }





    }
}
           
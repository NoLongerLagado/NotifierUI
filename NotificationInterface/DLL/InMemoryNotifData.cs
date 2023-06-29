using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationInterface.DLL
{
    internal class InMemoryNotifData
    {
        public class UserRepository
        {
            private List<User> _users;

            public UserRepository()
            {
                _users = new List<User>
        {
            /*new User { Id = 1, Name = " laurence" },
            new User { Id = 2, Name = "Nelson" },
            new User { Id = 3, Name = "Mika" },*/
        };
            }

            public User GetUserByName(string name)
            {
#pragma warning disable CS8603 
                return _users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
#pragma warning restore CS8603 
            }
        }

        public class NotificationRepository
        {
          
            private List<Notification> _notifications;

            public NotificationRepository()
            {
                _notifications = new List<Notification>();
            }

            public void SaveNotification(Notification notification)
            {
                _notifications.Add(notification);
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Notification
        {
            public int StudentId { get; set; }
            public User senderName { get; set; }
            public User receiverName { get; set; }
            public string Content { get; set; }
            public DateTime TimeCode { get; set; }
            public bool IsRead { get; set; }
        }
    }
}

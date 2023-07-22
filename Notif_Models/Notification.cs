using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notif_Models
{
    public class Notification
    {
        public string StudentID { get; set; }
        public User senderName { get; set; }
        public User receiverName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }

        public Notification()
        {
            StudentID = string.Empty;
            senderName = new User();
            receiverName = new User();
            Content = string.Empty;
            DateTime = DateTime.Now;
        }

        public List<Notification> sendNotif = new List<Notification>();
    }
}
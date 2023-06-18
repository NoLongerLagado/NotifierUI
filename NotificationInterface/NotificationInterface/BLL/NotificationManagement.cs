using static NotificationInterface.DLL.InMemoryNotifData;

namespace NotificationInterface.BLL
{
    public class NotificationManagement
    {
        private readonly UserRepository _userRepository;
        private readonly NotificationRepository _notificationRepository;

        public NotificationManagement()
        {
            _userRepository = new UserRepository(); 
            _notificationRepository = new NotificationRepository(); 
        }

        public void SendNotification(string senderName, string receiverName, string content)
        {
            
            var sender = _userRepository.GetUserByName(senderName);
            var receiver = _userRepository.GetUserByName(receiverName);

            if (sender != null && receiver != null)
            {
                var notification = new Notification
                {
                    senderName = sender,
                    receiverName = receiver,
                    Content = content,
                    TimeCode = DateTime.Now,
                    IsRead = false
                };

                
                _notificationRepository.SaveNotification(notification);

                
            }
            else
            {
                // Handle the case when the sender or receiver is not found
                
            }
        }
    }


}
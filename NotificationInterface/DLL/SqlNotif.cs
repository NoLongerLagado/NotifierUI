using NotificationInterface;
using System;
using System.Data.SqlClient;
using static NotificationInterface.DLL.InMemoryNotifData;

namespace NotificationInterface.DLL
{
    public class SqlNotif
    {
        private readonly string _connectionString;

        public SqlNotif(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object SqlNotificationType { get; private set; }

        public void ConnectAndListenForChanges()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT StudentId, SenderName, ReceiverName, Content, TimeCode, IsRead FROM Notifications", connection);

            var dependency = new SqlDependency(command);
            /*dependency.OnChange += Dependency_OnChange;*/

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var notification = new Notification
                    {
                        StudentId = reader.GetInt32(0),
                        senderName = UserRepository.GetUserByName(reader.GetString(1)),
                        receiverName = UserRepository.GetUserByName(reader.GetString(2)),
                        Content = reader.GetString(3),
                        TimeCode = reader.GetDateTime(4),
                        IsRead = reader.GetBoolean(5)
                    };

                   
                }
            }
        }

        /*private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                // Handle the change event
            }

            var dependency = (SqlDependency)sender;
            dependency.OnChange -= Dependency_OnChange;
            dependency.OnChange += Dependency_OnChange;

            ConnectAndListenForChanges();
        }*/
    }
}
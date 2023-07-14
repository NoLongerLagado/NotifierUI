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

        public object SqlNotificationType { get; private set;}

        




        public void ConnectAndListenForChanges()
        {

            UserRepository userRepository = new UserRepository();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT TOP (1000) [StudentId] ,[senderName] ,[receiverName] ,[Content] ,[DateTime] ,[IsRead] FROM [notifdatabase].[dbo].[tblNotification]", connection);

            var dependency = new SqlDependency(command);
            /*dependency.OnChange += Dependency_OnChange;*/

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var notification = new Notification
                    {
                        StudentId = reader.GetInt32(0),
                        senderName = userRepository.GetUserByName(reader.GetString(1)),
                        receiverName = userRepository.GetUserByName(reader.GetString(2)),
                        Content = reader.GetString(3),
                        DateTime = reader.GetDateTime(4),
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
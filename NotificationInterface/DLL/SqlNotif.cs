using NotificationInterface;
using InMemoryNotifData;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace NotificationInterface.DLL
{
    public class SqlNotif
    {
        static string _connectionString;

        _connectionString = "Data Source = localhost; Initial Catalog = notifdatabase; Integrated Security = True;";

        public SqlNotif(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ConnectAndListenForChanges()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Notifications", connection);
                var dependency = new SqlDependency(command);
                dependency.OnChange += Dependency_OnChange;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var notification = new Notification
                        {
                            StudentId = (int)reader["StudentId"],
                            senderName = UserRepository.GetUserByName(reader["SenderName"].ToString()),
                            receiverName = UserRepository.GetUserByName(reader["ReceiverName"].ToString()),
                            Content = reader["Content"].ToString(),
                            TimeCode = (DateTime)reader["TimeCode"],
                            IsRead = (bool)reader["IsRead"]
                        };

                    }
                }
            }
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
            }

            var dependency = (SqlDependency)sender;
            dependency.OnChange -= Dependency_OnChange;
            dependency.OnChange += Dependency_OnChange;

            ConnectAndListenForChanges();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Users
{
    class MSSQLUserDAO : IUserDAO
    {
        private static string connectionString = App.ConnectionString;
        private SqlCommand command;
        private SqlConnection connection;
        private SqlDataReader dataReader;

        public User GetUserById(int id)
        {
            string query = "SELECT * FROM SWZ.dbo.uzytkownicy WHERE id=@1";
            User user = null;
            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@1", id);
                connection.Open();
                dataReader = command.ExecuteReader();
                user = new User();
                
                while(dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                        user.Id = dataReader.GetInt32(0);
                    if (!dataReader.IsDBNull(1))
                        user.FirstName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        user.LastName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        user.Login = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        user.Password = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                        user.FieldOfStudy = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6))
                        user.FacultySymbol = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7))
                        user.Type = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8))
                        user.IndexNumber = dataReader.GetInt32(8);


                }

               
            }
            return user;
        }

        public int SaveUser(User user)
        {   

            throw new NotImplementedException();
        }
    }
}

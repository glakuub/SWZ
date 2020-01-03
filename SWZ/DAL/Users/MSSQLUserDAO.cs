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
        static string connectionString = @"Server=jakubgladysz.com;Database=SWZ;User Id=sa;Password=Geforce9600gt!;";
        SqlCommand command;
        SqlConnection connection;
        SqlDataReader dataReader;

        public User getUser(int id)
        {
            throw new NotImplementedException();
        }

        public int insertUser(User user)
        {   

            throw new NotImplementedException();
        }
    }
}

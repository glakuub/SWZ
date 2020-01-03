using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    class MSSQLReplacementDAO : IReplacementDAO
    {   
        static string connectionString = @"Server=jakubgladysz.com;Database=SWZ;User Id=sa;Password=Geforce9600gt!;";
        SqlCommand command;
        SqlConnection connection;
        SqlDataReader dataReader;

        public List<Replacement> GetReplacements()
        {
            List<Replacement> replacements = new List<Replacement>();
            string query = "SELECT * FROM SWZ.dbo.zamienniki";
            

            connection = new SqlConnection(connectionString);
            command = new SqlCommand(query, connection);

            connection.Open();
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                Replacement replacement= new Replacement();
                replacement.replacedID = dataReader.GetInt32(0);
                replacement.replacementID = dataReader.GetInt32(1);
                replacements.Add(replacement);
            }
            dataReader.Close();
            command.Dispose();
            connection.Close();

            return replacements;
        }

        public void SaveReplacement(Replacement replacement)
        {
            throw new NotImplementedException();
        }
    }
}

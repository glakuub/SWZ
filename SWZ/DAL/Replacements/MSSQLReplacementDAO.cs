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

        public List<Replacement> FindByReplacedId(int id)
        {
            string query = $"SELECT * FROM SWZ.dbo.zamienniki WHERE zamienianyid={id}";
            List<Replacement> replacements = new List<Replacement>();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand(query, connection);

            connection.Open();
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0) && !dataReader.IsDBNull(1))
                {
                   replacements.Add(new Replacement(dataReader.GetInt32(0), dataReader.GetInt32(1)));
                    
                }
            }
            dataReader.Close();
            command.Dispose();
            connection.Close();


            return replacements;
        }

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
                if (!dataReader.IsDBNull(0) && !dataReader.IsDBNull(1))
                {
                    Replacement replacement = new Replacement(dataReader.GetInt32(0), dataReader.GetInt32(1));
                    replacements.Add(replacement);
                }
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

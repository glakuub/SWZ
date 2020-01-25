using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    public class MSSQLReplacementDAO : IReplacementDAO
    {
        private static readonly string connectionString = App.ConnectionString;
        private SqlConnection connection;
        private SqlDataReader dataReader;
        private SqlCommand command;

        public List<Replacement> FindByReplacedId(int id)
        {
            string query = $"SELECT * FROM SWZ.dbo.zamienniki WHERE zamienianyid={id}";
            List<Replacement> replacements = new List<Replacement>();

            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(0) && !dataReader.IsDBNull(1))
                        {
                            replacements.Add(new Replacement(dataReader.GetInt32(0), dataReader.GetInt32(1)));

                        }
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new NoDatasourceConnectionException();
                }
            }

            return replacements;
        }

        public List<Replacement> GetReplacements()
        {
            List<Replacement> replacements = new List<Replacement>();
            string query = "SELECT * FROM SWZ.dbo.zamienniki";


            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
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
                }
                catch(Exception e)
                {
                    Debug.Write(e.Message);
                    throw new NoDatasourceConnectionException();
                }
            }
            return replacements;
        }

        public void SaveReplacement(Replacement replacement)
        {
            throw new NotImplementedException();
        }
    }
}

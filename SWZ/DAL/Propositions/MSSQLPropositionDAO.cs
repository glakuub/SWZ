using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Propositions
{
    class MSSQLPropositionDAO : IPropositionDAO
    {
        static string connectionString = App.ConnectionString;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlConnection connection;

        public void addProposition(Proposition proposition)
        {
            throw new NotImplementedException();
        }

        public List<Proposition> GetPropositions()
        {
            List<Proposition> propositions = new List<Proposition>();

            string query = "SELECT * FROM SWZ.dbo.propozycje";


            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        Proposition proposition = new Proposition(dataReader.GetInt32(0));
                        proposition.proposing = dataReader.GetInt32(1);
                        proposition.authorizing = dataReader.GetInt32(2);
                        if (!dataReader.IsDBNull(3)) proposition.dateOfSubmission = dataReader.GetDateTime(3);
                        proposition.replacementFor = dataReader.GetInt32(4);
                        propositions.Add(proposition);
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new NoDatasourceConnectionException();
                }
               
            }
            return propositions;
        }
             
       
        public int SaveProposition(Proposition proposition)
        {
            int insertedId = -1;
            string query = $"INSERT INTO SWZ.dbo.propozycje (skladajacy, datazlozenia, zamieniany)" +
                $" OUTPUT Inserted.ID" +
                $" VALUES (1,@1,{proposition.replacementFor});";

            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@1", proposition.dateOfSubmission);

                connection.Open();
                insertedId = (int)command.ExecuteScalar();
                
            }

            return insertedId;
        }
    }
}

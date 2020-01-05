using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyPlans
{
    class MSSQLStudyPlansDAO : IStudyPlansDAO
    {
        static string connectionString = @"Server=jakubgladysz.com;Database=SWZ;User Id=sa;Password=Geforce9600gt!;";
        SqlCommand command;
        SqlDataReader dataReader;
        SqlConnection connection;
         
        public StudyPlan GetStudyPlan(int id)
        {
            
            string query = $"SELECT * FROM SWZ.dbo.planystudiow WHERE id={id}";

            connection = new SqlConnection(connectionString);
            command = new SqlCommand(query, connection);
            StudyPlan studyPlan = null;
            connection.Open();
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                studyPlan = new StudyPlan(dataReader.GetInt32(0));
                studyPlan.facultySymbol = dataReader.GetString(1);
                studyPlan.fieldOfStudy = dataReader.GetString(2);
                studyPlan.degreeOfStudy = dataReader.GetInt32(3);
                studyPlan.language = dataReader.GetInt32(4);
                studyPlan.typeOfStudies = dataReader.GetInt32(5);

            }
            dataReader.Close();
            command.Dispose();
            connection.Close();

            return studyPlan;
        }

        public List<StudyPlan> GetStudyPlans()
        {
            throw new NotImplementedException();
        }

        public void SaveStudyPlan(StudyPlan studyPlan)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.PropositionsCourses
{
    class MSSQLPropositionsCoursesDAO : IPropositionsCoursesDAO
    {
        SqlCommand command;
        SqlConnection connection;
        SqlDataReader dataReader;
        public List<PropositionCourse> GetPropositionCourses()
        {
            throw new NotImplementedException();
        }

        public void SavePropositionCourse(PropositionCourse propositionCourse)
        {
            string query = "INSERT INTO SWZ.dbo.propozycje_kursy VALUES (@1,@2)";
            using (connection = new SqlConnection(App.ConnectionString))
            {
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@1", propositionCourse.PropositionID);
                command.Parameters.AddWithValue("@2", propositionCourse.CourseID);

                connection.Open();
                command.ExecuteNonQuery();

            }

        }
    }
}

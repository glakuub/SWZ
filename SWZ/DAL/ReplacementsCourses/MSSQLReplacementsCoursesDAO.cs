using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.ReplacementsCourses
{
    class MSSQLReplacementsCoursesDAO : IReplacementsCoursesDAO
    {
        private static readonly string connectionString = App.ConnectionString;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private SqlConnection connection;

        public List<ReplacementCourse> FindByReplacementId(int id)
        {
            string query = $"SELECT * FROM SWZ.dbo.zamienniki_kursy WHERE zamiennikid={id}";
            List<ReplacementCourse> replacements_courses = new List<ReplacementCourse>();

            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        ReplacementCourse replacementCourse = new ReplacementCourse(dataReader.GetInt32(0), dataReader.GetInt32(1));
                        replacements_courses.Add(replacementCourse);

                    }
                }catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new NoDatasourceConnectionException();
                }
            }

            return replacements_courses;
        }

        public List<ReplacementCourse> GetReplacementCourses()
        {
            throw new NotImplementedException();
        }

        public void SaveReplacementCourse(ReplacementCourse replacementCourse)
        {

            
            string query = $"INSERT INTO SWZ.dbo.propozycje_kursy " +
                $"(propozycjaid, zamiennikid) VALUES ({replacementCourse.replacementID},{replacementCourse.courseID});";

            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new NoDatasourceConnectionException();
                }
                                              
            }

            
        }
    }
}

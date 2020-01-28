using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    public class MSSQLCourseDAO : ICourseDAO
    {
        static string connectionString = App.ConnectionString;
       
        SqlCommand command;
        SqlDataReader dataReader;
        SqlConnection connection;

        public Course FindCourseById(int id)
        {   

         

            return _getCourses($"WHERE id={id};")[0];
        }

        public List<Course> FindCoursesInGroup(int id)
        {
            return _getCourses($"WHERE GrupaKursówID={id};");
        }


        public List<Course> GetCourses()
        {
            return _getCourses();
        }

        private List<Course> _getCourses(string where=null) 
        {
                List<Course> courses = new List<Course>();
                string query = where == null ? "SELECT * FROM SWZ.dbo.kursy" : $"SELECT * FROM SWZ.dbo.kursy {where}";



            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        Course course = new Course();
                        if (!dataReader.IsDBNull(0))
                            course.Id = dataReader.GetInt32(0);
                        if (!dataReader.IsDBNull(1))
                            course.CourseCode = Regex.Replace(dataReader.GetString(1), @"\s+", "");
                        if (!dataReader.IsDBNull(2))
                            course.CourseName = dataReader.GetString(2);
                        if (!dataReader.IsDBNull(3))
                            course.Ects = dataReader.GetInt32(3);
                        if (!dataReader.IsDBNull(4))
                            course.CourseType = dataReader.GetInt32(4);
                        if (!dataReader.IsDBNull(5))
                            course.Zzu = dataReader.GetInt32(5);
                        if (!dataReader.IsDBNull(6))
                            course.SemesterNumber = dataReader.GetInt32(6);
                        if (!dataReader.IsDBNull(7))
                            course.StudyPlanID = dataReader.GetInt32(7);
                        if (!dataReader.IsDBNull(8))
                            course.CoursesGroupID = dataReader.GetInt32(8);
                        if (!dataReader.IsDBNull(9))
                            course.IsCoursesGroup = dataReader.GetBoolean(9);
                        courses.Add(course);

                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw new NoDatasourceConnectionException();
                }
                
            }
                return courses;
            
        }
    }
}

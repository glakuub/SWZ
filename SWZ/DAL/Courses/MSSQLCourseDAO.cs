using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    class MSSQLCourseDAO : ICourseDAO
    {
        SqlCommand command;
        SqlDataReader dataReader;
        SqlConnection connection;

        public List<Course> GetCourses()
        {
           

                List<Course> courses = new List<Course>();

                string query = "SELECT * FROM SWZ.dbo.kursy";
                string connectionString = @"Server=jakubgladysz.com;Database=SWZ;User Id=sa;Password=Geforce9600gt!;";
                string result = "";

                connection = new SqlConnection(connectionString);
                command = new SqlCommand(query, connection);

                connection.Open();
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Course course = new Course(dataReader.GetInt32(0));
                    course.courseCode = dataReader.GetString(1);
                    course.courseName = dataReader.GetString(2);
                    course.ects = dataReader.GetInt32(3);
                    course.courseType = dataReader.GetInt32(4);
                    course.zzu = dataReader.GetInt32(5);
                    course.semesterNumber = dataReader.GetInt32(6);
                    course.studyPlanID = dataReader.GetInt32(7);
                    if (!dataReader.IsDBNull(8))
                    course.coursesGroupID = dataReader.GetInt32(8);
                   
                    course.isCoursesGroup = dataReader.GetBoolean(9);
                    courses.Add(course);

                }
                dataReader.Close();
                command.Dispose();
                connection.Close();

                return courses;
            
        }
    }
}

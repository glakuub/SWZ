using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL;
using SWZ.DAL.Courses;
using SWZ.DAL.StudyPlans;

namespace SWZ.Models
{
    class CoursesModel
    {
        public List<CourseModel> CourseModelsList { set; get; }
        
        public CoursesModel()
        {
            
        }
        public CourseModel GetCourseByID(int id)
        {
            RefreshCoursesFromData();
            return CourseModelsList.Find(cm => cm.Id == id);
        }
       
        public void RefreshCoursesFromData()
        {
            if (CourseModelsList == null)
            {
                CourseModelsList = new List<CourseModel>();

            }
            ICourseDAO courseDAO = new MSSQLCourseDAO();
            List<Course> coursesList = null;
            try
            {
               coursesList = courseDAO.GetCourses();
                CourseModelsList.Clear();
                foreach (Course c in coursesList)
                {
                    var model = Mapper.FromDTO(c);
                    if (model != null)
                        CourseModelsList.Add(model);
                }
            }
            catch(NoDatasourceConnectionException e)
            {
                Debug.WriteLine(e.Message);
                throw new DataServiceException("Could not refresh CoursesModel");
            }

           

        }

        


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    public class CoursesGroupModel : CourseModel
    {
        private List<CourseModel> _courses;
        public void AddCourse(CourseModel course)
        {
            if (_courses == null) _courses = new List<CourseModel>();
            _courses.Add(course);

        }
        public CourseModel GetCourseAt(int index)
        {
            return _courses.ElementAt(index);
        }
        public int GetCoursesCount()
        {
            return _courses.Count();
        }

        public List<CourseModel> GetCourses()
        {
            return  _courses;
        }
    }
}

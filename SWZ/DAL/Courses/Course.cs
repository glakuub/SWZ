using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    class Course
    {
        public int Id { set; get; }
        public string CourseCode { set; get; }
        public string CourseName { set; get; }
        public int Ects { set; get; }
        public int CourseType { set; get; }
        public int Zzu { set; get; }
        public int SemesterNumber { set; get; }
        public int StudyPlanID { set; get; }
        public int? CoursesGroupID { set; get; }
        public bool IsCoursesGroup { set; get; }


        public Course()
        {
            
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Id.ToString());
            result.Append("|");
            result.Append(CourseCode.ToString());
            result.Append("|");
            result.Append(CourseName.ToString());
            result.Append("|");
            result.Append(Ects.ToString());
            result.Append("|");
            result.Append(CourseType.ToString());
            result.Append("|");
            result.Append(Zzu.ToString());
            result.Append("|");
            result.Append(SemesterNumber.ToString());
            result.Append("|");
            result.Append(StudyPlanID.ToString());
            result.Append("|");
            result.Append(CoursesGroupID.ToString());
            result.Append("|");
            result.Append(IsCoursesGroup.ToString());
            return result.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    class Course
    {
        public int id { set; get; }
        public string courseCode { set; get; }
        public string courseName { set; get; }
        public int ects { set; get; }
        public int courseType { set; get; }
        public int zzu { set; get; }
        public int semesterNumber { set; get; }
        public int studyPlanID { set; get; }
        public int? coursesGroupID { set; get; }
        public bool isCoursesGroup { set; get; }


        public Course(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(id.ToString());
            result.Append("|");
            result.Append(courseCode.ToString());
            result.Append("|");
            result.Append(courseName.ToString());
            result.Append("|");
            result.Append(ects.ToString());
            result.Append("|");
            result.Append(courseType.ToString());
            result.Append("|");
            result.Append(zzu.ToString());
            result.Append("|");
            result.Append(semesterNumber.ToString());
            result.Append("|");
            result.Append(studyPlanID.ToString());
            result.Append("|");
            result.Append(coursesGroupID.ToString());
            result.Append("|");
            result.Append(isCoursesGroup.ToString());
            return result.ToString();
        }
    }
}

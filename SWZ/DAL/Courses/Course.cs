using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    class Course
    {
        int id;
        public string courseCode;
        public string courseName;
        public int ects;
        public int courseType;
        public int zzu;
        public int semesterNumber;
        public int studyPlanID;
        public int? coursesGroupID;
        public bool isCoursesGroup;


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

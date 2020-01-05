using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{   
    public enum CourseType { wykład = 1, ćwiczenia = 2, laboratorium = 3, projekt = 4}
    enum SemesterType { letni, zimowy}
    class CourseModel
    {
        int id;
        public string code;
        public string name;
        public int ects;
        public int zzu;
        public int semesterNumber;
        public SemesterType semesterType;
        public CourseType courseType;
        public StudyPlanModel studyPlan;
       

    }
}

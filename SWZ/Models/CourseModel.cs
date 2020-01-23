using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{   
    public enum CourseType { wykład = 1, ćwiczenia = 2, laboratorium = 3, projekt = 4, grupa = 5}
    public enum SemesterType { letni, zimowy}
    public class CourseModel
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int Ects { set; get; }
        public int Zzu { set; get; }
        public int SemesterNumber { set; get; }
        public SemesterType SemesterType { set; get; }
        public CourseType CourseType { set; get; }
        public StudyPlanModel StudyPlan { set; get; }

        public CourseModel() { }
        public CourseModel(int id)
        {
            this.Id = id;
        }

            
    }
}

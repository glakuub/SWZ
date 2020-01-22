using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.StudyPlans;

namespace SWZ.Models
{   
    public enum Language { polski = 1, angielski = 2};
    public enum StudyType { stacjonarne = 1, niestacjonarne = 2}
    public enum StudyDegree { pierwszy = 1, drugi = 2}

    public class StudyPlanModel
    {
        public int id;
        public string facultySymbol;
        public string fieldOfStudies;
        public StudyDegree studyDegree;
        public Language language;
        public StudyType studyType;
    }
}

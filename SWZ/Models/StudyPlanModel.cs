using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.StudyPlans;

namespace SWZ.Models
{   
    enum Language { polski = 1, angielski = 2};
    enum StudyType { stacjonarne = 1, niestacjonarne = 2}
    enum StudyDegree { pierwszy = 1, drugi = 2}
    class StudyPlanModel
    {
        public int id;
        public string facultySymbol;
        public string fieldOfStudies;
        public StudyDegree studyDegree;
        public Language language;
        public StudyType studyType;
    }
}

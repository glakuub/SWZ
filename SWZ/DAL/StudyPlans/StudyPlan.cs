using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyPlans
{
    class StudyPlan
    {
        public int id;
        public string facultySymbol;
        public string fieldOfStudy;
        public int degreeOfStudy;
        public int language;
        public int typeOfStudies;

        public StudyPlan(int id)
        {
            this.id = id;
        }
    }
}

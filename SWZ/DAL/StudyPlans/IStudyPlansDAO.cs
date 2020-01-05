using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyPlans
{
    interface IStudyPlansDAO
    {
        List<StudyPlan> GetStudyPlans();
        StudyPlan GetStudyPlan(int id);
        void SaveStudyPlan(StudyPlan studyPlan);
    }
}

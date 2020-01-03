using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.PropositionsCourses
{
    interface IPropositionsCoursesDAO
    {
        List<PropositionCourse> GetPropositionCourses();
        void SavePropositionCourse(PropositionCourse propositionCourse);
    }
}

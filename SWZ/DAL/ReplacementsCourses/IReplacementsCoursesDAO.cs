using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.ReplacementsCourses
{
    interface IReplacementsCoursesDAO
    {
        List<ReplacementCourse> GetReplacementCourses();
        List<ReplacementCourse> FindByReplacementId(int id);
        void SaveReplacementCourse(ReplacementCourse replacementCourse);
    }
}

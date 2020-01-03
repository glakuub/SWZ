using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.ReplacementsCourses
{
    class ReplacementCourse
    {
        int replacementID;
        int courseID;

        public ReplacementCourse(int replacementID, int courseID)
        {
            this.replacementID = replacementID;
            this.courseID = courseID;
        }
    }
}

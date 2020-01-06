using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.ReplacementsCourses
{
    class ReplacementCourse
    {
        public int replacementID;
        public int courseID;

        public ReplacementCourse(int replacementID, int courseID)
        {
            this.replacementID = replacementID;
            this.courseID = courseID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.PropositionsCourses
{
    class PropositionCourse
    {
        public int PropositionID { private set; get; }
        public int CourseID { private set; get; }

        public PropositionCourse(int propositionID, int replacementID)
        {
            this.PropositionID = propositionID;
            this.CourseID = replacementID;
        }
    }
}

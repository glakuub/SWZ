using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.PropositionsCourses
{
    class PropositionCourse
    {
        int propositionID;
        int replacementID;

        public PropositionCourse(int propositionID, int replacementID)
        {
            this.propositionID = propositionID;
            this.replacementID = replacementID;
        }
    }
}

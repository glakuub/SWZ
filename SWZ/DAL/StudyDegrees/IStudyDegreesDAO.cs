using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyDegrees
{
    interface IStudyDegreesDAO
    {
        List<StudyDegree> GetStudyDegrees();
    }
}

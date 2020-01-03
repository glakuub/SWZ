using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.LearningEffectsCourses
{
    class LearningEffectCourse
    {
        int learningEffectID;
        int courseID;

        public LearningEffectCourse(int learningEffectID, int courseID)
        {
            this.learningEffectID = learningEffectID;
            this.courseID = courseID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.LearningEffects
{
    interface ILearningEffectsDAO
    {
        List<LearningEffect> GetLearningEffects();
    }
}

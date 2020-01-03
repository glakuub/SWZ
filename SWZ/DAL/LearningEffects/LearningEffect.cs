using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.LearningEffects
{
    class LearningEffect
    {
        int id;
        public string KEK;
        public string KEKDescription;
        public string PRK;

        public LearningEffect(int id)
        {
            this.id = id;
        }
    }
}

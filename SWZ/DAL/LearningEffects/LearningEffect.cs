using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.LearningEffects
{
    class LearningEffect
    {
        public int Id { set; get; }
        public string KEK { set; get; }
        public string KEKDescription { set; get; }
        public string PRK { set; get; }

        public LearningEffect()
        {
           
        }
    }
}

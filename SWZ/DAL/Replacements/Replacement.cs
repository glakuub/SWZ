using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    class Replacement
    {
        public int id;
        public int replacedID;

        public Replacement(int id, int replacedID)
        {
            this.id = id;
            this.replacedID = replacedID;
        }
        
    }
}

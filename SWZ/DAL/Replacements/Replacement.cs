using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    class Replacement
    {
        int id;
        int replacedID;

        public Replacement(int id, int replacedID)
        {
            this.id = id;
            this.replacedID = replacedID;
        }
        
    }
}

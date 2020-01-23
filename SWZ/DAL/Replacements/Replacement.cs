using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    public class Replacement
    {
        public int Id { get; }
        public int ReplacedID { get; }

        public Replacement(int id, int replacedID)
        {
            this.Id = id;
            this.ReplacedID = replacedID;
        }
        
    }
}

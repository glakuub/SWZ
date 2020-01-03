using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL
{
    class Proposition
    {
        int id;
        public int proposing;
        public int authorizing;
        public DateTime dateOfSubmission;
        public int replacementFor;

        public Proposition(int id)
        {
            this.id = id;
        }

    }
}

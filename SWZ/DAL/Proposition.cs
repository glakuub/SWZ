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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(id.ToString());
            result.Append("|");
            result.Append(proposing.ToString());
            result.Append("|");
            result.Append(authorizing.ToString());
            result.Append("|");
            result.Append(dateOfSubmission.ToString());
            result.Append("|");
            result.Append(replacementFor.ToString());
            return result.ToString();
        }

    }
}

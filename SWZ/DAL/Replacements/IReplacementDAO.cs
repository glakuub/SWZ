using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    interface IReplacementDAO
    {
        List<Replacement> GetReplacements();
        void SaveReplacement(Replacement replacement);

    }
}

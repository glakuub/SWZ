using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Replacements
{
    public interface IReplacementDAO
    {
        List<Replacement> GetReplacements();
        List<Replacement> FindByReplacedId(int id);
        void SaveReplacement(Replacement replacement);

    }
}

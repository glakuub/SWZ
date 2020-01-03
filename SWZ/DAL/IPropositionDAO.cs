using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL
{
    interface IPropositionDAO
    {
        List<Proposition> GetPropositions();
        void addProposition(Proposition proposition);

    }
}

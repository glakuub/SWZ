using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Propositions
{
    interface IPropositionDAO
    {
        List<Proposition> GetPropositions();
        int SaveProposition(Proposition proposition);
        

    }
}

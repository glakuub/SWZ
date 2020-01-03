using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyDegrees
{
    class StudyDegree
    {
        int id;
        string degree;

        public StudyDegree(int id, string degree)
        {
            this.id = id;
            this.degree = degree;
        }
    }
}

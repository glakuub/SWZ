using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.StudyTypes
{
    class StudyType
    {
        int id;
        string type;

        public StudyType(int id, string type)
        {
            this.id = id;
            this.type = type;
        }

    }
}

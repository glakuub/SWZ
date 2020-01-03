using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.CourseTypes
{
    class CourseType
    {
        int id;
        string type;

        public CourseType(int id, string type)
        {
            this.id = id;
            this.type = type;
        }
    }
}

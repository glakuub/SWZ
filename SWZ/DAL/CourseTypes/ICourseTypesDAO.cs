using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.CourseTypes
{
    interface ICourseTypesDAO
    {
        List<CourseType> GetCourseTypes();
    }
}

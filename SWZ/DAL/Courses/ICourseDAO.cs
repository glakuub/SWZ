﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    interface ICourseDAO
    {
        List<Course> GetCourses();
    }
}

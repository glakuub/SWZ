using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{   
    enum CourseType { wykład, ćwiczenia, laboratorium, projekt}
    enum SemesterType { letni, zimowy}
    class Course
    {
        int id;
        string code;
        string name;
        int ects;
        int zzu;
        int semesterNumber;
        SemesterType semesterType;
        CourseType courseType;


    }
}

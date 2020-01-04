using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{   
    enum Language { polski, angielski};
    enum StudyType { stacjonarne, niestacjonarne}
    enum StudyDegree { pierwszy, drugi}
    class StudyPlan
    {
        int id;
        string facultySymbol;
        string fieldOfStudies;
        StudyDegree studyDegree;
        Language language;
        StudyType studyType;
    }
}

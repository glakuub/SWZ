using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class PropositionModel
    {
        int id;
        DateTime dateOfSubmission;
        StudentModel proposing;
        AuthorizingEmployeeModel authorizing;
        CourseModel replacing;
        List<CourseModel> replacements;
    }
}

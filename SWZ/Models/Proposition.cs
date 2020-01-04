using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class Proposition
    {
        int id;
        DateTime dateOfSubmission;
        Student proposing;
        AuthorizingEmployee authorizing;
        Course replacing;
        List<Course> replacements;
    }
}

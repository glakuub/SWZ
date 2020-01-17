using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class PropositionModel
    {
        public int id { set; get; }
        public DateTime dateOfSubmission { set; get; }
        public StudentModel proposing { set; get; }
        public AuthorizingEmployeeModel authorizing { set; get; }
        public CourseModel replacing { set; get; }
        public List<CourseModel> replacements { set; get; }
    }
}

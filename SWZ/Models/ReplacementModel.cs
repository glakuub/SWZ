using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class ReplacementModel
    {

        public DateTime dateOfAuthorization;
        int id;
        public CourseModel replaced
        {
            get { return replaced; }
            set { replaced = value; }
        }
        List<CourseModel> replacements;
       
        public ReplacementModel() { }
        public ReplacementModel(int id)
        {
            this.id = id;
            replacements = new List<CourseModel>();
        }

        public void AddCourse(CourseModel course)
        {
            replacements.Add(course);
        }
        
    }
}

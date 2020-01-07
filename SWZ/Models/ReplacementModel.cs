using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class ReplacementModel
    {

        public DateTime DateOfAuthorization { get; set; }
        public CourseModel Replaced{get; set;}
        public List<CourseModel> Replacements { get; set; }
        int id;
        public ReplacementModel()
        {
            Replacements = new List<CourseModel>();
        }
        public ReplacementModel(int id)
        {
            this.id = id;
            Replacements = new List<CourseModel>();
        }

        public void AddCourse(CourseModel course)
        {
            Replacements.Add(course);
        }
        
    }
}

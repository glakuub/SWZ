using SWZ.DAL.Propositions;
using SWZ.DAL.PropositionsCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class PropositionModel
    {
        public int Id { set; get; }
        public DateTime DateOfSubmission { set; get; }
        public StudentModel Proposing { set; get; }
        public AuthorizingEmployeeModel Authorizing { set; get; }
        public CourseModel Replacing { set; get; }
        public List<CourseModel> Replacements { set; get; }

        public void Save()
        {
            IPropositionDAO pdao = new MSSQLPropositionDAO();
            Proposition prop = new Proposition();
            prop.dateOfSubmission = DateOfSubmission;
            prop.proposing = Proposing.Id;
            prop.replacementFor = Replacing.Id;

            int prop_id = pdao.SaveProposition(prop);

            IPropositionsCoursesDAO pcdao = new MSSQLPropositionsCoursesDAO();

             foreach(CourseModel cm in Replacements)
            {
                pcdao.SavePropositionCourse(new PropositionCourse(prop_id, cm.Id));
            }

        }
    }
}

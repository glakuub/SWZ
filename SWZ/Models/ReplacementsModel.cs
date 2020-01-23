using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.Replacements;
using SWZ.DAL.ReplacementsCourses;



namespace SWZ.Models
{
    class ReplacementsModel
    {
        CourseModel replacedModel;
        List<ReplacementModel> replacementModels;

        public ReplacementsModel()
        {
           replacementModels = new List<ReplacementModel>();
        }
        public void SetReplaced(CourseModel replacedModel)
        {
            this.replacedModel = replacedModel;
        }
        public List<ReplacementModel> GetReplacementsFromData()
        {
            List<ReplacementModel> rml = new List<ReplacementModel>();
            if (replacedModel != null)
            {
               
                IReplacementDAO replacementDAO = new MSSQLReplacementDAO();
                IReplacementsCoursesDAO replacementsCoursesDAO = new MSSQLReplacementsCoursesDAO();

                List<Replacement> replacements = replacementDAO.FindByReplacedId(replacedModel.Id);
                CoursesModel coursesModel = new CoursesModel();

                foreach (Replacement r in replacements)
                {
                    ReplacementModel replacementModel = new ReplacementModel();
                    replacementModel.Replaced = replacedModel;
                    List<ReplacementCourse> replacements_courses = replacementsCoursesDAO.FindByReplacementId(r.Id);
                    foreach (ReplacementCourse rc in replacements_courses)
                    {
                        replacementModel.AddCourse(coursesModel.GetCourseByID(rc.courseID));
                    }

                    rml.Add(replacementModel);


                }




            }

            return rml;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL;
using SWZ.DAL.Replacements;
using SWZ.DAL.ReplacementsCourses;



namespace SWZ.Models
{
    class ReplacementsModel
    {
        private CourseModel _replacedModel;
        private readonly List<ReplacementModel> _replacementModels;

        public ReplacementsModel()
        {
           _replacementModels = new List<ReplacementModel>();
        }
        public void SetReplaced(CourseModel replacedModel)
        {
            this._replacedModel = replacedModel;
        }
        public List<ReplacementModel> GetReplacementsFromData()
        {
            List<ReplacementModel> rml = new List<ReplacementModel>();
            if (_replacedModel != null)
            {
               
                IReplacementDAO replacementDAO = new MSSQLReplacementDAO();
                IReplacementsCoursesDAO replacementsCoursesDAO = new MSSQLReplacementsCoursesDAO();

                try
                {
                    List<Replacement> replacements = replacementDAO.FindByReplacedId(_replacedModel.Id);
                    CoursesModel coursesModel = new CoursesModel();

                    foreach (Replacement r in replacements)
                    {
                        ReplacementModel replacementModel = new ReplacementModel();
                        replacementModel.Replaced = _replacedModel;
                        List<ReplacementCourse> replacements_courses = replacementsCoursesDAO.FindByReplacementId(r.Id);
                        foreach (ReplacementCourse rc in replacements_courses)
                        {
                            replacementModel.AddCourse(coursesModel.GetCourseByID(rc.courseID));
                        }

                        rml.Add(replacementModel);


                    }

                }
                catch
                (NoDatasourceConnectionException e)
                {
                    Debug.WriteLine(e.Message);
                    throw new DataServiceException();
                }


            }

            return rml;
        }
    }
}

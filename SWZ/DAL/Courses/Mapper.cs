using SWZ.DAL.StudyPlans;
using SWZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL.Courses
{
    public class Mapper
    {   

        
        public static dynamic FromDTO(Course dto)
        {
            CourseModel model=null;
            ICourseDAO courseDAO = new MSSQLCourseDAO();
            IStudyPlansDAO studyPlansDAO = new MSSQLStudyPlansDAO();

            if (dto.IsCoursesGroup && dto.CoursesGroupID == null)
            {
                model = new CoursesGroupModel()
                {
                    Id = dto.Id,
                    Name = dto.CourseName,
                    Code = dto.CourseCode,
                    SemesterNumber = dto.SemesterNumber,
                    CourseType = (CourseType)dto.CourseType,
                    Ects = dto.Ects,
                    Zzu = dto.Zzu
                };

                List<Course> subdtos = courseDAO.FindCoursesInGroup(model.Id);
                foreach(Course c in subdtos)
                {
                    var submodel = new CourseModel()
                    {
                        Code = c.CourseCode,
                        CourseType = (CourseType)c.CourseType
                    };
                    (model as CoursesGroupModel).AddCourse(submodel);
                }


            }
            else if(!dto.IsCoursesGroup)
            {
                model = new CourseModel
                {
                    Id = dto.Id,
                    Name = dto.CourseName,
                    Code = dto.CourseCode,
                    SemesterNumber = dto.SemesterNumber,
                    CourseType = (CourseType)dto.CourseType,
                    Ects = dto.Ects,
                    Zzu = dto.Zzu
                };
            }

            if (model != null) {
                var studyPlan = studyPlansDAO.GetStudyPlan(dto.StudyPlanID);
                StudyPlanModel studyPlanModel = new StudyPlanModel();
                studyPlanModel.id = studyPlan.id;
                studyPlanModel.facultySymbol = studyPlan.facultySymbol;
                studyPlanModel.fieldOfStudies = studyPlan.fieldOfStudy;
                studyPlanModel.studyDegree = (StudyDegree)studyPlan.degreeOfStudy;
                studyPlanModel.language = (Language)studyPlan.language;
                studyPlanModel.studyType = (StudyType)studyPlan.typeOfStudies;
                model.StudyPlan = studyPlanModel;
            }

            return model;
        }
    }
}

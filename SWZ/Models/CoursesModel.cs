using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.Courses;
using SWZ.DAL.StudyPlans;

namespace SWZ.Models
{
    class CoursesModel
    {
        public List<CourseModel> courseModelsList;
        /*{
            get { return courseModelsList; }
            set { courseModelsList = value; }
        }*/
        public CoursesModel()
        {
            courseModelsList = new List<CourseModel>();
        }
        public void GetCourses()
        {
            ICourseDAO courseDAO = new MSSQLCourseDAO();
            IStudyPlansDAO studyPlansDAO = new MSSQLStudyPlansDAO();
            List<Course> coursesList = courseDAO.GetCourses();
            StudyPlan studyPlan = null;

            foreach(Course c in coursesList)
            {
                CourseModel cm = new CourseModel();
                cm.code = c.courseCode;
                cm.name = c.courseName;
                cm.semesterNumber = c.semesterNumber;
                cm.ects = c.ects;
                cm.zzu = c.zzu;
                cm.courseType = (CourseType)c.courseType;

                studyPlan = studyPlansDAO.GetStudyPlan(c.studyPlanID);
                StudyPlanModel studyPlanModel = new StudyPlanModel();
                studyPlanModel.id = studyPlan.id;
                studyPlanModel.facultySymbol = studyPlan.facultySymbol;
                studyPlanModel.fieldOfStudies = studyPlan.fieldOfStudy;
                studyPlanModel.studyDegree = (StudyDegree)studyPlan.degreeOfStudy;
                studyPlanModel.language = (Language)studyPlan.language;
                studyPlanModel.studyType = (StudyType)studyPlan.typeOfStudies;

                cm.studyPlan = studyPlanModel;
                courseModelsList.Add(cm);

                
            }
        }
    }
}

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
            
        }
        public CourseModel GetCourseByID(int id)
        {
            GetCoursesFromData();
            return courseModelsList.Find(cm => cm.id == id);
        }
        public CourseModel At(int index)
        {
            if (index >= 0 && index < courseModelsList.Count - 1)
                return courseModelsList[index];
            else
                return null;
        }
        public void GetCoursesFromData()
        {
            if (courseModelsList == null)
            {
                courseModelsList = new List<CourseModel>();

            }
            ICourseDAO courseDAO = new MSSQLCourseDAO();
            IStudyPlansDAO studyPlansDAO = new MSSQLStudyPlansDAO();
            List<Course> coursesList = courseDAO.GetCourses();
            StudyPlan studyPlan = null;

            foreach(Course c in coursesList)
            {
                CourseModel cm = new CourseModel(c.id);
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

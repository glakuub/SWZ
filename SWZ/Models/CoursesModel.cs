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
        public List<CourseModel> CourseModelsList { set; get; }
        
        public CoursesModel()
        {
            
        }
        public CourseModel GetCourseByID(int id)
        {
            GetCoursesFromData();
            return CourseModelsList.Find(cm => cm.Id == id);
        }
        public CourseModel At(int index)
        {
            if (index >= 0 && index < CourseModelsList.Count - 1)
                return CourseModelsList[index];
            else
                return null;
        }
        public void GetCoursesFromData()
        {
            if (CourseModelsList == null)
            {
                CourseModelsList = new List<CourseModel>();

            }
            ICourseDAO courseDAO = new MSSQLCourseDAO();
            List<Course> coursesList = courseDAO.GetCourses();
            CourseModelsList.Clear();
            foreach (Course c in coursesList)
            {
                var model = Mapper.FromDTO(c);
                if(model!=null)
                CourseModelsList.Add(model);
            }



            /*
            IStudyPlansDAO studyPlansDAO = new MSSQLStudyPlansDAO();
            List<Course> coursesList = courseDAO.GetCourses();
            StudyPlan studyPlan = null;

            courseModelsList.Clear();
            foreach(Course c in coursesList)
            {
                if (c.IsCoursesGroup && c.CoursesGroupID != null) continue;
                CourseModel cm = null;
                if (c.IsCoursesGroup && c.CoursesGroupID == null)
                {

                    cm = new CoursesGroupModel
                    {
                        Id = c.Id,
                        Code = c.CourseCode,
                        Name = c.CourseName,
                        SemesterNumber = c.SemesterNumber,
                        Ects = c.Ects,
                        Zzu = c.Zzu,
                        CourseType = (CourseType)c.CourseType
                    };

                    if (c.CoursesGroupID == null)
                    {
                        List<Course> subclist = courseDAO.FindCoursesInGroup(c.Id);

                        foreach (Course subc in subclist)
                        {
                            CourseModel subcm = new CourseModel();
                            subcm.CourseType = (CourseType)subc.CourseType;
                            (cm as CoursesGroupModel).AddCourse(subcm);
                        }

                    }


                }
                else if(!c.IsCoursesGroup)
                {
                    
                    cm = new CourseModel(c.Id);
                    cm.Code = c.CourseCode;
                    cm.Name = c.CourseName;
                    cm.SemesterNumber = c.SemesterNumber;
                    cm.Ects = c.Ects;
                    cm.Zzu = c.Zzu;
                    cm.CourseType = (CourseType)c.CourseType;

                    
                }

                studyPlan = studyPlansDAO.GetStudyPlan(c.StudyPlanID);
                StudyPlanModel studyPlanModel = new StudyPlanModel();
                studyPlanModel.id = studyPlan.id;
                studyPlanModel.facultySymbol = studyPlan.facultySymbol;
                studyPlanModel.fieldOfStudies = studyPlan.fieldOfStudy;
                studyPlanModel.studyDegree = (StudyDegree)studyPlan.degreeOfStudy;
                studyPlanModel.language = (Language)studyPlan.language;
                studyPlanModel.studyType = (StudyType)studyPlan.typeOfStudies;

                cm.StudyPlan = studyPlanModel;

                courseModelsList.Add(cm);

                
            }*/
        }

    }
}

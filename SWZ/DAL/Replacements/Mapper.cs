using SWZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.DAL.Courses;
using SWZ.DAL.ReplacementsCourses;

namespace SWZ.DAL.Replacements
{
    public class Mapper
    {
        static public ReplacementModel FromDTO(Replacement dto)
        {
            ReplacementModel model = null;
            if(dto!=null)
            {
                model = new ReplacementModel();
                var coursesDAO = new MSSQLCourseDAO();
                model.Replaced = Courses.Mapper.FromDTO(coursesDAO.FindCourseById(dto.ReplacedID));

                var replacementsCoursesDAO = new MSSQLReplacementsCoursesDAO();
                foreach(ReplacementCourse rc in replacementsCoursesDAO.FindByReplacementId(dto.Id))
                {
                    model.AddCourse(Courses.Mapper.FromDTO(coursesDAO.FindCourseById(rc.courseID)));
                }


            }
                      
            return model;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class CoursesGroupViewModel: CourseViewModel
    {
        public ObservableCollection<CourseViewModel> Courses;

        public CoursesGroupViewModel(CoursesGroupModel model):base(model as CourseModel)
        {
            Courses = new ObservableCollection<CourseViewModel>();
            for(int i=0;i<model.GetCoursesCount();i++)
            {
                Courses.Add(new CourseViewModel(model.GetCourseAt(i)));
            }
        }
    }
}

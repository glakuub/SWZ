using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SWZ.ViewModels
{
    class AddCourseToPropositionViewModel: FindCourseBaseViewModel
    {
        public ICommand AddCourse { set; get; }
        public ObservableCollection<CourseViewModel> AddedCourses { set; get; }

        public AddCourseToPropositionViewModel()
        {
            AddCourse = new CommandHandler(AddCourseMethod);
        }
        private void AddCourseMethod()
        {
            Debug.WriteLine("AddCourseMethod");
            if(Courses !=null && Courses.Count > 0)
            {   
                if(_selectedCourseIndex != -1 && Courses.Count > _selectedCourseIndex && Courses[_selectedCourseIndex] != null)
                AddedCourses.Add(Courses[_selectedCourseIndex]);

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }
        }
    }
}

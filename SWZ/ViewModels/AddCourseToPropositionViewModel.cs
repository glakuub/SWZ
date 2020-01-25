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
            if(DisplayedCourses !=null && DisplayedCourses.Count > 0)
            {   
                if(_selectedCourseIndex != -1 && DisplayedCourses.Count > _selectedCourseIndex && DisplayedCourses[_selectedCourseIndex] != null)
                AddedCourses.Add(DisplayedCourses[_selectedCourseIndex]);

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }
        }
    }
}

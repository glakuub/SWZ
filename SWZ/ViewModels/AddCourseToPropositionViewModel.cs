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

        private bool _canAdd = false;
        public bool CanAdd { set { SetProperty(ref _canAdd, value); } get { return _canAdd; } }
        public ObservableCollection<CourseViewModel> AddedCourses { set; get; }

        private new int _selectedCourseIndex = -1;
        public new int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }
            set
            {
                SetProperty(ref _selectedCourseIndex, value);
                CanAddCheck();

            }
        }

        public string LoggedUserName
        {
            get
            {
                return UserSession.Get.IsSet ? $"Zalogowano jako: { UserSession.Get.StudentFirstName} {UserSession.Get.StudentLastName}" : string.Empty;
            }
        }

        private Predicate<object> can = (can) => { return can == null ? true : (bool)can; };

        public AddCourseToPropositionViewModel()
        {
            AddCourse = new CommandHandler(AddCourseMethod, can);
            DisplayedCourses.CollectionChanged += (sender, args) => { CanAddCheck(); };
            CanAddCheck();
            
        }

       
        private void AddCourseMethod()
        {
            
            if(DisplayedCourses !=null && DisplayedCourses.Count > 0)
            {   
                if(_selectedCourseIndex != -1 && DisplayedCourses.Count > _selectedCourseIndex && DisplayedCourses[_selectedCourseIndex] != null)
                AddedCourses.Add(DisplayedCourses[_selectedCourseIndex]);

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }
        }
        private void CanAddCheck()
        {
            if (DisplayedCourses != null && DisplayedCourses.Count > 0 && _selectedCourseIndex != -1 && DisplayedCourses.Count > _selectedCourseIndex && DisplayedCourses[_selectedCourseIndex] != null)
            {
                CanAdd = true;
            }
            else
            {
                CanAdd = false;
            }
        }
    }
}

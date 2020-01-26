using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWZ.Models;
using SWZ.Views;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;

namespace SWZ.ViewModels
{
    class FindCourseBaseViewModel : NotificationBase
    {
        public CoursesModel CoursesModel { set; get; }

        public ObservableCollection<CourseViewModel> DisplayedCourses { set; get; }
        private List<CourseViewModel> courseViewModels;

        public ICommand GoBack { set; get; }

        public IEnumerable<CourseType> TypeEnumVals = Enum.GetValues(typeof(CourseType)).Cast<CourseType>();

        private Brush _formColor = new SolidColorBrush(Windows.UI.Colors.LightPink);
        public Brush FormColor { set { SetProperty(ref _formColor, value); } get { return _formColor; } } 


        public FindCourseBaseViewModel()
        {
            

            DisplayedCourses = new ObservableCollection<CourseViewModel>();
            courseViewModels = new List<CourseViewModel>();
            
            CoursesModel = new CoursesModel();
            GetDataAsync();

        }

        private async void GetDataAsync()
        {

            await Task.Run(async () =>
            {
                try
                {
                    CoursesModel.RefreshCoursesFromData();
                }
                catch (DataServiceException e)
                {
                    Debug.WriteLine(e.Message);
                    ShowAlert();
                    

                }
            });

            RefreshLocalCourses();



        }

        protected void ShowAlert()
        {
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { ShowAlertAsync(); });
        }

        private async void ShowAlertAsync()
        {
            var messageDialog = new NoDataserviceConnectionDialog();
            await messageDialog.ShowAsync();
        }

        private void CheckIfFilled()
        {
            if(IsAnyOfRequiredFilled())
                FormColor = new SolidColorBrush(Windows.UI.Colors.Gray);
            else
                FormColor = new SolidColorBrush(Windows.UI.Colors.LightPink);

        }

        private bool IsAnyOfRequiredFilled()
        {
            if (_searchName != null && !_searchName.Equals(string.Empty)) return true;
            if (_searchFaculty != null && !_searchFaculty.Equals(string.Empty)) return true;
            if (_searchCode != null && !_searchCode.Equals(string.Empty)) return true;
            if (_searchFieldOfStudy != null && !_searchFieldOfStudy.Equals(string.Empty)) return true;

            return false;
        }
        string _searchName = string.Empty;
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                SetProperty(ref _searchName, value);
                CheckIfFilled();
                FilterCourses();
            }
        }

        string _searchFaculty = string.Empty;
        public string SearchFaculty
        {
            get { return _searchFaculty; }
            set
            {
                SetProperty(ref _searchFaculty, value);
                CheckIfFilled();
                FilterCourses();
            }
        }

        string _searchCode = string.Empty;
        public string SearchCode
        {
            get { return _searchCode; }
            set
            {
                SetProperty(ref _searchCode, value);
                CheckIfFilled();
                FilterCourses();
            }
        }

        string _searchFieldOfStudy = string.Empty;
        public string SearchFieldOfStudy
        {
            get { return _searchFieldOfStudy; }
            set
            {
                SetProperty(ref _searchFieldOfStudy, value);
                CheckIfFilled();
                FilterCourses();
            }
        }


        Language _searchLanguage = (Language)1;
        bool _lang0Checked = true;
        public bool Lang0
        {
            get { return _lang0Checked; }
            set
            {
                SetProperty(ref _lang0Checked, value);
                if (_lang0Checked)
                    _searchLanguage = (Language)1;
                else
                    _searchLanguage = (Language)2;
                FilterCourses();
            }
        }

        StudyType _searchStudyType = (StudyType)1;
        bool _type0Checked = true;
        public bool Type0
        {
            get { return _type0Checked; }
            set
            {
                SetProperty(ref _type0Checked, value);
                if (_type0Checked)
                    _searchStudyType = (StudyType)1;
                else
                    _searchStudyType = (StudyType)2;
                FilterCourses();
            }
        }

        CourseType _searchCourseType = default;
        public int SelectedCourseType
        {
            get { return (int)_searchCourseType; }
            set
            {
                SetProperty(ref _searchCourseType, (CourseType)value);
                FilterCourses();
                
            }
        }

        protected int _selectedCourseIndex = -1;
        public int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }
            set
            {
                SetProperty(ref _selectedCourseIndex, value);
               
            }
        }



      
        void FilterCourses()
        {

            RefreshLocalCourses();
            List<CourseViewModel> lcvm = courseViewModels;
            
            lcvm = lcvm.FindAll(cvm => cvm.Language.Equals(_searchLanguage));

            lcvm = lcvm.FindAll(cvm => cvm.StudyType.Equals(_searchStudyType));

            if(_searchCourseType!=default)
            lcvm = lcvm.FindAll(cvm => cvm.Type.Equals(_searchCourseType));

            if (_searchName != null && _searchName != string.Empty)
            {
                lcvm = lcvm.FindAll(cvm => cvm.Name.ToUpper().StartsWith(_searchName.ToUpper()));
            }

            if (_searchFaculty != null && _searchFaculty != string.Empty)
            {
                lcvm = lcvm.FindAll(cvm => cvm.FacultySymbol.ToUpper().StartsWith(_searchFaculty.ToUpper()));
            }
            if (_searchCode != null && _searchCode != string.Empty)
            {
                lcvm = lcvm.FindAll(cvm => cvm.Code.ToUpper().StartsWith(_searchCode.ToUpper()));
            }
            if (_searchFieldOfStudy != null && _searchFieldOfStudy != string.Empty)
            {
                lcvm = lcvm.FindAll(cvm => cvm.FieldOfStudy.ToUpper().StartsWith(_searchFieldOfStudy.ToUpper()));
            }
            
            if (ListChanged(DisplayedCourses.ToList(), lcvm))
            {
                DisplayedCourses.Clear();
                foreach (CourseViewModel cvm in lcvm)
                {
                    DisplayedCourses.Add(cvm);
                }
            }

            if (_searchCode.Equals(string.Empty)
                && _searchFaculty.Equals(string.Empty)
                && _searchFieldOfStudy.Equals(string.Empty)
                && _searchName.Equals(string.Empty))
            DisplayedCourses.Clear();


        }
        void RefreshLocalCourses()
        {
            courseViewModels.Clear();
            foreach (CourseModel cm in CoursesModel.CourseModelsList)
            {
                if (cm is CoursesGroupModel)
                    courseViewModels.Add(new CoursesGroupViewModel(cm as CoursesGroupModel));
                else
                    courseViewModels.Add(new CourseViewModel(cm));
            }
        }
        private void RefreshCoursesModel()
        {
            if (CoursesModel != null)
            {
                try
                {
                    CoursesModel.RefreshCoursesFromData();
                }
                catch (DataServiceException e)
                {
                    Debug.WriteLine(e.Message);
                  
                }

            }
        }
        private bool ListChanged(List<CourseViewModel> before, List<CourseViewModel> after)
        {
           
            if (before.Count != after.Count) return true;
            for(int i=0;i<before.Count;i++)
            {
                if (!before[i].Code.Equals(after[i].Code))
                    return true;
            }
            return false;
        }
    }
}

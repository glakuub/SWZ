using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWZ.Models;
using Windows.UI.Xaml;

namespace SWZ.ViewModels
{
    class FindReplacementViewModel : NotificationBase
    {
        CoursesModel coursesModel;
        public ObservableCollection<CourseViewModel> courses;
        public ObservableCollection<ReplacementViewModel> replacements;


        string _searchName;
        public string SearchName
        {
            get { return _searchName; }
            set { SetProperty(ref _searchName, value);
                filterCourses();
            }
        }

        string _searchFaculty;
        public string SearchFaculty
        {
            get { return _searchFaculty; }
            set { SetProperty(ref _searchFaculty, value);
                filterCourses();
            }
        }


        Language _searchLanguage;
        bool _lang0Checked = true;
        public bool Lang0
        {
            get { return _lang0Checked; }
            set { SetProperty(ref _lang0Checked, value);
                if (_lang0Checked)
                    _searchLanguage = (Language)1;
                else
                    _searchLanguage = (Language)2;
                filterCourses();
            }
        }

        StudyType _searchStudyType;
        bool _type0Checked = true;
        public bool Type0
        {
            get { return _type0Checked; }
            set { SetProperty(ref _type0Checked, value);
                if (_type0Checked)
                    _searchStudyType = (StudyType)1;
                else
                    _searchStudyType = (StudyType)2;
                filterCourses();
            }
        }

        CourseType _searchCourseType;
        public int SelectedCourseType
        {
            get { return (int)_searchCourseType; }
            set { SetProperty(ref _searchCourseType, (CourseType)value);
                filterCourses();
                Debug.WriteLine(value);
            }
        }

        int _selectedCourseIndex;
        public int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }
            set
            {
                SetProperty(ref _selectedCourseIndex, value);
            }
        }

        public FindReplacementViewModel(CoursesModel coursesModel)
        {
            courses = new ObservableCollection<CourseViewModel>();
            replacements = new ObservableCollection<ReplacementViewModel>();
            this.coursesModel = coursesModel;
            coursesModel.GetCourses();
          

            foreach (CourseModel cm in coursesModel.courseModelsList)
            {
                courses.Add(new CourseViewModel(cm));
            }
        }
        

        void filterCourses()
        {
            Debug.WriteLine("filter");
            refreshLocalCourses();
            List<CourseViewModel> lcvm = courses.ToList();

            lcvm = lcvm.FindAll(cvm => cvm.Language.Equals(_searchLanguage));

            lcvm = lcvm.FindAll(cvm => cvm.StudyType.Equals(_searchStudyType));

            if (_searchName!=null && _searchName!=string.Empty)
            {
                lcvm = lcvm.FindAll(cvm => cvm.Name.ToUpper().StartsWith(_searchName.ToUpper()));

               
            }

            if (_searchFaculty != null && _searchFaculty != string.Empty)
            {
                
               lcvm = lcvm.FindAll(cvm => cvm.FacultySymbol.ToUpper().StartsWith(_searchFaculty.ToUpper()));
              
            }

            
            courses.Clear();
            foreach (CourseViewModel cvm in lcvm)
            {
                courses.Add(cvm);
            }


        }
        void refreshLocalCourses()
        {
            courses.Clear();
            foreach (CourseModel cm in coursesModel.courseModelsList)
            {
                courses.Add(new CourseViewModel(cm));
            }
        }
        void refreshCoursesFromData()
        {
            if (coursesModel != null)
            {
                coursesModel.GetCourses();
                refreshLocalCourses();

            }
        }
    }
}

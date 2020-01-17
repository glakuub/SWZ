using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class FindCourseBaseViewModel: NotificationBase
    {
        public CoursesModel coursesModel { set; get; }
        public ReplacementsModel replacementsModel { set; get; }
        public ObservableCollection<CourseViewModel> Courses { set; get; }
        public ObservableCollection<ReplacementViewModel> Replacements { set; get; }
        public ICommand GoBack { set; get; }

        public FindCourseBaseViewModel()
        {
            Courses = new ObservableCollection<CourseViewModel>();
            Replacements = new ObservableCollection<ReplacementViewModel>();
            coursesModel = new CoursesModel();
            replacementsModel = new ReplacementsModel();
            coursesModel.GetCoursesFromData();
        }

        string _searchName;
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                SetProperty(ref _searchName, value);
                filterCourses();
            }
        }

        string _searchFaculty;
        public string SearchFaculty
        {
            get { return _searchFaculty; }
            set
            {
                SetProperty(ref _searchFaculty, value);
                filterCourses();
            }
        }

        string _searchCode;
        public string SearchCode
        {
            get { return _searchCode; }
            set
            {
                SetProperty(ref _searchCode, value);
                filterCourses();
            }
        }

        string _searchFieldOfStudy;
        public string SearchFieldOfStudy
        {
            get { return _searchFieldOfStudy; }
            set
            {
                SetProperty(ref _searchFieldOfStudy, value);
                filterCourses();
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
                filterCourses();
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
                filterCourses();
            }
        }

        CourseType _searchCourseType = (CourseType)0;
        public int SelectedCourseType
        {
            get { return (int)_searchCourseType - 1; }
            set
            {
                SetProperty(ref _searchCourseType, (CourseType)(value + 1));
                filterCourses();
                Debug.WriteLine(value);
            }
        }

        protected int _selectedCourseIndex;
        public int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }
            set
            {
                SetProperty(ref _selectedCourseIndex, value);
               
            }
        }



      
        void filterCourses()
        {
            Debug.WriteLine("filter");
            refreshLocalCourses();
            List<CourseViewModel> lcvm = Courses.ToList();

            lcvm = lcvm.FindAll(cvm => cvm.Language.Equals(_searchLanguage));

            lcvm = lcvm.FindAll(cvm => cvm.StudyType.Equals(_searchStudyType));

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


            Courses.Clear();
            foreach (CourseViewModel cvm in lcvm)
            {
                Courses.Add(cvm);
            }


        }
        void refreshLocalCourses()
        {
            Courses.Clear();
            foreach (CourseModel cm in coursesModel.courseModelsList)
            {
                Courses.Add(new CourseViewModel(cm));
            }
        }
        void refreshCoursesFromData()
        {
            if (coursesModel != null)
            {
                coursesModel.GetCoursesFromData();
                refreshLocalCourses();

            }
        }
    }
}

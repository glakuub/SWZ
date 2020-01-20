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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SWZ.ViewModels
{
     class CreatePropositionViewModel: FindCourseBaseViewModel
    {   
        
        public bool CanDelete { set; get; }
        private bool _canGoToSummary = true;
        public bool CanGoToSummary { set { Debug.WriteLine(value); SetProperty(ref _canGoToSummary,value); } get { return _canGoToSummary; } }
        public ObservableCollection<CourseViewModel> AddedCourses { set; get; }

        public ICommand GoToAddCourseToProposition{ set; get; }

        public ICommand CreateProposition { set; get; }

        
        public ICommand DeleteCourse { set; get; }

        public int SelectedReplacementCourse { set; get; }

        public PropositionViewModel PropositionViewModel { set; get; }

        public string LoggedUserName
        {
            get
            {
                return UserSession.Get.UserID == null ? string.Empty : $"Zalogowano jako: {GetUserName(UserSession.Get.UserID.Value)}";
            }
        }

        public new int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }

            set {
               
                SetProperty(ref _selectedCourseIndex, value);
                CheckCanGoToSummary();
            }
        }


        public CreatePropositionViewModel()
        {
            CanGoToSummary = false;
            CanDelete = false;

            AddedCourses = new ObservableCollection<CourseViewModel>();
            AddedCourses.CollectionChanged += (sender, args) =>
            {
                CheckCanGoToSummary();
            };
            CreateProposition = new CommandHandler(GoToPropositionSummary);
            DeleteCourse = new CommandHandler(DeleteSelected);
            PropositionViewModel = new PropositionViewModel(new PropositionModel());
        }

        void GoToPropositionSummary()
        {   
            var rootFrame = Window.Current.Content as Frame;
            UpdatePropositionViewModel();
            rootFrame.Navigate(typeof(PropositionSummary), PropositionViewModel);
         
        }
        void UpdatePropositionViewModel()
        {   
            PropositionViewModel.Course = Courses[SelectedCourseIndex];
            PropositionViewModel.Replacements = AddedCourses;
            PropositionViewModel.Date = DateTime.Now.ToString();
            PropositionViewModel.Student = new StudentViewModel(new StudentModel());

        }
        public void DeleteSelected()
        {
           
            if(SelectedReplacementCourse >= 0 && SelectedReplacementCourse < AddedCourses.Count)
            {
                AddedCourses.RemoveAt(SelectedReplacementCourse);
            }
        }
        private string GetUserName(int id)
        {
            var user = new StudentViewModel(StudentModel.GetById(id));
            return $"{user.FirstName} {user.LastName}";
        }
        public void CheckCanGoToSummary()
        {
            if (_selectedCourseIndex != -1 && AddedCourses.Count > 0)
                CanGoToSummary = true;
            else
                CanGoToSummary = false;
        }

    }
}

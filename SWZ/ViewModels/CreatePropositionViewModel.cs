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

        private bool _canDelete = false;
        public bool CanDelete { set { SetProperty(ref _canDelete, value); } get{ return _canDelete; } }
        private bool _canGoToSummary = false;
        public bool CanGoToSummary { set { SetProperty(ref _canGoToSummary,value); } get { return _canGoToSummary; } }
        public ObservableCollection<CourseViewModel> AddedCourses { set; get; }

        public ICommand GoToAddCourseToProposition{ set; get; }

        public ICommand CreateProposition { set; get; }

        
        public ICommand DeleteCourse { set; get; }

        private int _selectedReplacementCourse = -1;
        public int SelectedReplacementCourse { set { SetProperty(ref _selectedReplacementCourse, value);CheckCanDelete(); } get { return _selectedReplacementCourse; } }

        public PropositionViewModel PropositionViewModel { set; get; }

        public string LoggedUserName
        {
            get
            {
                return UserSession.Get.IsSet ? $"Zalogowano jako: { UserSession.Get.StudentFirstName} {UserSession.Get.StudentLastName}" : string.Empty;
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
                CheckCanDelete();
            };
            CreateProposition = new CommandHandler(GoToPropositionSummary, can);
            DeleteCourse = new CommandHandler(DeleteSelected, can);
            PropositionViewModel = new PropositionViewModel(new PropositionModel());
        }

        Predicate<object> can = (can) => { return can==null?true:(bool)can; };
        void GoToPropositionSummary()
        {   
            var rootFrame = Window.Current.Content as Frame;
            UpdatePropositionViewModel();
            rootFrame.Navigate(typeof(PropositionSummary), PropositionViewModel);
         
        }
        void UpdatePropositionViewModel()
        {   
            PropositionViewModel.Course = DisplayedCourses[SelectedCourseIndex];
            PropositionViewModel.Replacements = AddedCourses;
            PropositionViewModel.Date = DateTime.Now.ToString();
            PropositionViewModel.Student = new StudentViewModel(UserSession.Get.Model);

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
        public void CheckCanDelete()
        {
            if (SelectedReplacementCourse > -1 && AddedCourses.Count >= 0)
                CanDelete = true;
            else
                CanDelete = false;
        }

    }
}

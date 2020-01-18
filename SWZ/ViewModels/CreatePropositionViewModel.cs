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
        public ObservableCollection<CourseViewModel> AddedCourses { set; get; }

        public ICommand GoToAddCourseToProposition{ set; get; }

        public ICommand CreateProposition { set; get; }

        public PropositionViewModel PropositionViewModel { set; get; }
        public CreatePropositionViewModel()
        {
            AddedCourses = new ObservableCollection<CourseViewModel>();
            CreateProposition = new CommandHandler(GoToPropositionSummary);
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
            PropositionViewModel.Course = Courses[_selectedCourseIndex];
            PropositionViewModel.Replacements = AddedCourses;
            PropositionViewModel.Date = DateTime.Now.ToString();
            PropositionViewModel.Student = new StudentViewModel(new StudentModel());

        }
    }
}

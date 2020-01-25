using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWZ.Models;
using Windows.UI.Xaml;

namespace SWZ.ViewModels
{
    class FindReplacementViewModel : FindCourseBaseViewModel
    {
        public string LoggedUserName
        {
            get
            {
                return UserSession.Get.UserID == null ? string.Empty : $"Zalogowano jako: {GetUserName(UserSession.Get.UserID.Value)}";
            }
        }

        public ReplacementsModel replacementsModel { set; get; }
        public ObservableCollection<ReplacementViewModel> Replacements { set; get; }



        public FindReplacementViewModel()
        {
            Replacements = new ObservableCollection<ReplacementViewModel>();
            replacementsModel = new ReplacementsModel();

        }

        public new int SelectedCourseIndex
        {
            get { return _selectedCourseIndex; }
            set
            {
                SetProperty(ref _selectedCourseIndex, value);
                if(SelectedCourseIndex >=0 && SelectedCourseIndex<DisplayedCourses.Count)
                FindReplacementsAsync();

            }
        }

        async void FindReplacementsAsync()
        {
            Replacements.Clear();
            replacementsModel.SetReplaced(DisplayedCourses.ElementAt(SelectedCourseIndex).Model);
            var rmlist = await Task.Run(()=>replacementsModel.GetReplacementsFromData());
            foreach (ReplacementModel rm in rmlist)
            {
                Replacements.Add(new ReplacementViewModel(rm));
            }
        }
        private string GetUserName(int id)
        {
            var user = new StudentViewModel(StudentModel.GetById(id));
            return $"{user.FirstName} {user.LastName}";
        }
    }


}


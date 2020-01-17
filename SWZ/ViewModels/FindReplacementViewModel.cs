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
                findReplacements();

            }
        }

        void findReplacements()
        {
            Replacements.Clear();
            replacementsModel.SetReplaced(coursesModel.At(SelectedCourseIndex));
            foreach(ReplacementModel rm in replacementsModel.GetReplacementsFromData())
            {
                Replacements.Add(new ReplacementViewModel(rm));
            }
        }
        
    }
}

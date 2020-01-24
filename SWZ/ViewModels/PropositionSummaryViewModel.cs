using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SWZ.Models;

namespace SWZ.ViewModels
{
    class PropositionSummaryViewModel: NotificationBase
    {
        public PropositionViewModel PropositionViewModel { set; get; }
        public StudentViewModel StudentViewModel { set; get; }
        public ICommand SaveProposition { set; get; }
        public ICommand Cancel { set; get; }

        public PropositionSummaryViewModel()
        {   
            if(UserSession.Get.UserID != null)
            StudentViewModel = new StudentViewModel(StudentModel.GetById(UserSession.Get.UserID.Value));
            Cancel = new CommandHandler(GoBackMethod);
            SaveProposition = new CommandHandler(SavePropositionMethod);
        }
        private void GoBackMethod()
        {
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
        }
        private void SavePropositionMethod()
        {
            PropositionViewModel.Save();
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.BackStack.RemoveAt(rootFrame.BackStackDepth - 1);
            rootFrame.GoBack();
            
        }


    }
}

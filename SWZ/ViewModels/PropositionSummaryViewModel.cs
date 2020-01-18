using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SWZ.ViewModels
{
    class PropositionSummaryViewModel: NotificationBase
    {
        public PropositionViewModel PropositionViewModel { set; get; }
        public ICommand SaveProposition { set; get; }
        public ICommand GoBack { set; get; }

        public PropositionSummaryViewModel()
        {
            GoBack = new CommandHandler(GoBackMethod);
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
            
        }


    }
}

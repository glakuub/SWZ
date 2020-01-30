using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SWZ.Models;
using System.Diagnostics;
//using SWZ.Views;

namespace SWZ.ViewModels
{
    class PropositionSummaryViewModel: NotificationBase
    {

        public ContentDialog AlertDialog { set; get; }
        private PropositionViewModel _proposition;
        public PropositionViewModel PropositionViewModel { set { _proposition = value; StudentViewModel = _proposition.Student; } get { return _proposition; } }
        public StudentViewModel StudentViewModel { private set; get; }
        public ICommand SaveProposition { set; get; }
        public ICommand Cancel { set; get; }

        public PropositionSummaryViewModel()
        {

                    
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
            try
            {
                PropositionViewModel.Save();
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.BackStack.RemoveAt(rootFrame.BackStackDepth - 1);
                rootFrame.GoBack();
            }
            catch(DataServiceException e)
            {
                Debug.WriteLine(e.Message);
                ShowAlertAsync();
            }
            
        }
        private async void ShowAlertAsync()
        {
            if(AlertDialog!=null)
            await AlertDialog.ShowAsync();
        }


    }
}

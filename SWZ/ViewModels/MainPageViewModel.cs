using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
//using SWZ.Views;
using SWZ.Models;
using System.Diagnostics;
using Windows.UI.Popups;

namespace SWZ.ViewModels
{
    class MainPageViewModel: NotificationBase
    {
        private static readonly int MOCKED_ID = 2;

        public ICommand GoToUserPage { set; get; }
        public ICommand GoToStudentPage { set; get; }

        public Type StudentPageType { set; get; }
        public Type UserPageType { set; get; }
        public ContentDialog AlertDialog { set; get; }
        public MainPageViewModel()
        {
           
            GoToUserPage = new CommandHandler(GoToUserPageMethod);
            GoToStudentPage = new CommandHandler(GoToStudentPageMethod);
            
        }

        private void GoToStudentPageMethod()
        {
            try
            {
                LogUserIn();

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(StudentPageType);
            }
            catch(DataServiceException e)
            {
                Debug.WriteLine(e.Message);
                ShowAlert();
            }
        }

        private async void ShowAlert()
        {
            if (AlertDialog != null)
            await AlertDialog.ShowAsync();
        }

        private void GoToUserPageMethod()
        {
            LogUserOut();
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(UserPageType);
        }

        private void LogUserOut()
        {
            UserSession.Get.Destroy();
        }

        private void LogUserIn()
        {
            UserSession.Get.Create(MOCKED_ID);
        }
    }
}

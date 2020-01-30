using SWZ.ViewModels;
using SWZ.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SWZ.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddCourseToProposition : Page
    {
        AddCourseToPropositionViewModel viewModel;

        public AddCourseToProposition()
        {
            viewModel = new AddCourseToPropositionViewModel();
            viewModel.AlertDialog = new NoDataserviceConnectionDialog();
            viewModel.GoBack = new CommandHandler(() =>
            {
                if (this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
            });
       
            this.InitializeComponent();
          
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            var addedCourses = e.Parameter as ObservableCollection<CourseViewModel>;

            viewModel.AddedCourses = addedCourses;
        }
    }
}

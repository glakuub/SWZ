using SWZ.Models;
using SWZ.ViewModels;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SWZ.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateProposition : Page
    {
        CreatePropositionViewModel ViewModel { set; get; }
        
        public CreateProposition()
        {
            ViewModel = new CreatePropositionViewModel();
            ViewModel.GoToAddCourseToProposition = new CommandHandler(()=>{
            Frame.Navigate(typeof(AddCourseToProposition),ViewModel.AddedCourses); });

            ViewModel.GoBack = new CommandHandler(() =>{
                if (this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
            });


            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;


            var _typeEnumVals = Enum.GetValues(typeof(CourseType)).Cast<CourseType>();
            if (_typeEnumVals != null)
                SearchCourseType.ItemsSource = _typeEnumVals;
        }

      
    }
}

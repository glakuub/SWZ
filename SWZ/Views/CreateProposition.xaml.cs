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
        CreatePropositionViewModel viewModel { set; get; }
        
        public CreateProposition()
        {
            viewModel = new CreatePropositionViewModel();
            viewModel.AlertDialog = new NoDataserviceConnectionDialog();
            viewModel.PropositionSummaryPageType = typeof(PropositionSummary);
            viewModel.GoToAddCourseToProposition = new CommandHandler(()=>{
            Frame.Navigate(typeof(AddCourseToProposition),viewModel.AddedCourses); });

            viewModel.GoBack = new CommandHandler(() =>{
                if (this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
            });

            

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;


           
        }

      
    }
}

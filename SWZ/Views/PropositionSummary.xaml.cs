using SWZ.ViewModels;
using System;
using System.Collections.Generic;
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
    public sealed partial class PropositionSummary : Page
    {
        PropositionSummaryViewModel viewModel;
        public PropositionSummary()
        {
            this.InitializeComponent();
            viewModel = new PropositionSummaryViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var propositionViewModel = e.Parameter as PropositionViewModel;
            viewModel.PropositionViewModel = propositionViewModel;
        }
    }
}

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
using SWZ.ViewModels;
using SWZ.Models;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SWZ.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FindReplacement : Page
    {
        FindReplacementViewModel viewModel;
       
        public FindReplacement()
        {
            
            
            
            viewModel = new FindReplacementViewModel();
            viewModel.GoBack = new CommandHandler(()=> { this.Frame.GoBack(); });

          
            this.InitializeComponent();
            var _typeEnumVals = Enum.GetValues(typeof(CourseType)).Cast<CourseType>();
            if (_typeEnumVals != null)
                SearchCourseType.ItemsSource = _typeEnumVals;
            
        }

       
    }
}

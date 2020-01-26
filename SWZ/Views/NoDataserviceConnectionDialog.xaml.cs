using SWZ.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SWZ.Views
{
    public sealed partial class NoDataserviceConnectionDialog : ContentDialog
    {   

        public ICommand Close { set; get; }

        public NoDataserviceConnectionDialog()
        {
            Close = new CommandHandler(()=> { this.Hide(); });
            
            this.InitializeComponent();
        }

       
    }
}

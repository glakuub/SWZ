﻿using SWZ.ViewModels;
using SWZ.Views;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SWZ
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        NotificationBase mainPage;
        public MainPage()
        {
            this.InitializeComponent();
            mainPage = new MainPageViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserView));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Frame.Navigate(typeof(StudentView));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
       
    }
}

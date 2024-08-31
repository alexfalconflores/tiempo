using System;

using UWP_Test.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWP_Test.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}

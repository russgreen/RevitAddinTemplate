using Autodesk.Revit.UI;
using RevitAddinTemplate.ViewModels;
using System;
using System.Windows;

namespace RevitAddinTemplate.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly ViewModels.MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();

            //var viewModel = new MainViewModel();
            //this.DataContext = viewModel;

            //enable this line of code if XAML Behaviors is used
            //var _ = new Microsoft.Xaml.Behaviors.DefaultTriggerAttribute(typeof(Trigger), typeof(Microsoft.Xaml.Behaviors.TriggerBase), null);

            _viewModel = (ViewModels.MainViewModel)this.DataContext;
            _viewModel.ClosingRequest += (sender, e) => this.Close();

        }

    }
}

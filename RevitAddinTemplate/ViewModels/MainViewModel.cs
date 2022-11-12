using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using System.Windows.Input;

namespace RevitAddinTemplate.ViewModels
{
    internal class MainViewModel : ObservableValidator 
    {
        public string WindowTitle { get; private set; }

        public bool IsCommandEnabled { get; private set; } = true;

        public ICommand RunCommand { get; }

        public MainViewModel()
        {
            var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            WindowTitle = $"RevitAddinTemplate {informationVersion} ({App.RevitDocument.Title})";

            RunCommand = new RelayCommand(RunCommandMethod);
        }

        private void RunCommandMethod()
        {
            //DO STUFF HERE
            IsCommandEnabled = false;
        }
    }
}

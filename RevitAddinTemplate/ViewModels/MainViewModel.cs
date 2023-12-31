using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Windows.Input;

namespace RevitAddinTemplate.ViewModels
{
    internal partial class MainViewModel : BaseViewModel
    {
        public string WindowTitle { get; private set; }

        [ObservableProperty]
        private bool _isCommandEnabled = true;

        private readonly ILogger<MainViewModel> _logger = Host.GetService<ILogger<MainViewModel>>();

        public MainViewModel()
        {
            var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            WindowTitle = $"RevitAddinTemplate {informationVersion} ({App.RevitDocument.Title})";

            _logger.LogDebug("MainViewModel");
        }

        [RelayCommand]
        private void Run()
        {
            //DO STUFF HERE
            IsCommandEnabled = false;
        }
    }
}

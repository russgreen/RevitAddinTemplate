using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
#if (UseDI)
using Microsoft.Extensions.Logging;
#endif
using System.Reflection;
using System.Windows.Input;

namespace RevitAddinTemplate.ViewModels
{
    internal partial class MainViewModel : BaseViewModel
    {
        public string WindowTitle { get; private set; }

        [ObservableProperty]
        private bool _isCommandEnabled = true;

#if (UseDI)
        private readonly ILogger<MainViewModel> _logger = Host.GetService<ILogger<MainViewModel>>();
#endif
        
        public MainViewModel()
        {
            var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            WindowTitle = $"RevitAddinTemplate {informationVersion} ({App.RevitDocument.Title})";

#if (UseDI)
            _logger.LogDebug("MainViewModel");
#endif
        }

        [RelayCommand]
        private void Run()
        {
            //DO STUFF HERE
            IsCommandEnabled = false;
        }
    }
}

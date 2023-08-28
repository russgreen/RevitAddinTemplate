using CommunityToolkit.Mvvm.ComponentModel;

namespace RevitAddinTemplate.Models;
internal partial class Model : ObservableObject
{
    [ObservableProperty]
    private string _parameter;
}

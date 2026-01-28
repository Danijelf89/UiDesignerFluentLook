using CommunityToolkit.Mvvm.ComponentModel;

namespace UIDesignerWPFUI.Models
{
    public partial class GridColumnItem : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isVisible = true;

        [ObservableProperty]
        private string _columnType = string.Empty;

        [ObservableProperty]
        private string _width = string.Empty;
    }
}

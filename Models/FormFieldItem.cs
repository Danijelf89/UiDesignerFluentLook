using CommunityToolkit.Mvvm.ComponentModel;

namespace UIDesignerWPFUI.Models
{
    public partial class FormFieldItem : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _fieldType = "String";

        [ObservableProperty]
        private string _width = "200";

        [ObservableProperty]
        private string _label = string.Empty;

        [ObservableProperty]
        private string _labelPosition = "Left";

        [ObservableProperty]
        private int _row;

        [ObservableProperty]
        private int _column;
    }
}

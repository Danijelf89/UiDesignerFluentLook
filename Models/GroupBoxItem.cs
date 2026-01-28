using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UIDesignerWPFUI.Models
{
    public partial class GroupBoxItem : ObservableObject
    {
        [ObservableProperty]
        private string _name = "New Group";

        [ObservableProperty]
        private int _row;

        [ObservableProperty]
        private int _column;

        [ObservableProperty]
        private ObservableCollection<FormFieldItem> _fields = new();
    }
}

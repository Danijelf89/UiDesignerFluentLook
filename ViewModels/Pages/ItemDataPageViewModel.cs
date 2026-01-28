using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UIDesignerWPFUI.Helpers;
using UIDesignerWPFUI.Models;
using UIDesignerWPFUI.Views.Windows;

namespace UIDesignerWPFUI.ViewModels.Pages
{
    public partial class ItemDataPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<FormFieldItem> _fields = new()
        {
            new FormFieldItem { Name = "FirstName", FieldType = "String", Width = "200", Label = "First Name", LabelPosition = "Left", Row = 0, Column = 0 },
            new FormFieldItem { Name = "LastName", FieldType = "String", Width = "200", Label = "Last Name", LabelPosition = "Left", Row = 1, Column = 0 },
            new FormFieldItem { Name = "BirthDate", FieldType = "DateTime", Width = "200", Label = "Birth Date", LabelPosition = "Left", Row = 2, Column = 0 },
            new FormFieldItem { Name = "IsActive", FieldType = "CheckBox", Width = "200", Label = "Active", LabelPosition = "Left", Row = 3, Column = 0 },
        };

        public List<string> FieldTypes { get; } = new() { "String", "DateTime", "CheckBox" };
        public List<string> LabelPositions { get; } = new() { "Left", "Top" };

        [ObservableProperty]
        private FormFieldItem? _selectedField;

        [RelayCommand]
        private void PreviewForm()
        {
            var previewWindow = new ItemPreviewWindow(Fields.ToList());
            previewWindow.Owner = CurrentStateHelper.Mainwindow;
            previewWindow.ShowDialog();
        }
    }
}

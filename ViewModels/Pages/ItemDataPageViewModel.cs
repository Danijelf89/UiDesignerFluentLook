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
        private ObservableCollection<object> _items = new()
        {
            new GroupBoxItem
            {
                Name = "Personal Info",
                Row = 0,
                Column = 0,
                Fields = new ObservableCollection<FormFieldItem>
                {
                    new FormFieldItem { Name = "FirstName", FieldType = "String", Width = "200", Label = "First Name", LabelPosition = "Left", Row = 0, Column = 0 },
                    new FormFieldItem { Name = "LastName", FieldType = "String", Width = "200", Label = "Last Name", LabelPosition = "Left", Row = 1, Column = 0 },
                }
            }
        };

        public List<string> FieldTypes { get; } = new() { "String", "DateTime", "CheckBox" };
        public List<string> LabelPositions { get; } = new() { "Left", "Top" };

        [ObservableProperty]
        private object? _selectedItem;

        [ObservableProperty]
        private bool _isGroupSelected;

        [ObservableProperty]
        private bool _isFieldSelected;

        partial void OnSelectedItemChanged(object? value)
        {
            IsGroupSelected = value is GroupBoxItem;
            IsFieldSelected = value is FormFieldItem;
        }

        public GroupBoxItem? SelectedGroup => SelectedItem as GroupBoxItem;
        public FormFieldItem? SelectedField => SelectedItem as FormFieldItem;

        partial void OnIsGroupSelectedChanged(bool value) => OnPropertyChanged(nameof(SelectedGroup));
        partial void OnIsFieldSelectedChanged(bool value) => OnPropertyChanged(nameof(SelectedField));

        [RelayCommand]
        private void AddGroupBox()
        {
            Items.Add(new GroupBoxItem { Name = "New Group" });
        }

        [RelayCommand]
        private void AddField()
        {
            Items.Add(new FormFieldItem { Name = "NewField", FieldType = "String", Width = "200", Label = "New Field", LabelPosition = "Left" });
        }

        [RelayCommand]
        private void AddFieldToGroup()
        {
            GroupBoxItem? group = SelectedItem as GroupBoxItem;
            if (group == null && SelectedItem is FormFieldItem field)
            {
                group = Items.OfType<GroupBoxItem>().FirstOrDefault(g => g.Fields.Contains(field));
            }
            if (group == null)
            {
                group = Items.OfType<GroupBoxItem>().FirstOrDefault();
            }
            group?.Fields.Add(new FormFieldItem { Name = "NewField", FieldType = "String", Width = "200", Label = "New Field", LabelPosition = "Left" });
        }

        [RelayCommand]
        private void PreviewForm()
        {
            var previewWindow = new ItemPreviewWindow(Items.ToList());
            previewWindow.Owner = CurrentStateHelper.Mainwindow;
            previewWindow.ShowDialog();
        }
    }
}

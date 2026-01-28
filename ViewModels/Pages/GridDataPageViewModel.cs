using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UIDesignerWPFUI.Helpers;
using UIDesignerWPFUI.Models;
using UIDesignerWPFUI.Views.Windows;

namespace UIDesignerWPFUI.ViewModels.Pages
{
    public partial class GridDataPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<GridColumnItem> _columns = new()
        {
            new GridColumnItem { Name = "Column 1", ColumnType = "Text", Width = "100", IsVisible = true },
            new GridColumnItem { Name = "Column 2", ColumnType = "Text", Width = "100", IsVisible = true },
            new GridColumnItem { Name = "Column 3", ColumnType = "Text", Width = "100", IsVisible = true },
            new GridColumnItem { Name = "Column 4", ColumnType = "Text", Width = "100", IsVisible = false },
        };

        [ObservableProperty]
        private GridColumnItem? _selectedColumn;

        [RelayCommand]
        private void PreviewGrid()
        {
            var visibleColumns = Columns.Where(c => c.IsVisible).ToList();

            var previewWindow = new GridPreviewWindow(visibleColumns);
            previewWindow.Owner = CurrentStateHelper.Mainwindow;
            previewWindow.ShowDialog();
        }
    }
}

using System.Collections.Generic;
using System.Windows.Controls;
using UIDesignerWPFUI.Models;

namespace UIDesignerWPFUI.Views.Windows
{
    public partial class GridPreviewWindow
    {
        public GridPreviewWindow(List<GridColumnItem> visibleColumns)
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { DragMove(); };

            foreach (var col in visibleColumns)
            {
                PreviewDataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = col.Name,
                    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
                });
            }
        }
    }
}

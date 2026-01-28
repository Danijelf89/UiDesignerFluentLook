using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UIDesignerWPFUI.Models;

namespace UIDesignerWPFUI.Views.Windows
{
    public partial class ItemPreviewWindow
    {
        public ItemPreviewWindow(List<object> items)
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { DragMove(); };
            BuildForm(items);
        }

        private void BuildForm(List<object> items)
        {
            if (items.Count == 0) return;

            var groups = items.OfType<GroupBoxItem>().ToList();
            var standaloneFields = items.OfType<FormFieldItem>().ToList();

            int maxRow = 0;
            int maxCol = 0;
            if (groups.Count > 0)
            {
                maxRow = groups.Max(g => g.Row);
                maxCol = groups.Max(g => g.Column);
            }

            // Standalone fields go into rows after the group boxes
            int standaloneStartRow = maxRow + 1;
            int totalRows = standaloneFields.Count > 0 ? standaloneStartRow + 1 : maxRow + 1;

            for (int i = 0; i < totalRows; i++)
                FormGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            for (int c = 0; c <= maxCol; c++)
                FormGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            foreach (var group in groups)
            {
                var groupBox = new GroupBox
                {
                    Header = group.Name,
                    Margin = new Thickness(5)
                };

                var grid = new Grid();
                BuildFieldGrid(grid, group.Fields.ToList());
                groupBox.Content = grid;

                Grid.SetRow(groupBox, group.Row);
                Grid.SetColumn(groupBox, group.Column);
                FormGrid.Children.Add(groupBox);
            }

            if (standaloneFields.Count > 0)
            {
                var fieldGrid = new Grid { Margin = new Thickness(5) };
                BuildFieldGrid(fieldGrid, standaloneFields);
                Grid.SetRow(fieldGrid, standaloneStartRow);
                Grid.SetColumn(fieldGrid, 0);
                Grid.SetColumnSpan(fieldGrid, maxCol + 1);
                FormGrid.Children.Add(fieldGrid);
            }
        }

        private void BuildFieldGrid(Grid grid, List<FormFieldItem> fields)
        {
            if (fields.Count == 0) return;

            int maxLogicalRow = fields.Max(f => f.Row);
            int maxLogicalCol = fields.Max(f => f.Column);

            var rowHasTopLabel = new bool[maxLogicalRow + 1];
            foreach (var field in fields)
            {
                if (field.LabelPosition == "Top")
                    rowHasTopLabel[field.Row] = true;
            }

            var gridRowStart = new int[maxLogicalRow + 1];
            int currentGridRow = 0;
            for (int r = 0; r <= maxLogicalRow; r++)
            {
                gridRowStart[r] = currentGridRow;
                currentGridRow += rowHasTopLabel[r] ? 2 : 1;
            }
            int totalGridRows = currentGridRow;
            int totalGridCols = (maxLogicalCol + 1) * 3;

            for (int i = 0; i < totalGridRows; i++)
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            for (int c = 0; c < totalGridCols; c++)
            {
                if (c % 3 == 1)
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8) });
                else
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            foreach (var field in fields)
            {
                int baseGridRow = gridRowStart[field.Row];
                int labelRow, labelCol, fieldRow, fieldCol;

                if (field.LabelPosition == "Top")
                {
                    labelRow = baseGridRow;
                    labelCol = field.Column * 3;
                    fieldRow = baseGridRow + 1;
                    fieldCol = field.Column * 3;
                }
                else
                {
                    fieldRow = rowHasTopLabel[field.Row] ? baseGridRow + 1 : baseGridRow;
                    labelRow = fieldRow;
                    labelCol = field.Column * 3;
                    fieldCol = field.Column * 3 + 2;
                }

                var label = new TextBlock
                {
                    Text = field.Label + ":",
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5)
                };
                Grid.SetRow(label, labelRow);
                Grid.SetColumn(label, labelCol);
                if (field.LabelPosition == "Top")
                    Grid.SetColumnSpan(label, 3);
                grid.Children.Add(label);

                FrameworkElement input = field.FieldType switch
                {
                    "DateTime" => new DatePicker { Width = double.TryParse(field.Width, out var w) ? w : 200, Margin = new Thickness(5) },
                    "CheckBox" => new CheckBox { Content = field.Label, Margin = new Thickness(5) },
                    _ => new TextBox { Width = double.TryParse(field.Width, out var w2) ? w2 : 200, Margin = new Thickness(5) },
                };
                Grid.SetRow(input, fieldRow);
                Grid.SetColumn(input, fieldCol);
                if (field.LabelPosition == "Top")
                {
                    Grid.SetColumnSpan(input, 3);
                    input.HorizontalAlignment = HorizontalAlignment.Left;
                }
                grid.Children.Add(input);
            }
        }
    }
}

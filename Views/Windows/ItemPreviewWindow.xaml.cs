using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UIDesignerWPFUI.Models;

namespace UIDesignerWPFUI.Views.Windows
{
    public partial class ItemPreviewWindow
    {
        public ItemPreviewWindow(List<FormFieldItem> fields)
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { DragMove(); };
            BuildForm(fields);
        }

        private void BuildForm(List<FormFieldItem> fields)
        {
            if (fields.Count == 0) return;

            // For each logical row, check if ANY field on that row uses "Top" label.
            // If so, that logical row needs 2 grid rows (label row + field row).
            // Otherwise it needs 1 grid row (label and field side by side).
            int maxLogicalRow = fields.Max(f => f.Row);
            int maxLogicalCol = fields.Max(f => f.Column);

            var rowHasTopLabel = new bool[maxLogicalRow + 1];
            foreach (var field in fields)
            {
                if (field.LabelPosition == "Top")
                    rowHasTopLabel[field.Row] = true;
            }

            // Build mapping: logical row -> starting grid row
            var gridRowStart = new int[maxLogicalRow + 1];
            int currentGridRow = 0;
            for (int r = 0; r <= maxLogicalRow; r++)
            {
                gridRowStart[r] = currentGridRow;
                currentGridRow += rowHasTopLabel[r] ? 2 : 1;
            }
            int totalGridRows = currentGridRow;

            // Columns: each logical column gets 3 grid columns: label | gap | field.
            // "Top" fields span all 3 so the input is flush-left under its label.
            int totalGridCols = (maxLogicalCol + 1) * 3;

            for (int i = 0; i < totalGridRows; i++)
                FormGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            for (int c = 0; c < totalGridCols; c++)
            {
                if (c % 3 == 1) // gap column
                    FormGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8) });
                else
                    FormGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
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

                // Label
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
                FormGrid.Children.Add(label);

                // Input control
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
                FormGrid.Children.Add(input);
            }
        }
    }
}

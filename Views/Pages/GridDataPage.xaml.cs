using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class GridDataPage : INavigableView<GridDataPageViewModel>
    {
        public GridDataPageViewModel ViewModel { get; }

        public GridDataPage(GridDataPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}

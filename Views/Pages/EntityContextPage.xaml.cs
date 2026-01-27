using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class EntityContextPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public EntityContextPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}

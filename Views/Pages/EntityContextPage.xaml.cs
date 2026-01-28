using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class EntityContextPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public EntityContextPage(DashboardViewModel viewModel, INavigationViewPageProvider pageProvider)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            RootNavigation.SetPageProviderService(pageProvider);
        }
    }
}

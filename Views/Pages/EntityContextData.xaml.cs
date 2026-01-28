using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class EntityContextData : INavigableView<EntityContextDataViewModel>
    {
        public EntityContextData(EntityContextDataViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }

        public EntityContextDataViewModel ViewModel { get; }
    }
}

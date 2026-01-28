using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class ItemDataPage : INavigableView<ItemDataPageViewModel>
    {
        public ItemDataPageViewModel ViewModel { get; }

        public ItemDataPage(ItemDataPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            this.LisBox.SelectedIndex = 0;


        }
    }
}

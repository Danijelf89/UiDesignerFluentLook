using UIDesignerWPFUI.Helpers;
using UIDesignerWPFUI.ViewModels.Pages;
using UIDesignerWPFUI.Views.Windows;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    public partial class LookupPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

        public LookupPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LocalizationWindow loc = new LocalizationWindow();
            loc.Owner = CurrentStateHelper.Mainwindow;
            loc.ShowDialog();
        }
    }
}

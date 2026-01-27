using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace UIDesignerWPFUI.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "WPF UI - UIDesignerWPFUI";

        [ObservableProperty] private ObservableCollection<object> _menuItems = new()
        {

            new NavigationViewItem()
            {
                Content = "Entity Context",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(Views.Pages.EntityContextPage)
            },

            new NavigationViewItem()
            {
            Content = "Lookup",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
            TargetPageType = typeof(Views.Pages.LookupPage),
            },

            new NavigationViewItem()
            {
                Content = "Menu Items",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.MenuItemsPage),
            }

    };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}

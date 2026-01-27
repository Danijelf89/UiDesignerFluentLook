using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIDesignerWPFUI.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;

namespace UIDesignerWPFUI.Views.Pages
{
    /// <summary>
    /// Interaction logic for ItemDataPage.xaml
    /// </summary>
    public partial class ItemDataPage : INavigableView<DashboardViewModel>
    {
        public ItemDataPage()
        {
            InitializeComponent();
        }

        public DashboardViewModel ViewModel { get; }
    }
}

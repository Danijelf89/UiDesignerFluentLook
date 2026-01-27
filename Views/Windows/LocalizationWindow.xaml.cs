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
using System.Windows.Shapes;

namespace UIDesignerWPFUI.Views.Windows
{
    /// <summary>
    /// Interaction logic for LocalizationWindow.xaml
    /// </summary>
    public partial class LocalizationWindow
    {
        public LocalizationWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { DragMove(); };
        }
    }
}

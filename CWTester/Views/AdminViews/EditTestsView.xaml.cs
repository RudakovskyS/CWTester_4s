using CWTester.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CWTester.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for EditTestsView.xaml
    /// </summary>
    public partial class EditTestsView : UserControl
    {
        EditTestsViewModel a = new EditTestsViewModel();
        public EditTestsView()
        {
            DataContext = a;
            InitializeComponent();
        }
        private void testsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            a.id = testsList.SelectedIndex;
        }
    }
}

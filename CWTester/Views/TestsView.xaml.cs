using CWTester.ViewModels;
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

namespace CWTester.Views
{
    /// <summary>
    /// Interaction logic for TestsView.xaml
    /// </summary>
    public partial class TestsView : UserControl
    {
        TestsViewModel a = new TestsViewModel();
        public TestsView()
        {
            InitializeComponent();
            DataContext = a;
        }
        private void testsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            a.id = testsList.SelectedIndex;
        }
    }
}

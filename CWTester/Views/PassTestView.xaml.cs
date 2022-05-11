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
    /// Interaction logic for PassTestView.xaml
    /// </summary>
    public partial class PassTestView : UserControl
    {
        PassTestViewModel a = new PassTestViewModel();
        public PassTestView()
        {
            DataContext = a;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Btn1.Content == a.CorrectAnswer.Text)
            {
                PassTestViewModel.Result++;
                Btn1.Background = Brushes.Green;
            }
            else
            {
                Btn1.Background = Brushes.Red;
            }
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Btn2.Content == a.CorrectAnswer.Text)
            {
                PassTestViewModel.Result++;
                Btn2.Background = Brushes.Green;
            }
            else
            {
                Btn2.Background = Brushes.Red;
            }
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Btn3.Content == a.CorrectAnswer.Text)
            {
                PassTestViewModel.Result++;
                Btn3.Background = Brushes.Green;
            }
            else
            {
                Btn3.Background = Brushes.Red;
            }
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Btn4.Content == a.CorrectAnswer.Text)
            {
                PassTestViewModel.Result++;
                Btn4.Background = Brushes.Green;
            }
            else
            {
                Btn4.Background = Brushes.Red;
            }
            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;
        }
    }
}

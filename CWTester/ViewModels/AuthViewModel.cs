using CWTester.SingletonView;
using CWTester.Commands;
using CWTester.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using CWTester.Views;

namespace CWTester.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        UserControl currentUserConrol;
        BaseViewModel curViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return curViewModel; }
            set
            {
                curViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public UserControl CurrentUserConrol
        {
            get { return currentUserConrol; }
            set
            {
                currentUserConrol = value;
                OnPropertyChanged("CurrentUserConrol");
            }
        }

        public AuthViewModel()
        {
            SingletonAuth.getInstance(this);
            CurrentViewModel = new LoginViewModel();
            CurrentUserConrol = new LogInView();
        }
        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}

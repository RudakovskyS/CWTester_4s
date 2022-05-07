using CWTester.Commands;
using CWTester.SingletonView;
using CWTester.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CWTester.ViewModels
{
    class MainViewModel : BaseViewModel
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
        public MainViewModel()
        {
            SingletonUser.getInstance(this);
            CurrentUserConrol = new WelcomeView();
        }

        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
        private Command openTestsUC;
        public ICommand OpenTestsUC
        {
            get
            {
                return openTestsUC ?? (openTestsUC = new Command(
                (obj) =>
                {
                    if (SingletonUser.getInstance(null).MainViewModel.CurrentViewModel != new TestsViewModel())
                    {
                        SingletonUser.getInstance(null).MainViewModel.CurrentViewModel = new TestsViewModel();
                    }

                }));
            }
        }
    }
}

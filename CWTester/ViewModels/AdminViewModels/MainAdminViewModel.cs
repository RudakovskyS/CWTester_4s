using CWTester.Commands;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CWTester.ViewModels.AdminViewModels
{
    public class MainAdminViewModel : BaseViewModel
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
        public MainAdminViewModel()
        {
            SingletonAdmin.getInstance(this);
            CurrentUserConrol = new WelcomeAdminView();
        }

        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
        private Command openTestsUC;
        //public ICommand OpenTestsUC
        //{
        //    get
        //    {
        //        return openTestsUC ?? (openTestsUC = new Command(
        //        (obj) =>
        //        {
        //            if (SingletonAdmin.getInstance(null).MainAdminViewModel. != new TestsViewModel())
        //            {
        //                SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new TestsViewModel();
        //                SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new TestsView();
        //            }

        //        }));
        //    }
        //}
    }
}

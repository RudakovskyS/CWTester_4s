using CWTester.Commands;
using CWTester.SingletonView;
using CWTester.Views;
using CWTester.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private Command createTestPage;
        public ICommand CreateTestPage
        {
            get
            {
                return createTestPage ??
                  (createTestPage = new Command(obj =>
                  {
                      try
                      {
                          SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new CreateTestViewModel();
                          SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new CreateTestView();
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command showUsers;
        public ICommand ShowUsers
        {
            get
            {
                return showUsers ??
                  (showUsers = new Command(obj =>
                  {
                      try
                      {
                          SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new AllUsersListViewModel();
                          SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new AllUsersListView();
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command openTestsUC;
        public ICommand OpenTestsUC
        {
            get
            {
                return openTestsUC ?? (openTestsUC = new Command(
                (obj) =>
                {
                    if (SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel != new ShowTestsViewModel())
                    {
                        SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new ShowTestsViewModel();
                        SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new ShowTestsView();
                    }

                }));
            }
        }
        private Command openResultsUC;
        public ICommand OpenResultsUC
        {
            get
            {
                return openResultsUC ?? (openResultsUC = new Command(
                (obj) =>
                {
                    if (SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel != new AdminResultsViewModel())
                    {
                        SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new AdminResultsViewModel();
                        SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new AdminResultView();
                    }

                }));
            }
        }
        private Command logOut;
        public ICommand LogOut
        {
            get
            {
                return logOut ?? (logOut = new Command(
                (obj) =>
                {
                    AuthView authView = new AuthView();
                    authView.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    authView.Show();
                    MainAdminViewModel.Close();

                }));
            }
        }

        private Command changeLanguage;
        public ICommand ChangeLanguage
        {
            get
            {
                return changeLanguage ?? (changeLanguage = new Command(
                (obj) =>
                {
                    if (App.Language == CultureInfo.GetCultureInfo("en-US"))
                    {
                        App.Language = CultureInfo.GetCultureInfo("ru-RU");
                    }
                    else
                    {
                        App.Language = CultureInfo.GetCultureInfo("en-US");
                    }
                }));
            }
        }
    }
}

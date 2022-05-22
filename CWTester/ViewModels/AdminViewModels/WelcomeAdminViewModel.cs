using CWTester.Commands;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels.AdminViewModels
{
    public class WelcomeAdminViewModel : BaseViewModel
    {
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
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
    }
}

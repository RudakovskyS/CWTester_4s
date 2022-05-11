using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels.AdminViewModels
{
    public class AdminResultsViewModel : BaseViewModel
    {
        public ObservableCollection<Tests> Tests { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<UserAuth> UserAuths { get; set; }
        public ObservableCollection<TestResults> TestResults { get; set; }
        public ObservableCollection<PassedTests> PassedTests { get; set; }
        private Command clearHistory;
        public ICommand ClearHistory
        {
            get
            {
                return clearHistory ??
              (clearHistory = new Command(obj =>
              {
                  try
                  {
                      using (TesterContext db = new TesterContext())
                      {
                          db.PassedTests.RemoveRange(db.PassedTests);
                          db.TestResults.RemoveRange(db.TestResults);
                          db.SaveChanges();
                      }
                      SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new AdminResultsViewModel();
                      SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new AdminResultView();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }));
            }
        }
        public AdminResultsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                PassedTests = new ObservableCollection<PassedTests>(db.PassedTests);
                TestResults = new ObservableCollection<TestResults>(db.TestResults);
                Tests = new ObservableCollection<Tests>(db.Tests);
                Users = new ObservableCollection<User>(db.Users);
                UserAuths = new ObservableCollection<UserAuth>(db.UserAuths);
            }
        }
    }
}

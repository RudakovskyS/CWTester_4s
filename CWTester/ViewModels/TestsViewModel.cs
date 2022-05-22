using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels
{
    public class TestsViewModel : BaseViewModel
    {
        public ObservableCollection<Tests> Tests { get; set; }
        private IEnumerable<Tests> searchedTests;
        public IEnumerable<Tests> SearchedTests
        {
            get { return searchedTests; }
            set
            {
                searchedTests = value;
                OnPropertyChanged("SearchedTests");
            }
        }

        public string searchText { get; set; }
        public static Tests SelectedTest { get; set; }
        public double TestResult { get; set; }
        public int id { get; set; }
        public static Tests CurrentTest { get; set; }
        public TestsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                try
                {

                    Tests = new ObservableCollection<Tests>(db.Tests);
                    SearchedTests = new ObservableCollection<Tests>(Tests);
                    foreach (var item in Tests)
                    {
                        if (new ObservableCollection<Questions>(db.Questions).Where(x => x.TestId == item.Id).Count() == 0)
                        {
                            db.Tests.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private Command passTest;
        public ICommand PassTest
        {
            get
            {
                return passTest ??
                  (passTest = new Command(obj =>
                  {
                      try
                      {
                          using (TesterContext db = new TesterContext())
                          {
                              try
                              {
                                  CurrentTest = new ObservableCollection<Tests>(db.Tests).Where(x => x.Id == SelectedTest.Id).FirstOrDefault();
                                  TestResult = new ObservableCollection<TestResults>(db.TestResults).Where(x =>
                                  x.UserId == LoginViewModel.user.Id).Average(x => x.Result);
                              }
                              catch (Exception)
                              {
                                  MessageBox.Show("Good luck at your first try!");
                              }
                              SingletonUser.getInstance(null).MainViewModel.CurrentViewModel = new PassTestViewModel();
                              SingletonUser.getInstance(null).MainViewModel.CurrentUserConrol = new PassTestView();

                          }
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command findByName;
        public ICommand FindByName
        {
            get
            {
                return findByName ??
                  (findByName = new Command(obj =>
                  {
                      try
                      {
                          SearchedTests = SearchedTests.Where(x => x.Name.Contains(searchText));
                          SingletonUser.getInstance(null).MainViewModel.CurrentViewModel = new TestsViewModel();
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

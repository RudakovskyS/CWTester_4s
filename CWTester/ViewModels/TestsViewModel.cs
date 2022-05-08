using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
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
        public int id { get; set; }
        private Tests selectedTest;
        public Tests SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
                OnPropertyChanged("SelectedTest");
            }
        }
        public TestsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                try
                {
                    Tests = new ObservableCollection<Tests>(db.Tests);
                    SearchedTests = new ObservableCollection<Tests>(Tests);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

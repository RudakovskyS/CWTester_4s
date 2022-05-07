using CWTester.DataBase;
using CWTester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.ViewModels
{
    public class TestsViewModel : BaseViewModel
    {
        ObservableCollection<Tests> Tests { get; set; }
        ObservableCollection<Tests> SearchedTests { get; set; }
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
                Tests = new ObservableCollection<Tests>(db.Tests);
                SearchedTests = new ObservableCollection<Tests>(db.Tests);
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

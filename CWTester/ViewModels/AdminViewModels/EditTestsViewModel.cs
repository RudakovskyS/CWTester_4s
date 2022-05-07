using CWTester.DataBase;
using CWTester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CWTester.ViewModels.AdminViewModels
{
    public class EditTestsViewModel : BaseViewModel
    {
        public ObservableCollection<Tests> Tests { get; set; }
        public ObservableCollection<Tests> SearchedTests { get; set; }
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
        public EditTestsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                try
                {
                    Tests = new ObservableCollection<Tests>(db.Tests);
                    SearchedTests = new ObservableCollection<Tests>(db.Tests);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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


using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels
{

    public class ResultsViewModel : BaseViewModel
    {
        public ObservableCollection<Tests> Tests { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<UserAuth> UserAuths { get; set; }
        public ObservableCollection<TestResults> TestResults { get; set; }
        public ObservableCollection<PassedTests> PassedTests { get; set; }
       
        public ResultsViewModel()
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

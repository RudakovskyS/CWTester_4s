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
        public User User { get; set; }
        public ObservableCollection<UserAuth> UserAuths { get; set; }
        public IEnumerable<TestResults> TestResults { get; set; }
        public ObservableCollection<PassedTests> PassedTests { get; set; }
       
        public ResultsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                User = new ObservableCollection<User>(db.Users).Where(x => x.Id == LoginViewModel.user.Id).First();
                TestResults = new ObservableCollection<TestResults>(db.TestResults).Where(x => x.User.Id == User.Id);
                PassedTests = new ObservableCollection<PassedTests>(db.PassedTests);
                Tests = new ObservableCollection<Tests>(db.Tests);
                UserAuths = new ObservableCollection<UserAuth>(db.UserAuths);
            }
        }
    }
}

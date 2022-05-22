using CWTester.DataBase;
using CWTester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CWTester.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public double AverageResult { get; set; }
        public UserAuth LoggedUser { get; set; }
        public ProfileViewModel()
        {
            using (TesterContext db = new TesterContext()) 
            {
                LoggedUser = LoginViewModel.user.UserAuth;
                try
                {
                    AverageResult = Math.Round(new ObservableCollection<TestResults>(db.TestResults).Where(x => x.UserId == LoginViewModel.user.Id).Average(x => x.Result), 1);

                }
                catch (Exception)
                {
                    AverageResult = 0;
                }
            }
        }
    }
}

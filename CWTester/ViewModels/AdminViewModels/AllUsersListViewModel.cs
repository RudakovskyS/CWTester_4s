using CWTester.DataBase;
using CWTester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.ViewModels.AdminViewModels
{
    public class AllUsersListViewModel : BaseViewModel
    {
        public ObservableCollection<UserAuth> UserAuths { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public bool isAdmin { get; set; }
        public AllUsersListViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                Users = new ObservableCollection<User>(db.Users);
                UserAuths = new ObservableCollection<UserAuth>(db.UserAuths);
            }
        }
    }
}

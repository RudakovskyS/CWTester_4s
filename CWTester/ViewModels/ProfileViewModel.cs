using CWTester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public UserAuth LoggedUser { get; set; }
        public ProfileViewModel()
        {
            LoggedUser = LoginViewModel.user.UserAuth;
        }
    }
}

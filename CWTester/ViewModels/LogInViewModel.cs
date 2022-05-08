using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.PasswordEncryptor;
using CWTester.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CWTester.Views.AdminViews;

namespace CWTester.ViewModels
{

    public class LoginViewModel : BaseViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public Command authCommand;
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                this.errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        public ICommand AuthCommand
        {
            get
            {
                return authCommand ??
                 (authCommand = new Command(obj =>
                 {
                     try
                     {
                         using (TesterContext db = new TesterContext())
                         {
                             User user = null;
                             int authUserId;
                             password = Encryptor.Encrypt(password);
                             authUserId = db.UserAuths.Where(a => a.Login == login && a.Password == password).FirstOrDefault() == null ? 0 : db.UserAuths.Where(a => a.Login == login && a.Password == password).FirstOrDefault().Id;
                             user = db.Users.Where(a => a.Id == authUserId).FirstOrDefault();
                             if (user == null)
                             {
                                 throw new Exception("Невозможно найти пользователя с введенными данными");
                             }
                             if (user.Role == "User")
                             {
                                 MainWindow main = new MainWindow();
                                 main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                 main.Show();
                                 AuthViewModel.Close();

                             }
                             if (user.Role == "Admin")
                             {
                                 MainAdminWindow main = new MainAdminWindow();
                                 main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                 main.Show();
                                 AuthViewModel.Close();
                             }
                         }
                     }
                     catch (Exception e)
                     {
                         ErrorMessage = e.Message;
                     }
                 }));
            }
        }
        public Command openRegCommand;
        public ICommand OpenRegCommand
        {
            get
            {
                return openRegCommand ??
                 (openRegCommand = new Command(obj =>
                 {
                     SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new RegViewModel();
                     SingletonAuth.getInstance(null).StartViewModel.CurrentUserConrol = new RegView();

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


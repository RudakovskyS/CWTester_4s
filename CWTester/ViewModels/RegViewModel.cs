using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.PasswordEncryptor;
using CWTester.SingletonView;
using CWTester.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels
{
    public class RegViewModel : BaseViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        private string errorMes;
        public string ErrorMessage
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        private Command backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new Command(obj =>
                  {
                      try
                      {
                          SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new LoginViewModel();
                          SingletonAuth.getInstance(null).StartViewModel.CurrentUserConrol = new LogInView();
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        public Command regCommand;
        public ICommand RegCommand
        {
            get
            {
                return regCommand ??
                 (regCommand = new Command(obj =>
                 {
                     try
                     {
                         using (TesterContext db = new TesterContext())
                         {
                             User user = new User();
                             UserAuth userAuth = new UserAuth();
                             user.UserAuthId = userAuth.Id;
                             userAuth.Login = login;
                             if (password != confirmPassword)
                             {
                                 throw new Exception("Пароли не совпадают");
                             }
                             if (password != null & password[0] != ' ')
                             {
                                 password = Encryptor.Encrypt(password);
                                 userAuth.Password = password;
                             }
                             else
                             {
                                 throw new Exception("Не верный формат пароля");
                             }
                                 user.Role = "User";
                             if (login != null && password != null && confirmPassword != null)
                             {
                                 if (db.Users.Any(a => a.UserAuth.Login == login))
                                 {
                                     throw new Exception("Пользователь с такими данными уже существует");
                                 }
                                 else
                                 {
                                     db.Users.Add(user);
                                     db.UserAuths.Add(userAuth);
                                     db.SaveChanges();
                                     SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new LoginViewModel();
                                     SingletonAuth.getInstance(null).StartViewModel.CurrentUserConrol = new LogInView();

                                 }
                             }
                         }
                     }
                     catch (DbEntityValidationException e)
                     {
                         foreach (DbEntityValidationResult validationRes in e.EntityValidationErrors)
                         {
                             foreach (DbValidationError err in validationRes.ValidationErrors)
                             {
                                 ErrorMessage = err.ErrorMessage;
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
    }
}

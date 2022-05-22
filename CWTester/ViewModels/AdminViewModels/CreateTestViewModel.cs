using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels.AdminViewModels
{
    public class CreateTestViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private Command addTest;
        public ICommand AddTest
        {
            get
            {
                return addTest ??
                (addTest = new Command(obj =>
                {
                    try
                    {
                        using (TesterContext db = new TesterContext())
                        {
                            if(Name == null) 
                            {
                                throw new Exception("Name is too short!");
                            }
                            Tests test = new Tests();
                            test.Name = Name;
                            test.Description = Description;
                            if (db.Tests.Any(x => x.Name == test.Name))
                            {
                                throw new Exception("Test with this name already exists");
                            }
                            db.Tests.Add(test);
                            db.SaveChanges();
                            SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new AddQuestionsViewModel();
                            SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new AddQuestionsView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
    }
}

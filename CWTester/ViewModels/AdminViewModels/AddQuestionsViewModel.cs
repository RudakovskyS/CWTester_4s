using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWTester.ViewModels.AdminViewModels
{
    public class AddQuestionsViewModel : BaseViewModel
    {
        private Tests test;
        public Tests Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }
        public string Question { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        private string selectedFile;
        public string SelectedFile 
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                OnPropertyChanged("SelectedFile");
            }
        }
        private Command addImage;
        public ICommand AddImage
        {
            get
            {
                return addImage ??
                  (addImage = new Command(obj =>
                  {
                      try
                      {
                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                          openFileDialog.ShowDialog();
                          SelectedFile = openFileDialog.FileName;
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command addQuestion;
        public ICommand AddQuestion
        {
            get
            {
                return addQuestion ??
                (addQuestion = new Command(obj =>
                {
                    try
                    {
                        using (TesterContext db = new TesterContext())
                        {
                            Test = new ObservableCollection<Tests>(db.Tests).Last();

                            Media media = new Media();
                            media.Path = SelectedFile;
                            Questions question = new Questions();
                            question.TestId = Test.Id;
                            question.Text = Question;
                            question.Tests = Test;
                            question.Media = media;
                            Answers firstAnswer = new Answers();
                            firstAnswer.Text = FirstAnswer;
                            firstAnswer.IsCorrect = false;
                            firstAnswer.Questions = question;
                            Answers secondAnswer = new Answers();
                            secondAnswer.Text = SecondAnswer;
                            secondAnswer.IsCorrect = false;
                            secondAnswer.Questions = question;
                            Answers thirdAnswer = new Answers();
                            thirdAnswer.Text = ThirdAnswer;
                            thirdAnswer.IsCorrect = false;
                            thirdAnswer.Questions = question;
                            Answers correctAnswer = new Answers();
                            correctAnswer.Text = CorrectAnswer;
                            correctAnswer.IsCorrect = true;
                            correctAnswer.Questions = question;
                            
                            
                            db.Questions.Add(question);
                            db.Answers.Add(firstAnswer);
                            db.Answers.Add(secondAnswer);
                            db.Answers.Add(thirdAnswer);
                            db.Answers.Add(correctAnswer);
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

using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CWTester.Views;

namespace CWTester.ViewModels
{
    
        
    
    class PassTestViewModel : BaseViewModel
    {
        public IEnumerable<Questions> Questions { get; set; }
        public Questions CurrentQuestion { get; set; }
        public IEnumerable<Answers> Answers { get; set; }
        public Answers FirstAnswer { get; set; }
        public Answers SecondAnswer { get; set; }
        public Answers ThirdAnswer { get; set; }
        public Answers FourthAnswer { get; set; }
        public Answers CorrectAnswer { get; set; }
        public static int id { get; set; }
        public Tests Test { get; set; }
        private Command giveAnswer;
        
        public PassTestViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                Questions = new ObservableCollection<Questions>(db.Questions);
                CurrentQuestion = Questions.ElementAt(id);
                Answers = new ObservableCollection<Answers>(db.Answers).Where(x => x.Questions.Id == CurrentQuestion.Id);
                //Questions = new ObservableCollection<Questions>(db.Questions).Where(x => x.Tests.Id == Test.Id);
                Answers = Shuffle(Answers.ToList());
                FirstAnswer = Answers.ElementAt(0);
                SecondAnswer = Answers.ElementAt(1);
                ThirdAnswer = Answers.ElementAt(2);
                FourthAnswer = Answers.ElementAt(3);
                CorrectAnswer = Answers.Where(x => x.IsCorrect).First();
            }
        }
        public IList<T> Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        public ICommand GiveAnswer
        {
            get
            {
                return giveAnswer ??
              (giveAnswer = new Command(obj =>
              {
                  try
                  {
                      
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }));
            }
        }
        private Command toNextQuestion;
        public ICommand ToNextQuestion
        {
            get
            {
                return toNextQuestion ??
              (toNextQuestion = new Command(obj =>
              {
                  try
                  {
                      if (id < Questions.Count() - 1)
                      {
                          id++;
                          SingletonUser.getInstance(null).MainViewModel.CurrentViewModel = new PassTestViewModel();
                          SingletonUser.getInstance(null).MainViewModel.CurrentUserConrol = new PassTestView();
                      }
                      else
                      {
                          SingletonUser.getInstance(null).MainViewModel.CurrentViewModel = new TestsViewModel();
                          SingletonUser.getInstance(null).MainViewModel.CurrentUserConrol = new TestsView();
                          id = 0;
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

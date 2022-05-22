using CWTester.Commands;
using CWTester.DataBase;
using CWTester.Models;
using CWTester.SingletonView;
using CWTester.Views.AdminViews;
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
    public class ShowTestsViewModel : BaseViewModel
    {
        private ObservableCollection<Tests> tests;
        
        public ObservableCollection<Tests> Tests 
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged("Tests");
            }
        }
        public Tests TestToDelete { get; set; }
        private IEnumerable<Tests> searchedTests;
        public IEnumerable<Questions> SearchedQuestions { get; set; }
        public IEnumerable<Answers> SearchedAnswers { get; set; }
        public IEnumerable<PassedTests> SearchedPassedTests { get; set; }
        public IEnumerable<Media> SearchedMedia { get; set; }
        public IEnumerable<TestResults> SearchedResults { get; set; }
        public IEnumerable<Tests> SearchedTests
        {
            get { return searchedTests; }
            set
            {
                searchedTests = value;
                OnPropertyChanged("SearchedTests");
            }
        }
        public string searchText { get; set; }
        public int id { get; set; }
        private Tests selectedTest;
        public Tests SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
                OnPropertyChanged("SelectedTest");
            }
        }
        private Command deleteTest;
        public ICommand Delete
        {
            get
            {
                return deleteTest ??
                  (deleteTest = new Command(obj =>
                  {
                      try
                      {
                          using (TesterContext db = new TesterContext())
                          {
                              SearchedTests = new ObservableCollection<Tests>(db.Tests);
                              SearchedQuestions = new ObservableCollection<Questions>(db.Questions);
                              SearchedResults = new ObservableCollection<TestResults>(db.TestResults);
                              SearchedPassedTests = new ObservableCollection<PassedTests>(db.PassedTests);
                              SearchedAnswers = new ObservableCollection<Answers>(db.Answers);
                              SearchedMedia = new ObservableCollection<Media>(db.Medias);
                              db.Answers.RemoveRange(SearchedAnswers.Where(x => x.Questions.Tests.Id == Tests[id].Id));
                              foreach (var questionItem in SearchedQuestions.Where(x => x.Tests.Id == Tests[id].Id))
                              {
                                  foreach (var mediaItem in SearchedMedia)
                                  {
                                      if (questionItem.MediaId == mediaItem.Id)
                                          db.Medias.Remove(mediaItem);
                                  }
                              }
                              db.TestResults.RemoveRange(SearchedResults.Where(x => x.PassedTests.Tests.Id == Tests[id].Id));
                              db.PassedTests.RemoveRange(SearchedPassedTests.Where(x => x.TestId == Tests[id].Id));
                              db.Tests.Remove(SearchedTests.First(x => x.Name == Tests[id].Name));
                              db.SaveChanges();
                              SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new ShowTestsViewModel();
                              SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentUserConrol = new ShowTestsView();
                          }
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        public ShowTestsViewModel()
        {
            using (TesterContext db = new TesterContext())
            {
                try
                {
                    Tests = new ObservableCollection<Tests>(db.Tests);
                    SearchedTests = new ObservableCollection<Tests>(Tests);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private Command findByName;
        public ICommand FindByName
        {
            get
            {
                return findByName ??
                  (findByName = new Command(obj =>
                  {
                      try
                      {
                          SearchedTests = SearchedTests.Where(x => x.Name.Contains(searchText));
                          SingletonAdmin.getInstance(null).MainAdminViewModel.CurrentViewModel = new ShowTestsViewModel();
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
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


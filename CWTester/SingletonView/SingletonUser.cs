using CWTester.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.SingletonView
{
    class SingletonUser
    {
        private static SingletonUser instance;
        public MainViewModel MainViewModel { get; set; }
        private SingletonUser(MainViewModel mainView)
        {
            MainViewModel = mainView;
        }
        public static SingletonUser getInstance(MainViewModel mainViewModel = null)
        {
            return instance ?? (instance = new SingletonUser(mainViewModel));
        }
    }
}

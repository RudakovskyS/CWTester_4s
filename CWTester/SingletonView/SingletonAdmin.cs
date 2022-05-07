using CWTester.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.SingletonView
{
    public class SingletonAdmin
    {
        private static SingletonAdmin instance;
        public MainAdminViewModel StartViewModel { get; set; }
        public object MainAdminVM { get; internal set; }
        public object MainAdminViewModel { get; internal set; }

        private SingletonAdmin(MainAdminViewModel startView)
        {
            StartViewModel = startView;
        }
        public static SingletonAdmin getInstance(MainAdminViewModel startViewModel = null)
        {
            return instance ?? (instance = new SingletonAdmin(startViewModel));
        }
    }
}

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
        public MainAdminViewModel MainAdminViewModel { get; set; }

        private SingletonAdmin(MainAdminViewModel startView)
        {
            MainAdminViewModel = startView;
        }
        public static SingletonAdmin getInstance(MainAdminViewModel startViewModel = null)
        {
            return instance ?? (instance = new SingletonAdmin(startViewModel));
        }
    }
}

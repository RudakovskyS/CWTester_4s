﻿using CWTester.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CWTester.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for AllUsersListView.xaml
    /// </summary>
    public partial class AllUsersListView : UserControl
    {
        AllUsersListViewModel a = new AllUsersListViewModel();
        public AllUsersListView()
        {
            DataContext = a;
            InitializeComponent();
        }
    }
}

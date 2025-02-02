﻿using ProjectMvvmByErm.ModelView;
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
using System.Windows.Shapes;

namespace ProjectMvvmByErm.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowMenu.xaml
    /// </summary>
    public partial class MainWindowMenu : Window
    {
        public static ListView AllDepartmentsView;
        public static ListView AllUsersView;
        public static ListView AllPositionsView;
        public MainWindowMenu()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllDepartmentsView = ViewAllDepartments;
            AllUsersView = ViewAllUsers;
            AllPositionsView = ViewAllPositions;
        }
    }
}

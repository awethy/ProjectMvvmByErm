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
    /// Логика взаимодействия для AddNewDepartmentWindow.xaml
    /// </summary>
    public partial class AddNewDepartmentWindow : Window
    {
        public AddNewDepartmentWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}

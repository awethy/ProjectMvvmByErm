using ProjectMvvmByErm.Model;
using ProjectMvvmByErm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectMvvmByErm.ModelView
{
    public class DataManageVM :INotifyPropertyChanged
    {
        //все отделы
        private List<Department> allDepartments = DataWorker.GetAllDepartments();
        public List<Department> AllDepartments
        {   
            get { return allDepartments; }
            set { allDepartments = value; NotifyPropertyChanged("AllDepartments"); }
        }

        //все пользователи
        private List<User> allUsers = DataWorker.GetAllUsers(); 
        public List<User> AllUsers
        {
            get { return allUsers; }
            set { allUsers = value; NotifyPropertyChanged("AllUsers"); }
        }

        //все позиции
        private List<Position> allPositions = DataWorker.GetAllPositions();
        public List<Position> AllPositions
        {
            get { return allPositions; }
            set { allPositions = value; NotifyPropertyChanged("AllPositions"); }
        }

        //методы открытия оконw
        private void OpenAddDepartmentWindow()
        {
            AddNewDepartmentWindow addNewDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(addNewDepartmentWindow);
        }

        private void OpenAddUserWindow()
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(addNewUserWindow);
        }

        private void OpenAddPositionWindow()
        {
            AddNewPositionWindow addNewPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(addNewPositionWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}

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
using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectMvvmByErm.ModelView
{
    public class DataManageVM : INotifyPropertyChanged
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

        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserPosId { get; set; }

        #region КОММАНДЫ СОЗДАНИЯ, УДАЛЕНИЕ И ИЗМЕНЕНИЯ ПОЗИЦИЙ

        private RelayCommand addNewDepartment;
        public RelayCommand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RelayCommand(obj =>
                {
                    Window win = obj as Window;
                    string resultStr = "";
                    if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(win, "NameTextBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateDepartment(DepartmentName);
                        UpdateAllViews();
                        SetNullValuesToProperties();
                        win.Close();
                    }
                }
                );
            }
        }

        private RelayCommand addNewUser;
        public RelayCommand AddNewUser
        {
            get
            {
                return addNewUser ?? new RelayCommand(obj =>
                {
                    Window win = obj as Window;
                    string resultStr = "";
                    if (UserName == null || UserName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(win, "NameTextBlock");
                    }
                    else
                    {
                        //resultStr = DataWorker.CreateUser(UserName, UserPhone, UserPosId);
                        UpdateAllViews();
                        SetNullValuesToProperties();
                        win.Close();
                    }
                }
                );
            }
        }

        #endregion

        #region КОММАНДЫ ОТКРЫТИЯ ОКОН
        private RelayCommand openAddNewUserWin;
        public RelayCommand OpenAddNewUserWin
        {
            get
            {
                return openAddNewUserWin ?? new RelayCommand(obj =>
                {
                    OpenAddUserWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewPositionWin;
        public RelayCommand OpenAddNewPositionWin
        {
            get
            {
                return openAddNewPositionWin ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewDepartmentWin;
        public RelayCommand OpenAddNewDepartmentWin
        {
            get
            {
                return openAddNewDepartmentWin ?? new RelayCommand(obj =>
                {
                    OpenAddDepartmentWindowMethod();
                }
                );
            }
        }
        #endregion

        #region МЕТОДЫ ОТКРЫТИЯ ОКОН WW
        //методы открытия оконw
        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow addNewDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(addNewDepartmentWindow);
        }

        private void OpenAddUserWindowMethod()
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(addNewUserWindow);
        }

        private void OpenAddPositionWindowMethod()
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
        #endregion

        private void SetRedBlockControll(Window win, string blockName)
        {
            Control block = win.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #region UPDATE VIEWS
        private void SetNullValuesToProperties()
        {
            //для пользователей

            //для позиций

            //для отделов
            DepartmentName = null;
        }


        private void UpdateAllViews()
        {
            UpadateAllDepartmentsView();
            UpadateAllUsersView();
            UpadateAllUsersView();
        }

        private void UpadateAllDepartmentsView()
        {
            AllDepartments = DataWorker.GetAllDepartments();
            MainWindowMenu.AllDepartmentsView.ItemsSource = null;
            MainWindowMenu.AllDepartmentsView.Items.Clear();
            MainWindowMenu.AllDepartmentsView.ItemsSource = AllDepartments;
            MainWindowMenu.AllDepartmentsView.Items.Refresh();
        }

        private void UpadateAllUsersView()
        {
            AllUsers = DataWorker.GetAllUsers();
            MainWindowMenu.AllUsersView.ItemsSource = null;
            MainWindowMenu.AllUsersView.Items.Clear();
            MainWindowMenu.AllUsersView.ItemsSource = AllUsers;
            MainWindowMenu.AllUsersView.Items.Refresh();
        }

        private void UpadateAllPositionsView()
        {
            AllPositions = DataWorker.GetAllPositions();
            MainWindowMenu.AllPositionsView.ItemsSource = null;
            MainWindowMenu.AllPositionsView.Items.Clear();
            MainWindowMenu.AllPositionsView.ItemsSource = AllUsers;
            MainWindowMenu.AllPositionsView.Items.Refresh();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}

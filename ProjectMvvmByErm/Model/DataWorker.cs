using Microsoft.VisualBasic.ApplicationServices;
using ProjectMvvmByErm.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvmByErm.Model
{
    public class DataWorker
    {
        //получение всех позиций
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }           
        }

        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        //создание позиций>
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Departments.Any(el => el.Name == name);
                if (!checkExist)
                {
                    Department newDepartment = new Department 
                    { 
                        Name = name
                    };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Успешно!";
                }
                return result;
            }
        }

        public static string CreatePosition(string name, decimal salary, Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Departments.Any(el => el.Name == name);
                if (!checkExist)
                {
                    Position newPosition = new Position 
                    { 
                        Name = name,
                        Salary = salary,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Успешно!";
                }
                return result;
            }
        }

        public static string CreateUser(string name, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Departments.Any(el => el.Name == name);
                if (!checkExist)
                {
                    User newUser = new User 
                    { 
                        Name = name,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Успешно!";
                }
                return result;
            }
        }
        //удаление позиций>
        public static string DeleteDepartment(Department department)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Успешно! Позиция " + department.Name + "удалена.";
            }
            return result;
        }

        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Успешно! Позиция " + position.Name + "удалена.";
            }
            return result;
        }

        public static string DeleteUser(User user)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Успешно! Позиция " + user.Name + "удалена.";
            }
            return result;
        }
        //изменение позиций
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Успешно! Позиция " + department.Name + "изменена.";
            }
            return result;
        }

        public static string EditPosition(Position oldPosition, string newName, decimal newSalary, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(d => d.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.Department = newDepartment;
                db.SaveChanges();
                result = "Успешно! Позиция " + position.Name + "изменена.";
            }
            return result;
        }

        public static string EditUser(User oldUser, string newName, string newPhone, Position newPosition)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(d => d.Id == oldUser.Id);
                user.Name = newName;
                user.Phone = newPhone;
                user.Position = newPosition;
                db.SaveChanges();
                result = "Успешно! Позиция " + user.Name + "изменена.";
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeCard.DataBaseClasses;

namespace EmployeeCard
{
    static class Manipulate
    {
        static Organisation org;
        static MainWindow mainWindow;
        public static void Init(MainWindow window)
        {
            FillOrgStructure();
            mainWindow = window;
            mainWindow.lbDepartments.ItemsSource = org.Departments;
            mainWindow.lbDepartments.SelectionChanged += LbDepartments_SelectionChanged;
            //if (org.Departments.Count > 0)
            //  mainWindow.lbDepartments.ItemsSource = org.Departments;
        }

        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.lbEmployees.ItemsSource = (mainWindow.lbDepartments.SelectedItem as Department).Employees;
        }

        private static void FillOrgStructure()
        {
            org = new Organisation("MyCompany");
            org.AddDeparment(new Department("Main Department"));
            org.Departments[0].AddEmployee(new Programmer("Nikolay", "Dontsov", new DateTime(1990, 12, 22), new Passport("3243", "34234")));
            org.AddDeparment(new Department("Second Department"));
            org.Departments[1].AddEmployee(new Programmer("Vasilyi", "Pupkin", new DateTime(1920, 12, 22), new Passport("3243", "34234")));
        }
    }
}

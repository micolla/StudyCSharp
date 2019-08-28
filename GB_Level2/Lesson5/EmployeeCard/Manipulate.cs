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
            window.btnAddDepartment.Click += BtnAddDepartment_Click;
            window.btnAddEmployee.Click += BtnAddEmployee_Click;
            window.btnEditEmployee.Click += BtnEditEmployee_Click;
            //if (org.Departments.Count > 0)
            //  mainWindow.lbDepartments.ItemsSource = org.Departments;
        }

        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department));
        }

        private static void FillOrgStructure()
        {
            org = new Organisation("MyCompany");
            org.AddDeparment(new Department("Main Department"));
            org.AddEmployee(
                new Programmer("Nikolay", "Dontsov", new DateTime(1990, 12, 22), new Passport("3243", "34234"),org.Departments[0])
                );
            org.AddDeparment(new Department("Second Department"));
            org.AddEmployee(
                new Programmer("Vasilyi", "Pupkin", new DateTime(1920, 12, 22), new Passport("3243", "34234"), org.Departments[1])
                );
        }
    }
}

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
            mainWindow.lbEmployees.SelectionChanged += LbEmployees_SelectionChanged;
            window.btnAddDepartment.Click += BtnAddDepartment_Click;
            window.btnAddEmployee.Click += BtnAddEmployee_Click;
            window.btnEditEmployee.Click += BtnEditEmployee_Click;
        }

        private static void LbEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.btnEditEmployee.Visibility = mainWindow.lbEmployees.SelectedItem != null ? Visibility.Visible : Visibility.Hidden;
        }

        private static void FillOrgStructure()
        {
            org = new Organisation("MyCompany");
            org.AddDeparment(new Department("Main Department"));
            org.AddEmployee(
                new Programmer("Nikolay", "Dontsov", new DateTime(1990, 12, 22), new Passport("3243", "34234"), org.Departments[0])
                );
            org.AddDeparment(new Department("Second Department"));
            org.AddEmployee(
                new Programmer("Vasilyi", "Pupkin", new DateTime(1920, 12, 22), new Passport("3243", "34234"), org.Departments[1])
                );
        }
        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.tbFirstName.IsEnabled = false;
            employeeWindow.tbSecondName.IsEnabled = false;
            employeeWindow.tbSerial.IsEnabled = false;
            employeeWindow.tbNumber.IsEnabled = false;
            employeeWindow.dpBirthDay.IsEnabled = false;
            employeeWindow.cbDocumentType.IsEnabled = false;
            Employee curEmp = mainWindow.lbEmployees.SelectedItem as Employee;
            employeeWindow.tbFirstName.Text = curEmp.FirstName;
            employeeWindow.tbSecondName.Text = curEmp.SecondName;
            employeeWindow.tbSerial.Text = curEmp.EmployeeDocument.Serial;
            employeeWindow.tbNumber.Text = curEmp.EmployeeDocument.Number;
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentType));
            employeeWindow.cbDocumentType.SelectedItem = curEmp.EmployeeDocument.documentType;
            employeeWindow.dpBirthDay.SelectedDate =curEmp.BirthDay;
            employeeWindow.cbDepartment.ItemsSource= org.Departments;
            employeeWindow.cbDepartment.SelectedItem = curEmp.Department;
            employeeWindow.btnCancel.Click += (o, h) => employeeWindow.Close();
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentType));
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue && employeeWindow.cbDocumentType.SelectedItem != null
                && !String.IsNullOrEmpty(employeeWindow.tbSerial.Text) && !String.IsNullOrEmpty(employeeWindow.tbNumber.Text)
                && (employeeWindow.cbDepartment.SelectedItem as Department)!=curEmp.Department)
                {
                    var r = curEmp.Department;
                    curEmp.ChangeDepartment(employeeWindow.cbDepartment.SelectedItem as Department);
                    mainWindow.lbEmployees.ItemsSource = org.GetEmployees(r);
                    employeeWindow.Close();
                }
                else
                    MessageBox.Show("Заполните все параметры");
            };
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
        }

        private static void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.btnCancel.Click += (o, h) => employeeWindow.Close();
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentType));
            employeeWindow.cbDocumentType.ItemsSource = org.Departments;
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue && employeeWindow.cbDocumentType.SelectedItem != null
                && !String.IsNullOrEmpty(employeeWindow.tbSerial.Text) && !String.IsNullOrEmpty(employeeWindow.tbNumber.Text))
                {
                    org.AddEmployee(new Programmer(
                      employeeWindow.tbFirstName.Text
                      , employeeWindow.tbSecondName.Text
                      , employeeWindow.dpBirthDay.SelectedDate.Value
                      , (Document.DocumentType)employeeWindow.cbDocumentType.SelectedItem
                      , employeeWindow.tbSerial.Text, employeeWindow.tbSecondName.Text
                      , (mainWindow.lbDepartments.SelectedItem as Department)
                      )
                      );
                    mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department));
                    employeeWindow.Close();
                }
                else
                    MessageBox.Show("Заполните все параметры");
            };
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
        }

        private static void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow();
            departmentWindow.btnCancel.Click += (o, h) => departmentWindow.Close();
            departmentWindow.btnAddDepartment.Click += (o, h) =>
            {
                org.AddDeparment(new Department(departmentWindow.tbDeparmentName.Text));
                departmentWindow.Close();
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
        }

        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department));
            mainWindow.btnAddEmployee.Visibility = Visibility.Visible;
            mainWindow.btnEditDepartment.Visibility = mainWindow.lbDepartments.SelectedItem != null ? Visibility.Visible : Visibility.Hidden;
        }
    }
}

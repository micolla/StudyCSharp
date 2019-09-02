using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeCard.DataBaseClasses;
using System.IO;

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
            using (StreamReader streamReader = new StreamReader("InfoBase/departments.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    org.AddDeparment(new Department(streamReader.ReadLine()));
                }
            }
            using (StreamReader streamReader = new StreamReader("InfoBase/employee.csv"))
            {
                string[] emp;
                int deptId;
                while (!streamReader.EndOfStream)
                {
                    emp=streamReader.ReadLine().Split(';');
                    if (emp.Length == 7)
                    {
                        deptId = (from d in org.Departments where d.DepartmentName == emp[6] select d.DepartmentId).First();
                        org.AddEmployee(new Employee(emp[0],emp[1]
                            ,DateTime.Parse(emp[2],System.Globalization.CultureInfo.CurrentCulture)
                            ,(Document.DocumentTypes)Enum.Parse(typeof(Document.DocumentTypes),emp[3])
                            , emp[4], emp[5]
                            , deptId));
                    }
                }
            }
            /*org.AddDeparment(new Department("Main Department"));
            org.AddEmployee(
                new Programmer("Nikolay", "Dontsov", new DateTime(1990, 12, 22)
                , new Document("3243", "34234",Document.DocumentTypes.Passport), org.Departments[0].DepartmentId)
                );
            org.AddDeparment(new Department("Second Department"));
            org.AddEmployee(
                new Programmer("Vasilyi", "Pupkin", new DateTime(1920, 12, 22)
                , new Document("3243", "34234", Document.DocumentTypes.DriverLicense), org.Departments[1].DepartmentId)
                );*/
        }
        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            Employee curEmp = mainWindow.lbEmployees.SelectedItem as Employee;
            employeeWindow.tbFirstName.Text = curEmp.FirstName;
            employeeWindow.tbSecondName.Text = curEmp.SecondName;
            employeeWindow.tbSerial.Text = curEmp.EmployeeDocument.Serial;
            employeeWindow.tbNumber.Text = curEmp.EmployeeDocument.Number;
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentTypes));
            employeeWindow.cbDocumentType.SelectedItem = curEmp.EmployeeDocument.DocumentType;
            employeeWindow.dpBirthDay.SelectedDate =curEmp.BirthDay;
            employeeWindow.cbDepartment.ItemsSource= org.Departments;
            employeeWindow.cbDepartment.SelectedItem = org.Departments.First(d=>d.DepartmentId == curEmp.Departmentid);
            employeeWindow.btnCancel.Click += (o, h) => employeeWindow.Close();
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentTypes));
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue && employeeWindow.cbDocumentType.SelectedItem != null
                && !String.IsNullOrEmpty(employeeWindow.tbSerial.Text) && !String.IsNullOrEmpty(employeeWindow.tbNumber.Text))
                {
                    curEmp.ChangePersonalInfo(employeeWindow.tbFirstName.Text
                      , employeeWindow.tbSecondName.Text
                      , employeeWindow.dpBirthDay.SelectedDate.Value
                      , (Document.DocumentTypes)employeeWindow.cbDocumentType.SelectedItem
                      , employeeWindow.tbSerial.Text, employeeWindow.tbNumber.Text
                      , (employeeWindow.cbDepartment.SelectedItem as Department).DepartmentId);
                    mainWindow.lbEmployees.ItemsSource = org.GetEmployees(curEmp.Departmentid);
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
            employeeWindow.cbDocumentType.ItemsSource = Enum.GetValues(typeof(Document.DocumentTypes));
            employeeWindow.cbDepartment.ItemsSource = org.Departments;
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue && employeeWindow.cbDocumentType.SelectedItem != null
                && !String.IsNullOrEmpty(employeeWindow.tbSerial.Text) && !String.IsNullOrEmpty(employeeWindow.tbNumber.Text))
                {
                    if (org.AddEmployee(new Employee(
                      employeeWindow.tbFirstName.Text
                      , employeeWindow.tbSecondName.Text
                      , employeeWindow.dpBirthDay.SelectedDate.Value
                      , (Document.DocumentTypes)employeeWindow.cbDocumentType.SelectedItem
                      , employeeWindow.tbSerial.Text, employeeWindow.tbNumber.Text
                      , (employeeWindow.cbDepartment.SelectedItem as Department).DepartmentId
                      )))
                    {
                        mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department).DepartmentId);
                        employeeWindow.Close();
                    }
                    else
                        MessageBox.Show("Такой сотрудник уже есть");
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
                if (org.AddDeparment(new Department(departmentWindow.tbDeparmentName.Text)))
                    departmentWindow.Close();
                else MessageBox.Show("Такой отдел уже есть");
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
        }

        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department).DepartmentId);
            mainWindow.btnAddEmployee.Visibility = Visibility.Visible;
            mainWindow.btnEditDepartment.Visibility = mainWindow.lbDepartments.SelectedItem != null ? Visibility.Visible : Visibility.Hidden;
        }
    }
}

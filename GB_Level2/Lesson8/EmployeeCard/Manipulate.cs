using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeCard.DataBaseClasses;
using System.IO;
using System.Net.Http;

namespace EmployeeCard
{
    static class Manipulate
    {
        static Organisation org;
        static MainWindow mainWindow;
        static HttpClient httpClient;
        static string baseAddress;
        public static void Init(MainWindow window)
        {
            baseAddress = @"https://localhost:44315/";
            httpClient = new HttpClient();
            org = new Organisation("My Company");
            
            mainWindow = window;
            RefreshDepartments();
            mainWindow.lbDepartments.ItemsSource = org.Departments;
            mainWindow.lbDepartments.ItemsSource = org.Employees;
            mainWindow.lbDepartments.SelectionChanged += LbDepartments_SelectionChanged;
            mainWindow.lbEmployees.SelectionChanged += LbEmployees_SelectionChanged;
            mainWindow.btnAddDepartment.Click += BtnAddDepartment_Click;
            mainWindow.btnAddEmployee.Click += BtnAddEmployee_Click;
            mainWindow.btnEditEmployee.Click += BtnEditEmployee_Click;
            mainWindow.btnEditDepartment.Click += BtnEditDepartment_Click;
            mainWindow.btnRefreshDepts.Click += BtnRefreshDepts_Click;
        }

        private static void BtnRefreshDepts_Click(object sender, RoutedEventArgs e)
        {
            RefreshDepartments();
        }

        static void RefreshDepartments()
        {
            var r = httpClient.GetAsync(baseAddress + "GetAllDepartments").Result;
            org.LoadDepartmentsList(r.Content.ReadAsStringAsync().Result);
            mainWindow.lbDepartments.ItemsSource = org.Departments;
        }
        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            int deptId = (mainWindow.lbDepartments.SelectedItem as Department).DepartmentId;
            EmployeeWindow employeeWindow = new EmployeeWindow();
            Employee curEmp = mainWindow.lbEmployees.SelectedItem as Employee;
            employeeWindow.tbFirstName.Text = curEmp.FirstName;
            employeeWindow.tbSecondName.Text = curEmp.SecondName;
            employeeWindow.dpBirthDay.SelectedDate =curEmp.BirthDay;
            employeeWindow.cbDepartment.ItemsSource= org.Departments;
            employeeWindow.cbDepartment.SelectedItem = org.Departments.First(d=>d.DepartmentId == curEmp.Departmentid);
            employeeWindow.btnCancel.Click += (o, h) => employeeWindow.Close();
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                int currentDeptId = curEmp.Departmentid;
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue)
                {
                    curEmp.ChangePersonalInfo(employeeWindow.tbFirstName.Text
                      , employeeWindow.tbSecondName.Text
                      , employeeWindow.dpBirthDay.SelectedDate.Value
                      , (employeeWindow.cbDepartment.SelectedItem as Department).DepartmentId);
                    // Как бы это переделать
                    StringContent content = new StringContent(org.GetJSONEmployee(curEmp), Encoding.UTF8, "application/json");
                    var r = httpClient.PostAsync(baseAddress+@"ModifyEmployee", content).Result;
                    employeeWindow.Close();
                }
                else
                    MessageBox.Show("Заполните все параметры");
            };
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult == true)
                UpdateLbEmployees(deptId);
        }
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            int deptId = (mainWindow.lbDepartments.SelectedItem as Department).DepartmentId;
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.btnCancel.Click += (o, h) => employeeWindow.Close();
            employeeWindow.cbDepartment.ItemsSource = org.Departments;
            employeeWindow.cbDepartment.SelectedItem = org.Departments.First(d => d.DepartmentId == deptId);
            employeeWindow.btnAddEmployee.Click += (o, h) =>
            {
                if (!String.IsNullOrEmpty(employeeWindow.tbFirstName.Text) && !String.IsNullOrEmpty(employeeWindow.tbSecondName.Text)
                && employeeWindow.dpBirthDay.SelectedDate.HasValue)
                {
                    StringContent content = new StringContent(org.GetJSONEmployee(new Employee(
                      employeeWindow.tbFirstName.Text
                      , employeeWindow.tbSecondName.Text
                      , employeeWindow.dpBirthDay.SelectedDate.Value
                      , (employeeWindow.cbDepartment.SelectedItem as Department).DepartmentId
                      )), Encoding.UTF8, "application/json");
                    var r = httpClient.PostAsync(baseAddress + @"AddEmployee", content).Result;
                    employeeWindow.DialogResult = true;
                    employeeWindow.Close();
                }
                else
                    MessageBox.Show("Заполните все параметры");
            };
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult == true)
                UpdateLbEmployees(deptId);
        }
        /// <summary>
        /// Добавить отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow();
            departmentWindow.btnCancel.Click += (o, h) => departmentWindow.Close();
            departmentWindow.btnAddDepartment.Click += (o, h) =>
            {
                Department dept=new Department(departmentWindow.tbDeparmentName.Text);
                StringContent content =
                new StringContent(org.GetJSONDept(dept), Encoding.UTF8, "application/json");
                var r = httpClient.PostAsync(baseAddress + @"AddDepartment", content).Result;
                departmentWindow.DialogResult = true;
                departmentWindow.Close();
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult == true)
            {
                RefreshDepartments();
            }
        }
        /// <summary>
        /// Редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow((mainWindow.lbDepartments.SelectedItem as Department).DepartmentName);
            departmentWindow.btnCancel.Click += (o, h) => departmentWindow.Close();
            departmentWindow.btnAddDepartment.Click += (o, h) =>
            {
                (mainWindow.lbDepartments.SelectedItem as Department).DepartmentName = departmentWindow.tbDeparmentName.Text;
                StringContent content = 
                new StringContent(org.GetJSONDept(mainWindow.lbDepartments.SelectedItem as Department), Encoding.UTF8, "application/json");
                var r = httpClient.PostAsync(baseAddress + @"ModifyDepartment", content).Result;
                departmentWindow.DialogResult = true;
                departmentWindow.Close();
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult == true)
            {
                RefreshDepartments();
            }
        }

        /// <summary>
        /// Загрузка сотрудников, включение кнопок добавить сотрудника, редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int deptId = (mainWindow.lbDepartments.SelectedItem as Department).DepartmentId;
            if (UpdateLbEmployees(deptId))
                mainWindow.btnAddEmployee.IsEnabled = true;
            mainWindow.btnEditDepartment.IsEnabled = mainWindow.lbDepartments.SelectedItem != null ? true : false;
        }
        static bool UpdateLbEmployees(int deptId)
        {
            var r = httpClient.GetAsync(baseAddress + $"GetDeptEmployees/{deptId}").Result;
            if (r.IsSuccessStatusCode)
            {
                mainWindow.lbEmployees.ItemsSource = org.GetEmployees(r.Content.ReadAsStringAsync().Result);
            }
            return r.IsSuccessStatusCode;
        }
        /// <summary>
        /// Включение возможности редактировать сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.btnEditEmployee.IsEnabled = mainWindow.lbEmployees.SelectedItem != null ? true : false;
        }
    }
}

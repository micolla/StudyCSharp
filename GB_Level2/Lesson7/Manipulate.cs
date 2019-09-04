using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeCard.DataBaseClasses;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace EmployeeCard
{
    static class Manipulate
    {
        static Organisation org;
        static MainWindow mainWindow;
        private static SqlDataAdapter sqlDepartmentAdapter;
        private static DataTable deptDatatTable;
        private static DataTable empDatatTable;
        public static void Init(MainWindow window)
        {
            FillOrgStructure();
            mainWindow = window;
            mainWindow.lbDepartments.ItemsSource = org.Departments;
            mainWindow.lbDepartments.SelectionChanged += LbDepartments_SelectionChanged;
            mainWindow.lbEmployees.SelectionChanged += LbEmployees_SelectionChanged;
            mainWindow.btnAddDepartment.Click += BtnAddDepartment_Click;
            mainWindow.btnAddEmployee.Click += BtnAddEmployee_Click;
            mainWindow.btnEditEmployee.Click += BtnEditEmployee_Click;
            mainWindow.btnEditDepartment.Click += BtnEditDepartment_Click;
            mainWindow.Closing += MainWindow_Closing;
        }
        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Нужно переделать на долив изменений
            using (StreamWriter streamWriter = new StreamWriter("InfoBase/departments.csv"))
            {
                foreach (Department department in org.Departments)
                {
                    streamWriter.WriteLine($"{department.DepartmentId};{department.DepartmentName}");
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("InfoBase/employee.csv"))
            {
                foreach (Employee employee in org.Employees)
                {
                    streamWriter.WriteLine(
                        $"{employee.FirstName};{employee.SecondName};{employee.BirthDay.ToString("dd.mm.yyyy")};{employee.EmployeeDocument.DocumentType};"+
                        $"{ employee.EmployeeDocument.Serial};{employee.EmployeeDocument.Number}");
                }
            }
        }

        /// <summary>
        /// Загрузка данных об организации из файла
        /// </summary>
        private static void FillOrgStructure()
        {
            org = new Organisation("MyCompany");
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeCardConnectionString"].ConnectionString;
            SqlConnection sqlConnection;
            using (sqlConnection = new SqlConnection(connectionString)) {
                sqlDepartmentAdapter = new SqlDataAdapter("select * from departments", sqlConnection);
                SqlCommand updateCommand = new SqlCommand("update Departments set DepartmentName=@deptName,ParentDeptId=@parentDepId where DeptId=@deptid;",new SqlConnection(connectionString));
                updateCommand.Parameters.Add("@deptName", SqlDbType.VarChar,255, "DepartmentName");
                updateCommand.Parameters.Add("@parentDepId", SqlDbType.Int);
                updateCommand.Parameters.Add("@deptid", SqlDbType.Int);
                sqlDepartmentAdapter.UpdateCommand = updateCommand;
                SqlCommand insertCommand = new SqlCommand("Insert into Departments(DepartmentName,ParentDeptId)values(@deptName,@parentDepId);",new SqlConnection(connectionString));
                insertCommand.Parameters.Add("@deptName", SqlDbType.VarChar,255, "DepartmentName");
                insertCommand.Parameters.Add("@parentDepId", SqlDbType.Int);
                sqlDepartmentAdapter.InsertCommand = insertCommand;
                deptDatatTable = new DataTable();
                sqlDepartmentAdapter.Fill(deptDatatTable);
                for (int i = 0; i < deptDatatTable.Rows.Count; i++)
                {
                    org.AddDeparment(new Department((int)deptDatatTable.Rows[i]["DeptId"],(string)deptDatatTable.Rows[i]["DepartmentName"]));
                }
            };

        }

        /*private static void FillOrgStructure()
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
        }*/
        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int currentDeptId = curEmp.Departmentid;
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
                    // Как бы это переделать
                    if (currentDeptId!= curEmp.Departmentid)
                        mainWindow.lbEmployees.ItemsSource = org.GetEmployees(currentDeptId);
                    employeeWindow.Close();
                }
                else
                    MessageBox.Show("Заполните все параметры");
            };
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
        }
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                DataRow newRow = deptDatatTable.NewRow();
                newRow["DepartmentName"] = departmentWindow.tbDeparmentName.Text;
                newRow["DeptId"] = DBNull.Value;
                newRow["ParentDeptId"] = DBNull.Value;
                deptDatatTable.Rows.Add(newRow);
                sqlDepartmentAdapter.Update(deptDatatTable);
                if (org.AddDeparment(new Department((int)newRow["DeptId"], (string)newRow["DepartmentName"])))
                    departmentWindow.Close();
                else MessageBox.Show("Такой отдел уже есть");
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
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
                if (org.ChangeDepartmentName((mainWindow.lbDepartments.SelectedItem as Department).DepartmentId, departmentWindow.tbDeparmentName.Text))
                    departmentWindow.Close();
                else MessageBox.Show("Такой отдел уже есть");
            };
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
        }

        /// <summary>
        /// Загрузка сотрудников, включение кнопок добавить сотрудника, редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mainWindow.lbEmployees.ItemsSource = org.GetEmployees((mainWindow.lbDepartments.SelectedItem as Department).DepartmentId);
            mainWindow.btnAddEmployee.IsEnabled = true;
            mainWindow.btnEditDepartment.IsEnabled = mainWindow.lbDepartments.SelectedItem != null ? true : false;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace EmployeeCard
{
    static class Manipulate
    {
        static MainWindow mainWindow;
        private static SqlDataAdapter sqlDepartmentAdapter;
        private static SqlDataAdapter sqlEmployeeAdapter;
        private static DataTable deptDatatTable;
        private static DataTable empDatatTable;
        private static SqlConnection sqlConnection;
        public static void Init(MainWindow window)
        {
            FillOrgStructure();
            mainWindow = window;
            mainWindow.lbDepartments.DataContext = deptDatatTable.DefaultView;
            mainWindow.lbEmployees.DataContext = empDatatTable.DefaultView;
            mainWindow.lbDepartments.SelectionChanged += LbDepartments_SelectionChanged;
            mainWindow.lbEmployees.SelectionChanged += LbEmployees_SelectionChanged;
            mainWindow.btnAddDepartment.Click += BtnAddDepartment_Click;
            mainWindow.btnAddEmployee.Click += BtnAddEmployee_Click;
            mainWindow.btnEditEmployee.Click += BtnEditEmployee_Click;
            mainWindow.btnEditDepartment.Click += BtnEditDepartment_Click;
        }

        /// <summary>
        /// Загрузка данных об организации из файла
        /// </summary>
        private static void FillOrgStructure()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeCardConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);
            sqlDepartmentAdapter = new SqlDataAdapter("select * from departments", sqlConnection);
            SqlCommand updateCommand = new SqlCommand("update Departments set DepartmentName=@deptName,ParentDeptId=@parentDepId where DeptId=@deptid;", sqlConnection);
            SqlCommandBuilder scb = new SqlCommandBuilder(sqlDepartmentAdapter);
            /*updateCommand.Parameters.Add("@deptName", SqlDbType.VarChar,255, "DepartmentName");
            updateCommand.Parameters.Add("@parentDepId", SqlDbType.Int,0, "ParentDeptId");
            updateCommand.Parameters.Add("@deptid", SqlDbType.Int, 0, "deptid");
            sqlDepartmentAdapter.UpdateCommand = updateCommand;
            SqlCommand insertCommand = new SqlCommand("Insert into Departments(DepartmentName,ParentDeptId)values(@deptName,@parentDepId); SET @ID = @@IDENTITY;", sqlConnection);
            insertCommand.Parameters.Add("@deptName", SqlDbType.VarChar,255, "DepartmentName");
            insertCommand.Parameters.Add("@parentDepId", SqlDbType.Int,0, "ParentDeptId");
            insertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "deptID");
            insertCommand.Parameters["@ID"].Direction = ParameterDirection.Output;
            insertCommand.Parameters["@ID"].SourceVersion = DataRowVersion.Current;
            sqlDepartmentAdapter.InsertCommand = insertCommand;*/
            //sqlDepartmentAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
            deptDatatTable = new DataTable();
            sqlDepartmentAdapter.Fill(deptDatatTable);

            sqlEmployeeAdapter = new SqlDataAdapter("select e.*, d.DepartmentName "
                                                +"from Employees e "
                                                +"join Departments d on d.DeptId = e.DeptId "
                                                +"where e.DeptId=@Deptid"
                                    , sqlConnection);
            sqlEmployeeAdapter.SelectCommand.Parameters.Add("@deptid", SqlDbType.Int, 0, "deptid");
            sqlEmployeeAdapter.SelectCommand.Parameters["@deptid"].Value = DBNull.Value;
            sqlEmployeeAdapter.UpdateCommand = new SqlCommand("update Employees set FirstName=@Firstname,SecondName=@Secondname,BirthDay=@Birthday,DeptId=@Deptid where EmplId=@emplid",sqlConnection);
            sqlEmployeeAdapter.UpdateCommand.Parameters.Add("@Firstname", SqlDbType.NVarChar, 50, "Firstname");
            sqlEmployeeAdapter.UpdateCommand.Parameters.Add("@Secondname", SqlDbType.NVarChar, 50, "Secondname");
            sqlEmployeeAdapter.UpdateCommand.Parameters.Add("@Birthday", SqlDbType.Date, 0, "Birthday");
            sqlEmployeeAdapter.UpdateCommand.Parameters.Add("@Deptid", SqlDbType.Int, 0, "Deptid");
            sqlEmployeeAdapter.UpdateCommand.Parameters.Add("@emplid", SqlDbType.Int, 0, "emplid");
            sqlEmployeeAdapter.InsertCommand = new SqlCommand("insert into Employees(FirstName,SecondName,BirthDay,DeptId) values(@Firstname,@Secondname,@Birthday,@Deptid)",sqlConnection);
            sqlEmployeeAdapter.InsertCommand.Parameters.Add("@Firstname", SqlDbType.NVarChar, 60, "Firstname");
            sqlEmployeeAdapter.InsertCommand.Parameters.Add("@Secondname", SqlDbType.NVarChar, 60, "Secondname");
            sqlEmployeeAdapter.InsertCommand.Parameters.Add("@Birthday", SqlDbType.Date, 0, "Birthday");
            sqlEmployeeAdapter.InsertCommand.Parameters.Add("@Deptid", SqlDbType.Int, 0, "Deptid");
            sqlEmployeeAdapter.InsertCommand.Parameters.Add("@emplid", SqlDbType.Int, 0, "emplid");
            sqlEmployeeAdapter.InsertCommand.Parameters["@emplid"].Direction = ParameterDirection.Output;
            sqlEmployeeAdapter.InsertCommand.Parameters["@emplid"].SourceVersion = DataRowVersion.Current;
            empDatatTable = new DataTable();
            sqlEmployeeAdapter.Fill(empDatatTable);

        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)mainWindow.lbEmployees.SelectedItem;
            EmployeeWindow employeeWindow = new EmployeeWindow(newRow.Row,deptDatatTable);
            employeeWindow.Owner = mainWindow;
            newRow.BeginEdit();
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                empDatatTable.Rows.Add(newRow);
                sqlEmployeeAdapter.Update(empDatatTable);
            }
            else
                newRow.CancelEdit();
        }
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = empDatatTable.NewRow();
            EmployeeWindow employeeWindow = new EmployeeWindow(newRow, deptDatatTable);
            employeeWindow.Owner = mainWindow;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
            {
                empDatatTable.Rows.Add(newRow);
                sqlEmployeeAdapter.Update(empDatatTable);
            }
        }
        /// <summary>
        /// Добавить отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = deptDatatTable.NewRow();
            DepartmentWindow departmentWindow = new DepartmentWindow(newRow);
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult.HasValue && departmentWindow.DialogResult.Value)
            {
                deptDatatTable.Rows.Add(newRow);
                sqlDepartmentAdapter.Update(deptDatatTable);
            }
        }

        /// <summary>
        /// Редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BtnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)mainWindow.lbDepartments.SelectedItem;
            DepartmentWindow departmentWindow = new DepartmentWindow(newRow.Row);
            newRow.BeginEdit();
            departmentWindow.Owner = mainWindow;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult.HasValue && departmentWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                sqlDepartmentAdapter.Update(deptDatatTable);
            }
            else
                newRow.CancelEdit();
        }

        /// <summary>
        /// Загрузка сотрудников, включение кнопок добавить сотрудника, редактировать отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LbDepartments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            sqlEmployeeAdapter.SelectCommand.Parameters["@deptid"].Value = (mainWindow.lbDepartments.SelectedItem as DataRowView).Row["deptId"];
            //Без этого данные в ListView остаются и постоянно увеличиваются при считывании в empDataable
            empDatatTable = null;
            empDatatTable = new DataTable();
            sqlEmployeeAdapter.Fill(empDatatTable);
            mainWindow.lbEmployees.ItemsSource = empDatatTable.DefaultView;
            //Конец непонятного блока
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

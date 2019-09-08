using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using EmployeeCard.DataBaseClasses;

namespace WebApiEmployeesDB.Models
{
    public enum DbAction
    {
        Update,Insert
    }
    public class Manipulate
    {
        SqlConnection dbConnection;
        public Manipulate()
        {
            dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCardConnectionString"].ConnectionString);
            dbConnection.Open();
        }
        public List<Department> GetAllDepartments()
        {
            List<Department> deptsList = new List<Department>();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select deptId,DepartmentName from departments", dbConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            deptsList.Add(new Department(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return deptsList;
        }
        public Department GetDepartment(int deptId)
        {
            Department dept=new Department();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand($"Select deptId,DepartmentName from departments where deptid={deptId}"
                    , dbConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            dept= new Department(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                dept = new Department();
            }
            return dept;

        }
        public List<Employee> GetEmployees(int deptId)
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("select e.emplId,e.FirstName,e.SecondName,e.BirthDay "
                                                + "from Employees e "
                                                + $"where e.DeptId={deptId}", dbConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {

                            employeeList.Add(
                                new Employee(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1)
                                            , sqlDataReader.GetString(2),sqlDataReader.GetDateTime(3),deptId)
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return employeeList;
        }
        public bool WorkDepartment(Department department, DbAction dbAction)
        {
            try
            {
                string sqlAdd=String.Empty;
                using (SqlCommand command = new SqlCommand())
                {
                    if (dbAction==DbAction.Insert)
                    {
                        sqlAdd = $@" INSERT INTO Departments(DepartmentName)
                               VALUES(@DepartmentName)";
                    }
                    else if(dbAction == DbAction.Update)
                    {
                        sqlAdd = $"Update Departments set DepartmentName=@DepartmentName where deptId=@deptId";
                        command.Parameters.Add("@deptId", SqlDbType.Int, 0, "Deptid");
                        command.Parameters["deptId"].Value = department.DepartmentId;
                    }
                    if (sqlAdd != String.Empty)
                    {
                        command.Parameters.Add("@DepartmentName", SqlDbType.Date, 0, "DepartmentName");
                        command.Parameters["DepartmentName"].Value = department.DepartmentName;
                        command.CommandText = sqlAdd;
                        command.Connection = dbConnection;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool WorkEmployee(Employee employee,DbAction dbAction)
        {
            string sqlAdd= String.Empty;
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.Add("@Firstname", SqlDbType.NVarChar, 60, "Firstname");
                    command.Parameters.Add("@Secondname", SqlDbType.NVarChar, 60, "Secondname");
                    command.Parameters.Add("@Birthday", SqlDbType.Date, 0, "Birthday");
                    command.Parameters.Add("@Deptid", SqlDbType.Int, 0, "Deptid");
                    if (dbAction == DbAction.Insert)
                    {
                        sqlAdd = $@"insert into Employees(FirstName,SecondName,BirthDay,DeptId) values(@Firstname,@Secondname,@Birthday,@Deptid)";
                    }
                    else if (dbAction == DbAction.Update)
                    {
                        sqlAdd = "update Employees set FirstName = @Firstname,SecondName = @Secondname,BirthDay = @Birthday,DeptId = @Deptid where EmplId = @emplid";
                        command.Parameters.Add("@emplid", SqlDbType.Int, 0, "emplid");
                        command.Parameters[4].Value = employee.EmployeeId;
                    }
                    if (sqlAdd != String.Empty)
                    {
                        command.CommandText = sqlAdd;
                        command.Connection = dbConnection;
                        command.Parameters[0].Value = employee.FirstName;
                        command.Parameters[1].Value = employee.SecondName;
                        command.Parameters[2].Value = employee.BirthDay;
                        command.Parameters[3].Value = employee.Departmentid;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
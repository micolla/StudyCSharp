using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Department
    {
        public string DepartmentName { get; private set; }
        public List<Employee> Employees { get; private set; }
        public Department(string depatmentName)
        {
            this.DepartmentName = depatmentName;
            Employees = new List<Employee>();
        }
        public Department(string depatmentName,List<Employee> employees)
        {
            this.DepartmentName = depatmentName;
            this.Employees = employees;
        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
    }
}

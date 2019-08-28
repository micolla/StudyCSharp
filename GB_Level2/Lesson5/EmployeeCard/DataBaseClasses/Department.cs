using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Department
    {
        public string DepartmentName { get; private set; }
        public ObservableCollection<Employee> Employees { get; private set; }
        public Department(string depatmentName)
        {
            this.DepartmentName = depatmentName;
            Employees = new ObservableCollection<Employee>();
        }
        public Department(string depatmentName, ObservableCollection<Employee> employees)
        {
            this.DepartmentName = depatmentName;
            this.Employees = employees;
        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public override string ToString()
        {
            return $"{DepartmentName}";
        }
    }
}

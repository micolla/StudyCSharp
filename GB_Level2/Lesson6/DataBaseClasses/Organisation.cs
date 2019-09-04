using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Organisation
    {
        public ObservableCollection<Department> Departments { get; private set; }
        public ObservableCollection<Employee> Employees { get; private set; }
        public string OrganisationName { get; private set; }
        public Organisation(string orgName)
        {
            this.OrganisationName = orgName;
            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
        }
        public bool AddDeparment(Department department)
        {
            if ((from d in Departments
                 where d.DepartmentName == department.DepartmentName
                 select d).Count() == 0)
            {
                this.Departments.Add(department);
                return true;
            }
            else
                return false;
        }

        public bool ChangeDepartmentName(int deptId,string newName)
        {
            if ((from d in Departments
                 where d.DepartmentName == newName
                 select d).Count() == 0)
            {
                this.Departments.Where((d)=>d.DepartmentId==deptId).First().DepartmentName=newName;
                return true;
            }
            else
                return false;
        }

        public bool AddEmployee(Employee employee)
        {
            if ((from e in Employees
                 where e == employee
                 select e).Count() == 0)
            {
                this.Employees.Add(employee);
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return this.OrganisationName;
        }
        public ObservableCollection<Employee> GetEmployees(int departmentId)
        {
            return new ObservableCollection<Employee>(from e in Employees
                                                      where e.Departmentid == departmentId
                                                      select e);
        }
    }
}

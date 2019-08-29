using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Organisation
    {
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public string OrganisationName { get; private set; }
        public Organisation(string orgName)
        {
            this.OrganisationName = orgName;
            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
        }
        public void AddDeparment(Department department)
        {
            if(( from d in Departments
                       where d == department
                       select d).Count()==0)
                this.Departments.Add(department);
        }

        public void AddEmployee(Employee employee)
        {
            this.Employees.Add(employee);
        }

        public override string ToString()
        {
            return this.OrganisationName;
        }
        public ObservableCollection<Employee> GetEmployees(Department department)
        {
            return new ObservableCollection<Employee>(from e in Employees
                                                      where e.Department == department
                                                      select e);
        }
    }
}

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
        public string OrganisationName { get; private set; }
        public Organisation(string orgName)
        {
            this.OrganisationName = orgName;
            Departments = new ObservableCollection<Department>();
        }
        public void AddDeparment(Department department)
        {
            this.Departments.Add(department);
        }
        public override string ToString()
        {
            return this.OrganisationName;
        }
    }
}

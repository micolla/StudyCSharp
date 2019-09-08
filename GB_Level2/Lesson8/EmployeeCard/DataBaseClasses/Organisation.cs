using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

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

        internal void LoadDepartmentsList(string jsonList)
        {
            JavaScriptSerializer jsonSerializer 
                = new JavaScriptSerializer();
            Departments = jsonSerializer.Deserialize<ObservableCollection<Department>>(jsonList);
        }

        public string GetJSONDept(Department dept)
        {
            JavaScriptSerializer jsonSerializer
                = new JavaScriptSerializer();
            return jsonSerializer.Serialize(dept);
        }

        public string GetJSONEmployee(Employee employee)
        {
            JavaScriptSerializer jsonSerializer
                = new JavaScriptSerializer();
            return jsonSerializer.Serialize(employee);
        }

        public override string ToString()
        {
            return this.OrganisationName;
        }
        public ObservableCollection<Employee> GetEmployees(string jsonList)
        {
             JavaScriptSerializer jsonSerializer
                = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<ObservableCollection<Employee>>(jsonList);
        }
    }
}

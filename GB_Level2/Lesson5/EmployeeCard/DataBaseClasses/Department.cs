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
        public Department(string depatmentName)
        {
            this.DepartmentName = depatmentName;
        }
    }
}

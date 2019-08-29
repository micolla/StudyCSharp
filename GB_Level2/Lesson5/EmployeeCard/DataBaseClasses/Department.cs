using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Department : IComparable<Department>
    {
        public string DepartmentName { get; private set; }
        public Department(string depatmentName)=>this.DepartmentName = depatmentName;
        public override string ToString()
        {
            return $"{DepartmentName}";
        }

        public int CompareTo(Department other) => this.DepartmentName.CompareTo(other.DepartmentName);

        public override bool Equals(object obj)
        {
            if (obj is Department)
            {
                return this.DepartmentName.Equals((obj as Department).DepartmentName);
            }
            else
                return false;
        }

        public static bool operator ==(Department d, Department d2) => d.Equals(d2);
        public static bool operator !=(Department d, Department d2) => d.Equals(d2);
    }
}

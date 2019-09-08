using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    [DataContract]
    public class Department : IEquatable<Department>,IComparable<Department>,System.ComponentModel.INotifyPropertyChanged
    {
        #region Данные
        private string departmentName;
        [DataMember]
        public string DepartmentName { get=> departmentName;
            set { this.departmentName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentName))); }
        }
        private int? departmentId;
        [DataMember]
        public int? DepartmentId { get => departmentId; private set => departmentId = value; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Department(int deptId,string departmentName):this(departmentName)
        {
            this.DepartmentName = departmentName;
            this.DepartmentId = deptId;
        }
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
            this.DepartmentId = null;
        }
        public Department()
        {

        }
        #region Вспомогательные методы
        public override string ToString()
        {
            return $"{DepartmentName}";
        }

        public int CompareTo(Department other) => this.DepartmentName.CompareTo(other.DepartmentName);
        public override bool Equals(object obj)
        {
            if (obj is Department)
                return this.Equals(obj as Department);
            else
                return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(Department other)
        {
            return this.DepartmentId==other.DepartmentId;
        }

        public static bool operator ==(Department d, Department d2) => d.Equals(d2);
        public static bool operator !=(Department d, Department d2) => !d.Equals(d2);
        #endregion
    }
}

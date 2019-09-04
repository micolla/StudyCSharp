using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Department : IEquatable<Department>,IComparable<Department>,System.ComponentModel.INotifyPropertyChanged
    {
        #region Статические объекты
        private static int currentDepartmentId;
        static Department() => currentDepartmentId = 0;
        #endregion
        #region Данные
        private string departmentName;
        public string DepartmentName { get=> departmentName;
            set { this.departmentName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentName))); }
        }
        public int DepartmentId { get; private set; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public Department(string depatmentName)
        {
            this.DepartmentName = depatmentName;
            this.DepartmentId = currentDepartmentId++;
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

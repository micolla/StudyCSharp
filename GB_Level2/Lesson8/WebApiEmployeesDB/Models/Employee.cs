using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeCard.DataBaseClasses
{
    [DataContract]
    public class Employee: IEquatable<Employee>, IComparable<Employee>, System.ComponentModel.INotifyPropertyChanged
    {
        #region Данные
        private int employeeId;
        private string firstName;
        private string secondName;
        private DateTime birthDay;
        private int departmentid;
        [DataMember]
        public int EmployeeId { get => employeeId;
            private set {employeeId=value;}
        }
        [DataMember]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FirstName)));
            }
        }
        [DataMember]
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SecondName)));
            }
        }
        [DataMember]
        public DateTime BirthDay { get => birthDay.Date; private set => birthDay = value; }
        [DataMember]
        public int Departmentid { get => departmentid; set => departmentid = value; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public Employee(int employeeId,string firstName, string secondName, DateTime birthDay,int deptId)
        {
            this.FirstName = firstName;
            this.SecondName= secondName;
            this.BirthDay = birthDay.Date;
            this.EmployeeId = employeeId;
            this.Departmentid = deptId;
        }

        public void ChangeDepartment(int newDepartment) => this.Departmentid = newDepartment;
        public void ChangePersonalInfo(string firstName, string secondName, DateTime birthDay
            , int department)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDay = birthDay.Date;
            this.Departmentid = department;
        }
        #region Вспомогательные методы
        public override string ToString()
        {
            return $"{FirstName} {SecondName} {this.GetType().Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                return this.Equals((obj as Employee));
            }
            else
                return false;
        }

        public int CompareTo(Employee other)
        {
            var firstCompare=this.SecondName.CompareTo(other.SecondName);
            if (firstCompare == 0)
                return this.FirstName.CompareTo(other.FirstName);
            else
                return firstCompare;
        }

        public bool Equals(Employee other)
        {
            return this.EmployeeId.Equals(other.EmployeeId);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Employee e, Employee e2) => e.Equals(e2);
        public static bool operator !=(Employee e, Employee e2) => !e.Equals(e2);
        #endregion
    }
}
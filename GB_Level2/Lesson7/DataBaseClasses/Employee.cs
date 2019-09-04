using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Employee: IEquatable<Employee>, IComparable<Employee>, System.ComponentModel.INotifyPropertyChanged
    {
        #region Статические объекты
        private static int currentEmployeeId;
        static Employee() => currentEmployeeId = 0;
        #endregion
        #region Данные
        private int employeeId;
        private string firstName;
        private string secondName;
        private DateTime birthDay;
        private Document employeeDocument;
        private int departmentid;
        public int EmployeeId { get => employeeId;
            private set {employeeId=value;}
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FirstName)));
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SecondName)));
            }
        }
        public DateTime BirthDay { get => birthDay; private set => birthDay = value; }
        public Document EmployeeDocument { get => employeeDocument; private set => employeeDocument = value; }
        public int Departmentid { get => departmentid; set => departmentid = value; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private Employee(string firstName, string secondName, DateTime birthDay)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.birthDay = birthDay.Date;
            this.employeeId = currentEmployeeId++;
        }
        public Employee(string firstName, string secondName, DateTime birthDay, Document employeeDocument, int department)
            : this(firstName, secondName, birthDay)
        {
            this.employeeDocument = employeeDocument;
            this.departmentid = department;
        }
        public Employee(string firstName, string secondName, DateTime birthDay
            ,Document.DocumentTypes documentType, string serial,string number,int department)
            : this(firstName, secondName, birthDay)
        {
            this.employeeDocument = new Document(serial, number, documentType);
            this.departmentid = department;
        }
        public void ChangeDepartment(int newDepartment) => this.Departmentid = newDepartment;
        public void ChangePersonalInfo(string firstName, string secondName, DateTime birthDay
            , Document.DocumentTypes documentType, string serial, string number, int department)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDay = birthDay.Date;
            this.EmployeeDocument = new Document(serial, number, documentType);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    abstract class Employee
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public Document EmployeeDocument { get; private set; }
        public Department Department { get; private set; }
        private Employee(string firstName, string secondName, DateTime birthDay)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDay = birthDay.Date;
        }
        public Employee(string firstName, string secondName, DateTime birthDay, Document employeeDocument, Department department)
            : this(firstName, secondName, birthDay)
        {
            this.EmployeeDocument = employeeDocument;
            this.Department = department;
        }
        public Employee(string firstName, string secondName, DateTime birthDay
            ,Document.DocumentType documentType, string serial,string number,Department department)
            : this(firstName, secondName, birthDay)
        {
            this.EmployeeDocument = new Document(serial, number, documentType);
            this.Department = department;
        }
        public void ChangeDepartment(Department newDepartment) => this.Department = newDepartment;
        public void ChangePersonalInfo(string firstName, string secondName, DateTime birthDay
            , Document.DocumentType documentType, string serial, string number, Department department)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDay = birthDay.Date;
            this.EmployeeDocument = new Document(serial, number, documentType);
            this.Department = department;
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName} {this.GetType().Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                return this.EmployeeDocument.Equals((obj as Employee).EmployeeDocument);
            }
            else
                return false;
        }
        public static bool operator ==(Employee e, Employee e2) => e.Equals(e2);
        public static bool operator !=(Employee e, Employee e2) => !e.Equals(e2);
    }
}
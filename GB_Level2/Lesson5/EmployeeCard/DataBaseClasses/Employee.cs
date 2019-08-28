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
        private Employee(string firstName, string secondName, DateTime birthDay)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDay = birthDay.Date;
        }
        public Employee(string firstName, string secondName, DateTime birthDay, Document employeeDocument)
            : this(firstName, secondName, birthDay)
            => this.EmployeeDocument = employeeDocument;
        public Employee(string firstName, string secondName, DateTime birthDay
            ,Document.DocumentType documentType, string serial,string number)
            : this(firstName, secondName, birthDay)
        {
            if(documentType==Document.DocumentType.Passport)
                this.EmployeeDocument = new Passport(serial, number);
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName} {this.GetType().Name}";
        }
    }
}
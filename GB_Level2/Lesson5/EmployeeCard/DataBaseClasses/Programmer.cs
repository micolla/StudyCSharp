using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Programmer : Employee
    {
        public Programmer(string firstName, string secondName, DateTime birthDay, Document employeeDocument) : base(firstName, secondName, birthDay, employeeDocument)
        {
        }

        public Programmer(string firstName, string secondName, DateTime birthDay, Document.DocumentType documentType, string serial, string number) : base(firstName, secondName, birthDay, documentType, serial, number)
        {
        }
    }
}

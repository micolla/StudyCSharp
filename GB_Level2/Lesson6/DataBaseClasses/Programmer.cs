using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Programmer : Employee
    {
        public Programmer(string firstName, string secondName, DateTime birthDay, Document employeeDocument,int departmentId) 
            : base(firstName, secondName, birthDay, employeeDocument, departmentId)
        {
        }

        public Programmer(string firstName, string secondName, DateTime birthDay, Document.DocumentTypes documentType
            , string serial, string number, int departmentId) 
            : base(firstName, secondName, birthDay, documentType, serial, number, departmentId)
        {
        }
    }
}

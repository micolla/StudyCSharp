using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class ProgrammerFactoyMethod : AbstractEmployeeFactoryMethod
    {
        public override Employee GetEmployee(string firstName, string secondName, DateTime birthDay, Document.DocumentType documentType, string serial, string number)
        {
            return new Programmer(firstName,secondName,birthDay,documentType,serial,number,new Department("dsf"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    abstract class AbstractEmployeeFactoryMethod
    {
        public abstract Employee GetEmployee(string firstName, string secondName, DateTime birthDay
            , Document.DocumentTypes documentType, string serial, string number);
    }
}

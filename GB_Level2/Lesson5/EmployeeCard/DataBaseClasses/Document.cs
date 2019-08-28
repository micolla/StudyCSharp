using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    abstract class Document
    {
        public enum DocumentType
        {
            Passport
            ,DriverLicense
        }
        public string Serial { get; private set; }
        public string Number { get; private set; }
        public Document(string serial,string number)
        {
            this.Number = number;
            this.Serial = serial;
        }
    }
}

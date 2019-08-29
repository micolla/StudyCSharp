using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Passport : Document
    {
        public override Document.DocumentType documentType => Document.DocumentType.Passport;
        public Passport(string serial, string number) : base(serial, number)
        {
        }
    }
}

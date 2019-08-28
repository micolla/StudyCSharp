using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.DataBaseClasses
{
    class Passport : Document
    {
        public Passport(string serial, string number) : base(serial, number)
        {
        }
    }
}

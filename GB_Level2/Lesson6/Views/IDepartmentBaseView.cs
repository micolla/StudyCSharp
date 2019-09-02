using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCard.Views
{
    interface IDepartmentBaseView
    {
        string DepartmentName { get; set; }
        int DepartmentId { get; set; }
    }
}

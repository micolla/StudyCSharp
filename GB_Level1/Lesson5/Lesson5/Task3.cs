using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Task3
    {
        public static bool CheckConsist(string s1,string s2)
        {
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();
            Array.Sort(c1);
            Array.Sort(c2);
            s1 = new string(c1);
            s2 = new string(c2);
            return s1.CompareTo(s2) == 0 ? true : false;
        }
    }
}

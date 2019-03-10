using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.StudentSpace
{
    class Student : IComparable
    {
        public string firstName;
        public string lastName;
        public string university;
        public string department;
        public string facultet;
        public ushort age;
        public ushort course;
        public ushort group;
        public string city;
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
        public int CompareTo(object o)///Реализация для сортировки
        {
            Student s = o as Student;
            if (s != null)
                return this.age.CompareTo(s.age);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}

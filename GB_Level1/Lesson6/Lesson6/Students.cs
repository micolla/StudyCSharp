using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lesson6.StudentSpace
{
    public class Students
    {
        List<Student> studentList;
        public Students(List<Student> ls)
        {
            studentList = ls;
        }

        public Students(string fileName)
        {
            studentList = new List<Student>();
            // Запомним время в начале обработки данных
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                try
                {
                    this.AddStudent(sr.ReadLine().Split(';'));
                }
                catch
                {
                }
            }
            sr.Close();
        }

        public Students()
        {
            studentList = new List<Student>();
        }
        public bool AddStudent(string[] s1)
        {
            Student st = new Student();
            try
            {
                st.firstName = s1[0];
                st.lastName = s1[1];
                st.university = s1[2];
                st.department = s1[3];
                st.facultet = s1[4];
                st.age = ushort.Parse(s1[5]);
                st.course = ushort.Parse(s1[6]);
                st.group = ushort.Parse(s1[7]);
                st.city = s1[8];
                studentList.Add(st);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        public void Sort()
        {
            studentList.Sort();
        }

        /// <summary>
        /// Количество бакалавров
        /// </summary>
        public int BacalavrCount
        {
            get
            {
                int result = 0;
                foreach (var item in studentList)
                {
                    if (item.course < 5)
                        result++;
                }
                return result;
            }
        }
        /// <summary>
        /// Количество Магистров
        /// </summary>
        public int MagistrCount
        {
            get
            {
                int result = 0;
                foreach (var item in studentList)
                {
                    if (item.course >= 5)
                        result++;
                }
                return result;
            }
        }
        /// <summary>
        /// Всего студентов
        /// </summary>
        public int StudentsCount => studentList.Count;
        /// <summary>
        /// Студентов 5 курса
        /// </summary>
        public int Students5Cnt => StudentsCnt(5);
        /// <summary>
        /// Студентов 6 курса
        /// </summary>
        public int Students6Cnt => StudentsCnt(6);
        /// <summary>
        /// Количество студентов на курсе
        /// </summary>
        /// <param name="course">курс</param>
        /// <returns>Число студентов</returns>
        int StudentsCnt(int course)
        {
            int result = 0;
            foreach (var item in studentList)
            {
                if (item.course == course)
                    result++;
            }
            return result;
        }
        /// <summary>
        /// Индексатор внутренного массива
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Student this[int index]
        {
            get { return studentList[index]; }
            set { studentList[index] = value; }
        }
        /// <summary>
        /// Приведение максимума к x2, минимума к x1
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        private static void MaxVal(ref int x1, ref int x2)
        {
            if (x1 > x2)
            {
                x2 = x1 + x2;
                x1 = x2 - x1;
                x2 = x2 - x1;
            }
        }
        /// <summary>
        /// Определение числа студентов в диапазоне возраста
        /// </summary>
        /// <param name="age1">С</param>
        /// <param name="age2">По</param>
        /// <returns></returns>
        public int GetStudentsCnt(int age1, int age2)
        {
            MaxVal(ref age1, ref age2);
            int cnt = 0;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].age >= age1 && studentList[i].age <= age2)
                    cnt++;
            }
            return cnt;
        }
        public void CreateXML(string fileName)
        {
            XmlSerializer x = new XmlSerializer(this.studentList.GetType());
            Stream fStream;
            if (!File.Exists(fileName))
            {
                fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            else
            {
                fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            }
                x.Serialize(fStream, this.studentList);
            fStream.Close();
        }
    }
}

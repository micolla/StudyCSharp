using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson6.StudentSpace;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Task4
{//Донцов Николай
    //**Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок)
    static class MakeXML
    {
        /// <summary>
        /// Метод для себя, сохранение в CSV
        /// </summary>
        /// <param name="s">Класс студенты</param>
        /// <param name="fileName">Куда сохранять CSV</param>
        public static void CreateCSV(Students s,string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            
            for (int i = 0; i < s.StudentsCount; i++)
            {
                foreach (var item in s[i].GetType().GetFields())
                {
                    sw.Write(item.GetValue(s[i]).ToString()+";");
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        /// <summary>
        /// **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок)
        /// </summary>
        /// <param name="s">Класс студенты</param>
        /// <param name="fileName">Куда сохранять XML</param>
        public static void CreateXML(Students s,string fileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(Student));
            Stream fStream;
            if (!File.Exists(fileName))
            {
                fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            else
            {
                fStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            }
            for (int i = 0; i < s.StudentsCount; i++)
            {
                x.Serialize(fStream, s[i]);
            }
            fStream.Close();
        }

    }
}

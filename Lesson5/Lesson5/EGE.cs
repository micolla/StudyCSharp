using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson5
{
    class EGE
    {
        StreamReader sr;
        int pupilCount;
        string[,] pupilInfo;

        /// <summary>
        /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
        /// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        /// </summary>
        /// <param name="filePath">Путь к файлу в кодировке UTF-8</param>
        public EGE(string filePath)
        {
            string tmpStr;
            string[] tmpstrAr;
            int i = 0;
            char[] splitChars = { ' ' };
            if (File.Exists(filePath))
            {
                sr = new StreamReader(filePath,Encoding.UTF8);
                if(!int.TryParse(sr.ReadLine(), out pupilCount))
                {
                    throw new Exception("В первой строке должно быть целое число учеников");
                }
                
                pupilInfo = new string[pupilCount, 6];
                while (!sr.EndOfStream && i <= pupilCount)
                {
                    tmpStr = sr.ReadLine();
                    tmpstrAr = tmpStr.Split(splitChars);
                    for (int j = 0; j < 5; j++)
                    {
                        pupilInfo[i, j] = tmpstrAr[j];
                    }
                    pupilInfo[i, 5] = 
                        $"{(int.Parse(pupilInfo[i, 2]) + int.Parse(pupilInfo[i, 3])+ int.Parse(pupilInfo[i, 4])) / 3.0}";
                    i++;
                }
                sr.Close();
            }
            else
                throw new FileNotFoundException($"Файла {filePath} не существует");
        }

        /// <summary>
        /// Определение самых низких значений средних оценок учеников
        /// </summary>
        /// <param name="n">число анализируемых низких оценок</param>
        /// <returns>Массив средних оценок</returns>
        public double[] GetLowestDegrees(int n)
        {
            double[] degrees = new double[n];
            double tmpAvgDegree;
            const int maxDegree = 10_000;
            for (int i = 0; i < degrees.Length; i++)
            {
                if (double.TryParse(pupilInfo[0, 5], out tmpAvgDegree) && (i == 0
                    || (i > 0 && tmpAvgDegree > degrees[i - 1])))
                {
                    degrees[i] = tmpAvgDegree;
                }
                else
                    degrees[i] = maxDegree;
                for (int j = 1; j < pupilInfo.GetLength(0); j++)
                {
                    if(double.TryParse(pupilInfo[j, 5], out tmpAvgDegree)){
                        if(degrees[i] > tmpAvgDegree&&
                            (i == 0||(i>0&& tmpAvgDegree > degrees[i - 1])))
                        {
                            degrees[i] = tmpAvgDegree;
                        }
                    }
                }
            }
            return degrees;
        }
        /// <summary>
        /// Определяет самых плохих учеников, которые имеют оценки из топ 3 самых плохих
        /// </summary>
        /// <returns>Массив string с именами и фамилиями</returns>
        public string[] GetWorsPupils()
        {
            const int cntDegrees = 3;
            List<string> pupils = new List<string>();
            double[] lowestDegrees = GetLowestDegrees(cntDegrees);
            for (int i = 0; i < lowestDegrees.Length; i++)
            {
                for (int j = 0; j < pupilInfo.GetLength(0); j++)
                {
                    if (Double.Parse(pupilInfo[j, 5]) == lowestDegrees[i])
                    {
                        pupils.Add(pupilInfo[j, 0] + " " + pupilInfo[j, 1]);
                    }
                }
            }
            return pupils.ToArray();
        }
        /// <summary>
        /// Выводит на экран массив с указанием, что это ученики
        /// </summary>
        /// <param name="ar">Массив string с именами учеников</param>
        public void PrintArray(string[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine($"{i+1} ученик {ar[i]}");
            }
        }
    }
}

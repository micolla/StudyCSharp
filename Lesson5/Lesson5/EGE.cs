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
        Dictionary<int, double> listOfStars;
        string[,] pupilInfo;

        public EGE(string filePath)
        {
            string tmpStr;
            string[] tmpstrAr;
            int i = 0;
            Dictionary<int,Double> minDegree;
            char[] splitChars = { ' ' };
            if (File.Exists(filePath))
            {
                sr = new StreamReader(filePath);
                if(!int.TryParse(sr.ReadLine(), out pupilCount))
                {
                    throw new Exception("В первой строке должно быть целое число учеников");
                }
                listOfStars = new Dictionary<int, double>(pupilCount);
                pupilInfo = new string[pupilCount, 5];
                while (!sr.EndOfStream && i<=pupilCount)
                {
                    tmpStr = sr.ReadLine();
                    tmpstrAr = tmpStr.Split(splitChars);
                    for (int j = 0; j < 5; j++)
                    {
                        pupilInfo[i, j] = tmpstrAr[j];
                    }
                    listOfStars[i] = (int.Parse(pupilInfo[i, 2]) + int.Parse(pupilInfo[i, 3])
                        + int.Parse(pupilInfo[i, 4]))/3;
                    i++;
                }
                
            }
            else
                throw new FileNotFoundException($"Файла {filePath} не существует");
        }
    }
}

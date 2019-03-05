using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4
{
    class Task5
    {
        int[,] myArray;
        int minElement;
        int maxElement;
        int sumElement;
        /// <summary>
        /// Заполнение квадратной матрицы случайными числами
        /// </summary>
        /// <param name="n">число элементов в строку или столбец</param>
        public Task5(int n)
        {
            myArray = new int[n, n];
            Random rnd = new Random();
            sumElement = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    myArray[i, j] = rnd.Next();
                    sumElement += myArray[i, j];
                    if (i == 0 && j == 0)
                    {
                        minElement = maxElement = myArray[i, j];
                    }
                    else if (minElement > myArray[i, j])
                    {
                        minElement = myArray[i, j];
                    }
                    else if (maxElement < myArray[i, j])
                    {
                        maxElement = myArray[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Заполнение квадратной матрицы из файла
        /// Сохранение в лог ошибок
        /// </summary>
        public Task5(string fileName)
        {
            string[] s;
            string[][] selem;
            int sInd=0;
            int rows=0, columns=0;
            string logFileName = "log.txt";
            if (!File.Exists(logFileName))
                File.Create(logFileName).Close();
            StreamWriter strWr = new StreamWriter(logFileName);
            strWr.WriteLine($"Начало работы {DateTime.Now}");
            if (File.Exists(fileName))
            {
                s = File.ReadAllLines(fileName);
                rows = s.Length;
                selem = new string[rows][];
                foreach(string c in s)
                {
                    c.Trim();
                    selem[sInd] =c.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if(columns<selem[sInd].Length)
                    {
                        columns = selem[sInd].Length;
                    }
                    sInd++;
                }
                myArray = new int[rows, columns];
                for (int i = 0; i < selem.Length; i++)
                {
                    for (int j = 0; j < selem[i].Length; j++)
                    {
                        if(!int.TryParse(selem[i][j].Trim(), out myArray[i, j]))
                        {
                            strWr.WriteLine($"Пропущено значение {selem[i][j].Trim()}");
                        }
                    }
                }
            }
            else
            {
                strWr.WriteLine($"Не найден файл {fileName}");
                strWr.Close();
                throw new FileNotFoundException();
            }
            strWr.Close();
        }

        public int SumAllElements()
        {
            return sumElement;
        }
        public int MinElement()
        {
            return minElement;
        }
        public int MaxElement()
        {
            return maxElement;
        }

        /// <summary>
        /// Возвращает сумму элементов, больше значения
        /// </summary>
        /// <param name="value;">Проверочое значение</param>
        public int SumElements(int value)
        {
            int summa=0;
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (value < myArray[i, j])
                    {
                        summa += myArray[i, j];
                    }
                }
            }
            return summa;
        }

        /// <summary>
        /// Возвращает индексы максимального элемента
        /// </summary>
        /// <param name="rowIndex">Результат инндекс в строке, -1 если не найдено</param>
        /// <param name="colIndex">Результат инндекс в колонке, -1 если не найдено</param>
        public void GetIndexOfValue(out int rowIndex, out int colIndex)
        {
            rowIndex = -1;
            colIndex = -1;
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (maxElement==myArray[i, j])
                    {
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }
        }
    }
}

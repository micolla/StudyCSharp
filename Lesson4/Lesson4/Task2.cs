using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4
{
    class Task2
    {
        static public int GetNumberGroups(int[] exampleArray)
        {
            int numberGroups = 0;
            if (exampleArray.Length > 1)
            {
                for (int i = 0; i < exampleArray.Length - 1; i++)
                {
                    if (exampleArray[i] % 3 == 0 ^ exampleArray[i + 1] % 3 == 0)
                        numberGroups++;
                }
            }
            return numberGroups;
        }
        static public int[] LoadToArray(string fileName)
        {
            int[] exampleArray;
            StreamReader s;
            int i = 0;
            if (File.Exists(fileName))
            {
                exampleArray = new int[File.ReadAllLines(fileName).Length];
                s = new StreamReader(fileName);
                while (!s.EndOfStream)
                {
                    if (!int.TryParse(s.ReadLine(), out exampleArray[i]))
                    {
                        Console.WriteLine($"На {i + 1} строке не число. Строка пропущена.");
                    }
                }
            }
            else
            {
                Console.Write($"Не найден файл {fileName}");
                throw new FileNotFoundException();
            }
            s.Close();
            return exampleArray;
        }
    }
}

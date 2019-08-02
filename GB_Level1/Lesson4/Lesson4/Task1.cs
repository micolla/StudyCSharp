using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Task1
    {
        int[] exampleArray;
        Random rnd = new Random();
        public Task1(int beginValue, int endValue, int numberElements)
        {
            exampleArray = new int[numberElements];
            for (int i = 0; i < exampleArray.Length; i++)
            {
                exampleArray[i] = rnd.Next(beginValue, endValue);
                Console.WriteLine(exampleArray[i]);
            }
        }

        public int GetNumberGroups()
        {
            int numberGroups = 0;
            if (exampleArray.Length > 1)
            {
                for (int i = 0; i < exampleArray.Length-1; i++)
                {
                        if (exampleArray[i]%3==0^ exampleArray[i+1] % 3 == 0)
                            numberGroups++;
                }
            }
            return numberGroups;
        }

    }
}

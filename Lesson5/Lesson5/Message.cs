using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Message
    {
        /// <summary>
        /// а) Вывести только те слова сообщения,  которые содержат не более n букв.
        /// </summary>
        /// <param name="msg">Текст</param>
        /// <param name="n">Количество символов</param>
        /// <param name="splitSymb">Массив с делителями</param>
        public static void PrintWords(string msg,int n,char[] splitSymb)
        {
            string[] words=msg.Split(splitSymb);
            foreach (var w in words)
            {
                if (w.Length == n)
                {
                    Console.WriteLine(w);
                }
            }
        }
        /// <summary>
        /// Вывести все слова из msg
        /// </summary>
        /// <param name="msg">Текст</param>
        /// <param name="splitSymb">Массив с делителями</param>
        public static void PrintWords(string msg, char[] splitSymb)
        {
            string[] words = msg.Split(splitSymb);
            foreach (var w in words)
            {
                    Console.WriteLine(w);
            }
        }

        /// <summary>
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="msg">Текст</param>
        /// <param name="c">Символ, на который заканчивается слово</param>
        /// <param name="splitSymb">Массив с делителями</param>
        public static string DeleteWords(string msg, char c, char[] splitSymb)
        {
            string[] words = msg.Split(splitSymb);
            StringBuilder s = new StringBuilder(msg.Length);
            foreach (var w in words)
            {
                if (w[w.Length - 1] == c)
                {
                    Console.WriteLine($"Удалено слово {w}");
                }
                else
                    s.Append(w+"\r\n");
            }
            return s.ToString();
        }
        /// <summary>
        /// в) Найти самое длинное слово сообщения.
        /// </summary>
        /// <param name="msg">Текст</param>
        /// <param name="splitSymb">Массив с делителями</param>
        /// <returns>Самое длинное слово</returns>
        public static string GetLongWord(string msg, char[] splitSymb)
        {
            string[] words = msg.Split(splitSymb);
            int ind = 0;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[ind].Length < words[i].Length)
                {
                    ind = i;
                }
            }
            return words[ind];
        }
        /// <summary>
        /// д) ***Создать метод, который производит частотный анализ текста. 
        /// В качестве параметра в него передается массив слов и текст, 
        /// в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
        /// Здесь требуется использовать класс Dictionary.
        /// </summary>
        /// <param name="words">Искомые слова</param>
        /// <param name="msg">Текст</param>
        /// <param name="splitSymb">Массив с делителями</param>
        public static void FreqAnalysis(string[] words,string msg,char[] splitSymb)
        {
            Dictionary<string, int> dictWords = new Dictionary<string, int>();
            string[] message= msg.Split(splitSymb);
            foreach (string s in words)
            {
                dictWords[s] = 0;
            }
            foreach (string s in message)
            {
                if (dictWords.ContainsKey(s))
                {
                    dictWords[s]++;
                }
            }
            Console.WriteLine("Результат частотного анализа");
            foreach (var d in dictWords)
            {
                Console.WriteLine($"{d.Value} {d.Key}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Counter
    {
        uint _commandCount;
        uint _currentNumber;
        uint _finalNumber;
        Stack<uint> st = new Stack<uint>();

        public string commandCount { get {return _commandCount.ToString("N0"); } }
        public string currentNumber { get { return _currentNumber.ToString("N0"); } }
        public string finalNumber { get { return _finalNumber.ToString("N0"); } }
        public string difference { get { return (_currentNumber-_finalNumber).ToString("N0"); } }
        Random r;

        public Counter()
        {
            _commandCount = 0;
            _currentNumber = 0;
            r = new Random();
            _finalNumber = (uint)r.Next();
        }
        /// <summary>
        /// Сброс в 0 и актуализация искомого числа
        /// </summary>
        /// <param name="command"></param>
        /// <param name="numb"></param>
        /// <param name="final"></param>
        public void Reset(ref string command, ref string numb,ref string final)
        {
            _commandCount = 0;
            _currentNumber = 0;
            r = new Random();
            _finalNumber = (uint)r.Next();
            command = commandCount;
            numb = currentNumber;
            final = finalNumber;
        }
        /// <summary>
        /// Сложение с 1
        /// </summary>
        /// <param name="command"></param>
        /// <param name="numb"></param>
        public void Add(ref string command,ref string numb)
        {
            st.Push(_currentNumber);
            Add(1);
            command = commandCount;
            numb = currentNumber;
        }
        /// <summary>
        /// Универсальная процедура сложения
        /// </summary>
        /// <param name="n">слагаемое</param>
        private void Add(uint n)
        {
            _commandCount++;
            _currentNumber += n;
        }
        /// <summary>
        /// Умножение на 2
        /// </summary>
        /// <param name="command"></param>
        /// <param name="numb"></param>
        public void Multi(ref string command, ref string numb)
        {
            st.Push(_currentNumber);
            Multi(2);
            command = commandCount;
            numb = currentNumber;
        }
        /// <summary>
        /// Универсальная процедура умножения
        /// </summary>
        /// <param name="n">множитель</param>
        private void Multi(uint n)
        {
            _commandCount++;
            _currentNumber *= n;
        }
        /// <summary>
        /// Проверка закончилась ли игра
        /// </summary>
        /// <returns>-1 проиграл, 1 выиграл, 0 недобор</returns>
        public int CheckResult()
        {
            int res;
            if (_currentNumber < _finalNumber)
                res = 0;
            else if (_currentNumber == _finalNumber)
                res = 1;
            else
                res = -1;
            return res;
        }

        /// <summary>
        /// Реализация команды отменить действие
        /// </summary>
        /// <param name="command"></param>
        /// <param name="numb"></param>
        public void Revert(ref string command, ref string numb)
        {
            if (st.Count > 0)
            {
                _commandCount--;
                _currentNumber = st.Pop();
                command = commandCount;
                numb = currentNumber;
            }
        }
    }
}

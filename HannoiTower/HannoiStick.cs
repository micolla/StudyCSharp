using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower
{
    class HannoiStick
    {
        //Stack<int> blocks;
        List<int> blocks;
        public int Count { get { return blocks.Count; } }
        public HannoiStick(int blockCnt)
        {
            blocks = new List<int>(blockCnt);//new Stack<int>(blockCnt);
            for (int i = 0; i < blockCnt; i++)
            {
                blocks.Add(i + 1);// Push(i+1);
            }
            
        }

        public void Push(int x)
        {
            blocks.Push(x);
        }

        public int Pop()
        {
            return blocks.Pop();
        }

        public int Show()
        {
            int tmp;
            tmp = blocks.Pop();
            //Console.WriteLine("{0}|", tmp);
            //blocks.Pop(tmp);
            return tmp;
        }
    }
}

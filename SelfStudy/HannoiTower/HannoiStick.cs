using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower
{
    class HannoiStick
    {
        //Stack<int> blocks;
        List<int> blocks;
        int last_index;
        public int Count { get { return last_index+1; } }
        public HannoiStick(int blockCnt)
        {
            blocks = new List<int>(blockCnt);//new Stack<int>(blockCnt);
            last_index = blockCnt-1;
            for (int i = 0; i < blockCnt; i++)
            {
                blocks.Add(blockCnt-i);// Push(i+1);
            }
            
        }

        public void Push(int x)
        {
            blocks.Add(x);
            last_index++;
        }

        public int Pop()
        {
            int ret=blocks[last_index];
            blocks.RemoveAt(last_index);
            last_index--;
            return ret;
        }

        public int this[int index]
        {
            get { return this.blocks[index]; }
        }
    }
}

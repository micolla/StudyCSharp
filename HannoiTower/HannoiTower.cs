using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower
{
    class HannoiTower
    {
        List<HannoiStick> state;
        private int blocksCnt { get; set; }
        int operations;
        public HannoiTower(int blocksCnt)
        {
            if (blocksCnt > 0)
            {
                this.blocksCnt = blocksCnt;
                this.state = new List<HannoiStick>() { new HannoiStick(blocksCnt), new HannoiStick(0), new HannoiStick(0)};
                this.operations = 0;
            }
            else
                throw new IndexOutOfRangeException("Необходимо указать положительное число блоков");
        }
        public void DoIt()
        {
            MoveAllTo(0,2,blocksCnt);
        }
        private void MoveAllTo(int from,int to,int n)
        {
            int temp = ((from+1) ^ (to+1))-1;
            if (n > 1)
            {
                MoveAllTo(from, temp, n - 1);
                MoveTo(from, to);
                MoveAllTo(temp, to, n - 1);
            }
            else
            {
                MoveTo(from,to);
            }
        }

        private void MoveTo(int from,int to)
        {
            operations++;
            state[to].Push(state[from].Pop());
            ShowCurrentState();
        }

        public void ShowCurrentState()
        {
            for (int i = blocksCnt; i > 0; i--)
            {
                for (int j = 0; j < state.Count; j++)
                {
                    Console.Write("{0}|", state[j].Count < i ? 0 : state[j][i-1]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(operations);
        }
    }
}

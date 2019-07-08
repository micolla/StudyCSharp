using System;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число блоков!");
            int blocks;
            int.TryParse(Console.ReadLine(), out blocks);
            HannoiTower dsf = new HannoiTower(blocks);
            
            dsf.DoIt();
            dsf.ShowCurrentState();
            Console.ReadLine();
        }
    }
}

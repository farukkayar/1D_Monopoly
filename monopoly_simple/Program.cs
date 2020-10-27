using System;
using System.Runtime.CompilerServices;

namespace _319
{
    class Program
    {
        static void Main(string[] args)
        {
            //Railroad a = new Railroad("Haydarpaşa", 500, 370);
            //GameSquare gs = new GameSquare();
            //Console.WriteLine(gs.getAssetType());
            Game g = new Game();
            Player[] arr = new Player[4];
            
            for(int i = 0; i < 4; i++)
            {
                arr[i] = new Player(false,i);
            }
            g.initPlayers(arr);
            int p = 0;

            for (int i = 0; p != -1; i++)
            {
                i = i % 4;
                string line = Console.ReadLine();
                p = int.Parse(line);
                g.displayPlayerInfo();
                int posx = g.parr[i].takeTurn();
                g.startBidRoutine(i,posx);

            }    
        }
    }
}
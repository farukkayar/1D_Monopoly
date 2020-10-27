using System;
using System.Collections.Generic;
using System.Text;

namespace _319
{
    class Game
    {
        const int playerSize = 4;
        const int sqSize = 40;
        GameSquare[] sqarr = new GameSquare[sqSize];
        public Player[] parr = new Player[playerSize];

        public Game()
        {
            
            init();
        }

        public void initPlayers(Player[] arr)
        {
            parr = arr;
        }

        public void init()
        {
            //Assets a = new Railroad("Haydarpaşa", 500, 370);
            //Assets a = new Railroad("Haydarpaşa", 500, 370);
            //Assets a = new Railroad("Haydarpaşa", 500, 370);
            //Assets a = new Railroad("Haydarpaşa", 500, 370);
            //GameSquare gs = new GameSquare(a);
            //GameSquare gs = new GameSquare(a);
            //GameSquare gs = new GameSquare(a);
            for(int i = 0; i < 40; i++)
            {
                if(i % 2 == 0)
                    sqarr[i] = new GameSquare(AssetType.railroad);
                else
                    sqarr[i] = new GameSquare(AssetType.property);

            }
        }

        public void startBidRoutine(int id, int posx)
        {
            displayGameSquare(posx);
            if (!sqarr[posx].isOwned)
            {
                int[] bidarr = new int[4];
                int winnerId = -1;
                for (int i = 0; i < playerSize; i++)
                {
                    bidarr[i] = parr[i].bid();
                }
                int max = -1;
                int maxId = -1;
                for (int i = 0; i < playerSize; i++)
                {
                    if (bidarr[i] > max)
                    {
                        max = bidarr[i];
                        maxId = i;
                    }
                }
                winnerId = maxId;
                Console.WriteLine("Winning bid rn is: " + max);
                if (maxId != id)
                {
                    int taketwo = parr[id].bid();
                    if (taketwo >= max)
                    {
                        winnerId = id;
                        max = taketwo;
                    }
                }
                if (max > 0)
                {
                    sqarr[posx].isOwned = true;
                    sqarr[posx].setOwner(parr[id]);
                }
                parr[id].money -= max;
                Console.WriteLine("Winning bid is: " + max + ".\nPlayer " + winnerId + " won! \n");
            }
            else
            {
                parr[id].money -= sqarr[posx].getRent();
                int ownerId = sqarr[posx].getOwnerId();
                parr[ownerId].money += sqarr[posx].getRent();


                Console.WriteLine("no bidding since this is owned");
            }
        }
        public void displayGameSquare(int posx)
        {
            sqarr[posx].displayInfo();
        }
        public void displayPlayerInfo()
        {
            for(int i = 0; i < 4; i++)
            {
                parr[i].info();
            }
        }
    }
}

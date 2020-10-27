using System;
using System.Collections.Generic;
using System.Text;

namespace _319
{
    class Player
    {
        //const
        public Player(bool h, int id)
        {
            isHost = h;
            hasVeto = true; 
            pos = 0;
            isJailed = false;
            playerId = id;
            player_name = "";
            money = 1500;
        }
        //properties
        string player_name;
        int playerId;
        bool isJailed;
        const int totalPropCount = 22;
        const int totalUtilityCount = 2;
        const int totalRailroadCount = 4;
        const int totalCardCount = 2;
        int assetCount;
        bool isHost;
        bool hasVeto;
        int pos;
        public int money;
        Assets[] assets = new Assets[totalPropCount + totalUtilityCount + totalCardCount + totalRailroadCount];

        //methods

        public void addAsset(Assets a)
        {
            //send input to database();
            int propCount = 0;
            bool pcheck = true;
            int utilityCount;
            int cardCount;

        }
        public int bid() ///////////?????????????????
        {
            bool valid = false;
            int bid = 0;
            while (!valid)
            {
                Console.WriteLine("Player " + playerId + ", What is your bid ?\n");
                string line = Console.ReadLine();
                bid = int.Parse(line);
                if (bid < money && bid > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid offer, needs to be non-negative integer");
                }
            }

            return bid;
        }

        public bool canBuild()
        {
            //ToDo
            return true;
        }
        public bool canPlay()
        {
            return !isJailed;
        }

        public void drawCard() //?
        {

        }
        public int getId()
        {
            return playerId;
        }
        public void goToJail()
        {
            isJailed = true;
            //pos = transform to jail;

        }

        public void info()
        {
            Console.WriteLine("Player " + playerId + " has " + money + " dollars.");
        }

        public void land()
        { //????? 

        }


        //calculates the next position of the player
        public int move(int[] arr)
        {
            int m = arr[0] + arr[1];
            pos = (pos + m) % 40;
            
            return pos;
        }

        public int[] rollDice()
        {
            Random rand = new Random();
            int x = rand.Next(1, 7);
            int y = rand.Next(1, 7);
            int[] toret = { x, y };
            Console.WriteLine("Player " + playerId + " has rolled " + x + " and " + y);
            return toret;
        }
        public int takeTurn()
        {
            int toret = move(rollDice());
            Console.WriteLine("Player " + playerId + " is at square " + pos);
            return toret;
        }
        public string toString()
        {
            string nruter = "Player " + playerId;
            return nruter;
        }

        public void trade() //????
        {

        }


        public bool veto()
        {
            //if the user wants to veto, it invokes this method
            return hasVeto;
        }



        

        
        


    }
}

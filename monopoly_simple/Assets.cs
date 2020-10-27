using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace _319
{
    public enum AssetType
    {
        property,
        railroad,
        utility,
        card,
        empty
    }
    class Assets
    {
        Player player;
      
        public AssetType asset_type;
        public Assets()
        {
            asset_type = AssetType.empty;
            player = null;
        }
        //methods
        public void setPlayer(Player p)
        {
            player = p;
        }
        
    }
    class Railroad : Assets
    {
        string p_name;
        int cost;
        int mortgageCost;
        const int railroadModifier = 5;
        int railroadCount;
        public int income;
        
        public Railroad()
        {
            p_name = "";
            cost = 0;
            mortgageCost = 0;
            railroadCount = 0;
            income = 0;
            asset_type = AssetType.railroad;
        }
        public Railroad(string p, int c, int mc)
        {
            p_name = "";
            cost = c;
            mortgageCost = mc;
            railroadCount = 0;
            income = 100;
            asset_type = AssetType.railroad;
        }

        public void displayRailroad()
        {
            Console.WriteLine("This is a railroad");
        }
    }

    class Property : Assets
    {
        string p_name;
        string p_color;
        int cost;
        int mortgageCost;
        public int[] income;
        const int totalDifferentRentTypes = 7;
        public int houseCount;
        int upgradeCost;
        public Property()
        {
            upgradeCost = 0;
            houseCount = 0;
            asset_type = AssetType.property;
            p_name = "";
            p_color = "";
            cost = 0;
            mortgageCost = 0;
            income = new int[totalDifferentRentTypes];
            income[0] = 100;
        }
        public void displayProperty()
        {
            Console.WriteLine("This is a property");
        }
    }
    class Utility : Assets
    {
        string p_name;
        int cost;
        int mortgageCost;
        int income;
        int utilityCount;
        const int utilityModifier = 10;
        public Utility()
        {
            p_name = "";
            cost = 0;
            mortgageCost = 0;
            income = 0;
            utilityCount = 0;
            asset_type = AssetType.utility;
        }
    }

    class Card : Assets
    {
        string p_name;
        
        public Card()
        {
            p_name = "";
            asset_type = AssetType.card;
        }
    }
}
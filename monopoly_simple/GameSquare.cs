using System;
using System.Collections.Generic;
using System.Text;

namespace _319
{
    class GameSquare
    {
        public bool isOwned;
        Player owner;
        Property p;
        Utility u;
        Railroad r;
        Card c;
        Assets[] asarr = new Assets[4];
        //var
        public GameSquare(AssetType t)
        {
            isOwned = false; // change in case of banker ????
            initgs(t);
            asarr[0] = p;
            asarr[1] = u;
            asarr[2] = r;
            asarr[3] = c;

        }

        public void initgs(AssetType t)
        {
            switch (t)
            {
                case AssetType.railroad:
                    r = new Railroad();
                    p = null;
                    u = null;
                    c = null;
                    break;
                case AssetType.utility:
                    r = null;
                    p = null;
                    u = new Utility();
                    c = null;
                    break;
                case AssetType.property:
                    r = null;
                    p = new Property();
                    u = null;
                    c = null;

                    break;
                case AssetType.card:
                    r = null;
                    p = null;
                    u = null;
                    c = new Card();

                    break;
                default:
                    break;
            }
        }

        public AssetType getAssetType()
        {
            for(int i =0; i < 4; i++)
            {
                
                if (asarr[i] != null)
                {
                    return asarr[i].asset_type;
                }
            }
            return AssetType.empty;
        }

        public void setOwner(Player p) {
            owner = p;
        }

        public void displayInfo()
        {
            if (!isOwned)
            {
                AssetType at = getAssetType();
                switch (at)
                {
                    case AssetType.railroad:
                        r.displayRailroad();
                        break;
                    case AssetType.utility:
                        break;
                    case AssetType.property:
                        p.displayProperty();
                        break;
                    case AssetType.card:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("This property is owned by " + owner.toString());
            }
        }
        public int getRent()
        {
            AssetType at = getAssetType();
            switch (at)
            {
                case AssetType.railroad:
                    Console.WriteLine("rent " + r.income);
                    return r.income;
                    break;
                case AssetType.utility:
                    Console.WriteLine("rent " + 0);
                    return 0;
                    break;
                case AssetType.property:
                    Console.WriteLine("rent " + p.income[p.houseCount]);
                    return p.income[p.houseCount];
                    break;
                case AssetType.card:
                    Console.WriteLine("rent " + 0);
                    return 0;
                    break;
                default:
                    return 0;
            }
        }
        public int getOwnerId()
        {
            if (isOwned)
                return owner.getId();
            else
                return -1;
        }
    }
}

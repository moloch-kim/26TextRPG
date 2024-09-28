using _26TextRPG.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Dungeon
{
    public enum Shoplist
    {
        Armor = 100, Consum = 200, Weapon = 300,
        Startshop = 1
    }
    public class Shop
    {
        public List<_26TextRPG.Item.Item> ItemsForSale { get; set; }

        //public Shop()
    }
}

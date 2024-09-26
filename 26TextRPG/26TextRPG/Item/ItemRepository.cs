using _26TextRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item
{
    internal class ItemRepository
    {
        public static List<IItem> Allitems {  get; set; }
        public static List<Armor> Armors { get; set; }
        public static List<Potion> Potions { get; set; }
        public static List<Weapon> Weapons { get; set; }

        // 정렬 기준은 솔루션 탐색기

        static ItemRepository()
        {
            Armors = new List<Armor>()
            {
                new(1000,"로브", "매우 편하지만 방어력은 전무합니다.", 0 , 10),
                new(1001,"가죽 갑옷", "가볍고 유연한 가죽 갑옷입니다.", 2, 30),

            };
            Potions = new List<Potion>()
            {
                new(2000, 1 ,"회복 물약", "들이켜서 상처를 치료할수 있습니다.", 20, 40),
                // 아이템 추가
            };
            Weapons = new List<Weapon>() 
            {
                // 아이템 추가
            };

            Allitems = new List<IItem>();
            Allitems.AddRange(Armors);
            Allitems.AddRange(Potions);
            Allitems.AddRange(Weapons);
        }

        public static IItem GetItemByID(int id)
        {
            return Allitems.FirstOrDefault(item => item.ID == id);
        }

        public static IItem GetItemByName(string name)
        {
            return Allitems.FirstOrDefault(item => item.Name == name);
        }
    }
}

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
                new(1000,"로브", "매우 편하지만 방어력은 전무합니다.", 0 , 0, 10),
                new(1001,"가죽 갑옷", "가볍고 유연한 가죽 갑옷입니다.", 2, 2, 30),
                new(1002,"미늘 갑옷", "가벼움을 유지하면서 최대한 방어력을 끌어올렸습니다.", 4, 4, 60),
                new(1003,"사슬 갑옷", "사슬로 이루어진 균형잡힌 갑옷입니다.", 6, 6, 90),
                new(1004,"판금 갑옷", "무겁고 튼튼한 기사들의 갑옷입니다.", 8 , 8, 120),
                new(1005,"악마의 판금 갑옷", "터무니없이 무겁고 튼튼합니다.", 12, 12, 180),
            };
            Potions = new List<Potion>()
            {
                new(2000, 1 ,"회복 물약", "들이켜서 상처를 치료할수 있습니다.", 20, 40),
                // 아이템 추가
            };
            Weapons = new List<Weapon>() 
            {
                new(3000, 2, "롱소드", "다재다능해 믿음직한 롱소드 입니다." , 5 , 5, 40),
                new(3001, 1, "메이스", "강력한 타격으로 적을 제압합니다.", 5 , 5, 40),
                new(3002, 1, "배틀엑스", "강력한 전투도끼 입니다.", 8, 2, 60),
                
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

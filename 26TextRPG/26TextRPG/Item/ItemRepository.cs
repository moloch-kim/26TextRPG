using _26TextRPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    internal class ItemRepository
    {
        public static List<Item> Allitems {  get; private set; }
        public static List<IEquipable> Gears { get; private set; }
        public static List<Armor> Armors { get; private set; }
        public static List<Potion> Potions { get; private set; }
        public static List<Weapon> Weapons { get; private set; }
        // 정렬 기준은 솔루션 탐색기
        static ItemRepository()
        {
            Random random = new Random();
            Armors = new List<Armor>() // 방어구 리스트
            {
                new(1000,"로브", "매우 편하지만 방어력은 전무합니다.", 0 , 0, 50),
                new(1001,"가죽 갑옷", "가볍고 유연한 가죽 갑옷입니다.", 2, 2, 100),
                new(1002,"미늘 갑옷", "가벼움을 유지하면서 최대한 방어력을 끌어올렸습니다.", 4, 4, 200),
                new(1003,"사슬 갑옷", "사슬로 이루어진 균형잡힌 갑옷입니다.", 8, 6, 300),
                new(1004,"판금 갑옷", "무겁고 튼튼한 기사들의 갑옷입니다.", 10 , 8, 500),
                new(1005,"악마의 판금 갑옷", "터무니없이 무겁고 튼튼합니다.", 20, 12, 1000),
                new(1006,"무쇠 강화 슈트", "살아있는 철벽이 될수있는 기회입니다.", 60, 24, 2500),
                new(1007,"용비늘 갑옷", "매우 가볍고 튼튼한 갑옷입니다.", 12, 4, 1500),
                new(1008,"공허 피갑", "몸이 더 가벼워지는 기묘한 갑옷입니다.", 0, -10, 1200),
                new(1009,"광전사의 갑주", "매우 튼튼하지만 더이상 당신이 움직이는게 아닙니다.", 16, 0, 4500)
            };
            Potions = new List<Potion>() // 포션 리스트
            {
                new(2000, 1 ,"회복 물약", "들이켜서 체력을 회복할수 있습니다.", 20, 40),
                new(2001, 1 ,"회복 영약", "들이켜서 체력을 크게 회복할수 있습니다.", 60, 120),
                new(2002, 2 ,"힘의 물약", "들이키면 잠시동안 공격력이 증가합니다.", 30 , 50),
                new(2003, 2 ,"힘의 영약", "들이키면 잠시동안 공격력이 매우 증가합니다", 60 , 100),
                new(2004, 3 ,"용기의 물약", "들이키면 잠시동안 방어력이 증가합니다.", 30 , 50),
                new(2005, 3 ,"용기의 물약", "들이키면 잠시동안 방어력이 매우 증가합니다.", 60, 100),
                new(2006, 4 ,"가속의 물약", "들이키면 잠시동안 속도가 증가합니다.", 10, 100),
                new(2007, 4 ,"가속의 영약", "들이키면 잠시동안 속도가 매우 증가합니다.", 20, 200),
                new(2008, 5 ,"축복의 물약", "들이키면 잠시동안 모든 능력치가 증가합니다!", 10, 500),
                new(2009, 5, "축복의 영약", "들이키면 잠시동안 모든 능력치가 매우 증가합니다!", 20, 1200),
                new(2010, random.Next(1,5), "혼돈의 영약", "어떤 효과가 나올지 예측할수 없습니다.", random.Next(-20, 80), 120)
                // 아이템 추가
            };
            Weapons = new List<Weapon>()  // 무기 리스트
            {
                new(3000, "롱소드", "다재다능해 믿음직한 롱소드 입니다." , 5 , 2, 250),
                new(3001, "메이스", "강력한 타격으로 적을 제압합니다.", 5 , 2, 250),
                new(3002, "배틀엑스", "강력한 전투도끼 입니다.", 10, 4, 400),
                new(3003, "야구방망이", "놀랍도록 휘두르기 편한 양손 곤봉입니다.", 6, 3, 300),
                new(3004, "모닝스타", "가시가 달려 치명적인 메이스입니다.", 12, 6, 800),
                new(3005, "단검", "매우 가벼운 단검입니다.", 2, 0, 150),
                new(3006, "대검", "매우 무겁지만 휘두르기만 하면 뭐든 동강냅니다.", 15, 8, 1000),
                new(3007, "스위프트소드", "검신에 바람을 둘러 속도가 빨라지는 마법이 깃들었습니다.", 5, -10 , 2000),
                new(3008, "거인파괴자", "매우 무겁지만 그만한 상대를 만나면 매우 효과적입니다.", 50, 25, 2500),
                new(3009, "엑스칼리버", "전설속의 명검입니다.", 25, 2, 4500),
                new(3010, "단궁", "기초적인 단궁 입니다.", 10, 4, 450),
                new(3011, "장궁", "강력한 힘이 담긴 장궁입니다.", 20, 8, 800),
                new(3012, "곡궁", "유연한 재료로 만들어 어느 상황에서도 효과적입니다.", 20, 4, 1500),
                new(3013, "흑각궁", "활의 나라에서 비롯한 전설의 활입니다.", 40, 4, 4500),
                new(3014, "스위프트보우", "활시위에 바람을 둘러 속도가 빨라지는 마법이 깃들었습니다.", 10, -5, 2500),
                new(3015, "발리스타", "공성병기를 직접 들고 쏘는건 미친짓일겁니다.", 60, 30, 2500)
                // 아이템 추가
            };
            Gears = new List<IEquipable>(); // 장비 리스트 = 무기 + 방어구
            Gears.AddRange(Armors);
            Gears.AddRange(Weapons);

            Allitems = new List<Item>();
            Allitems.AddRange(Weapons);
            Allitems.AddRange(Potions);
            Allitems.AddRange(Armors);
        }

        public static Item GetItemByID(int id)
        {
            return Allitems.FirstOrDefault(item => item.ID == id);
        }

        public static Item GetItemByName(string name)
        {
            return Allitems.FirstOrDefault(item => item.Name == name);
        }
        public static Armor GetRandomArmor()
        {
            Random random = new Random();
            int index = random.Next(0, Armors.Count - 1);
            return Armors[index];
        }
        public static Potion GetRandomPotion()
        {
            Random random = new Random();
            int index = random.Next(0, Potions.Count - 1);
            return Potions[index];
        }
        public static Weapon GetRandomWeapon()
        {
            Random random = new Random();
            int index = random.Next(0, Weapons.Count -1);
            return Weapons[index];
        }

        public static void Inventory()
        {
            bool isIn = true;
            while (isIn)
            {
                Player playerData = Player.Instance;
                if (playerData.Inventory.Count == 0)
                {
                    Console.WriteLine("인벤토리가 비어 있습니다.");
                    return;
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("인벤토리 아이템 목록:");
                for (int i = 0; i < playerData.Inventory.Count; i++)
                {
                    Item item = playerData.Inventory[i];
                    string itemType = item is Weapon ? "무기" : item is Armor ? "방어구" : "아이템";

                    // 아이템이 장착된 상태인지 확인
                    bool isEquipped = false;
                    if (item == playerData.EquipedWeapon || item == playerData.EquipedArmor)
                    {
                        isEquipped = true;
                    }
                    // 장착된 아이템 앞에 [E] 추가
                    string equippedIndicator = isEquipped ? "[E] " : "";


                    Console.WriteLine($"{i + 1}. {equippedIndicator}[{itemType}] {item.Name}");
                }
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("사용하거나 장착할 아이템의 번호를 입력하세요 (나가기 : I )");
                string input = Console.ReadLine();
                int choice;
                bool isNum = int.TryParse(input, out choice);

                if (input == "i" || input == "I")
                {
                    Console.WriteLine("인벤토리에서 나갑니다.");
                    isIn = false;
                    return;
                }
                else if (!isNum)
                {
                    Console.WriteLine("해당하는 숫자를 입력하세요.");
                }
                else if (choice > 0 && choice <= playerData.Inventory.Count)
                {
                    Item item = playerData.Inventory[choice - 1];
                    item.UseItem();
                }
            }
            



        }

    }
}

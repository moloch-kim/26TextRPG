using _26TextRPG;
using _26TextRPG.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Dungeon
{
    public enum Shoplist
    {
        Startshop = 0, Gearshop = 1, ConsumerShop = 2, ArmorShop = 3, WeaponShop = 4 
    }
    public class Shop
    {
        public List<Item> ItemsForSale { get; set; }
        public Shop(Shoplist shoplist)
        {
            ItemsForSale = new List<Item>();
            Random random = new Random();
            switch ((int)shoplist)
            {
                case 0:
                    ItemsForSale = new List<Item>
                {
                    ItemRepository.GetItemByID(1000),
                    ItemRepository.GetItemByID(1001),
                    ItemRepository.GetItemByID(1002),
                    ItemRepository.GetItemByID(1003),
                    ItemRepository.GetItemByID(2000),
                    ItemRepository.GetItemByID(3000),
                    ItemRepository.GetItemByID(3001),
                    ItemRepository.GetItemByID(3002),
                    ItemRepository.GetItemByID(3010)
                };
                    break;
                case 1:
                    for (int i = 0; i < random.Next(6, 10); i++)
                    {
                        int coinflip = random.Next(1, 101);
                        if (coinflip >= 50)
                        {
                            ItemsForSale.Add(ItemRepository.GetRandomWeapon());
                        }
                        else
                        {
                            ItemsForSale.Add(ItemRepository.GetRandomArmor());
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < random.Next(6, 10); i++)
                    {
                        ItemsForSale.Add(ItemRepository.GetRandomPotion());
                    }
                    break;
                case 3:
                    for (int i = 0; i < random.Next(6, 10); i++)
                    {
                        ItemsForSale.Add(ItemRepository.GetRandomArmor());
                    }
                    break;
                case 4:
                    for (int i = 0; i < random.Next(6, 10); i++)
                    {
                        ItemsForSale.Add(ItemRepository.GetRandomWeapon());
                    }
                    break;
            }
        }

        public void DisplayItems() // 판매 아이템 출력
        {
            Console.WriteLine("상점 아이템 목록:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < ItemsForSale.Count; i++)
            {
                var item = ItemsForSale[i];

                if (item == null)
                {
                    Console.WriteLine($"디버그: ItemsForSale[{i}]가 null입니다.");
                    continue;
                }
                Console.WriteLine($"{i + 1}. {ItemsForSale[i].Name}({ItemsForSale[i].Value}Gold): {ItemsForSale[i].Description} - {ItemsForSale[i].GetType().Name}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void BuyItem() // 아이템 구매 메소드
        {
            Player playerData = Player.Instance;
            Console.Clear();
            TypingEffect("상점에 입장했습니다!", 40);
            bool InShop = true;
            while (InShop)
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"현재 골드: {playerData.Gold}골드");
                DisplayItems();
                Console.WriteLine("구매하기 : D");
                Console.WriteLine("판매하기 : S");
                Console.WriteLine("나가기 : ESC ");
                Console.WriteLine(); Thread.Sleep(100);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.S://판매상점
                        SellItem();
                        break;
                    case ConsoleKey.D://구매상점
                        Console.WriteLine("");
                        TypingEffect("구매할 아이템의 번호를 입력하세요.(취소하려면 0 입력) :", 40);
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int choice))
                        {
                            if (choice == 0)
                            {
                                TypingEffect("구매를 취소했습니다.", 40);
                                Console.WriteLine(); Thread.Sleep(100);
                            }
                            else if (choice > 0 && choice <= ItemsForSale.Count)
                            {
                                Item selectedItem = ItemsForSale[choice - 1];

                                if (playerData.Gold >= selectedItem.Value)
                                {
                                    playerData.Gold -= selectedItem.Value;
                                    playerData.Inventory.Add(selectedItem);
                                    ItemsForSale.RemoveAt(choice - 1);
                                    TypingEffect($"{selectedItem.Name}을(를) 구매하여 인벤토리에 추가했습니다.", 40);
                                    Console.WriteLine();
                                    TypingEffect($"남은 골드: {playerData.Gold}골드", 40); Console.WriteLine(); Thread.Sleep(100);
                                }
                                else
                                {
                                    TypingEffect("골드가 부족하여 아이템을 구매할 수 없습니다.", 40);
                                    Console.WriteLine(); Thread.Sleep(100);
                                }
                            }
                            else
                            {
                                TypingEffect("잘못된 선택입니다.", 40);
                            }
                        }
                        break;
                    case ConsoleKey.Escape://나가기
                        InShop = false;
                        TypingEffect("상점에서 나갔습니다.", 40);
                        Console.WriteLine(); Thread.Sleep(100);
                        break;
                }
            }
        }

        public void SellItem()
        {
            Player playerData = Player.Instance;
            if (playerData.Inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
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


                Console.WriteLine($"{i + 1}. {equippedIndicator}[{itemType}] {item.Name} : " + item.Value / 5);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("판매할 아이템을 선택하세요 (취소하려면 0 입력)");
            string input = Console.ReadLine();

            if(int.TryParse(input, out int choice))
            {
                if (choice == 0)
                {
                    TypingEffect("판매를 취소했습니다.", 40);
                    Console.WriteLine(); Thread.Sleep(100);
                    return;
                }

                if (choice > 0 && choice <= playerData.Inventory.Count)
                {
                    Item selectedItem = playerData.Inventory[choice - 1];
                    if (selectedItem == playerData.EquipedWeapon || selectedItem == playerData.EquipedArmor)
                    {
                        TypingEffect("장착중인 아이템은 판매할수 없습니다.", 40);
                        Console.WriteLine(); Thread.Sleep(100);
                    }
                    else
                    {
                        playerData.Gold += selectedItem.Value / 5;
                        playerData.Inventory.Remove(selectedItem);
                        TypingEffect($"{selectedItem.Name}을(를) 판매하여 {selectedItem.Value / 5}만큼의 Gold를 획득했습니다.", 40);
                        Console.WriteLine();
                        TypingEffect($"남은 골드: {playerData.Gold}골드", 40); Console.WriteLine(); Thread.Sleep(100);
                    }
                }
                else
                {
                    TypingEffect("잘못된 선택입니다.", 40);
                    Console.WriteLine(); Thread.Sleep(100);
                }
            }
            else
            {
                TypingEffect("숫자를 입력해주세요.", 40);
                Console.WriteLine(); Thread.Sleep(100);
            }
            Console.Clear();
        }

        private void TypingEffect(string text, int delay) // (타이핑을 직접 치는것 같은 효과) srting 문자열과 int 딜레이 값을 넣어주면
        {
            foreach (char c in text)// text에 들어있는 문자열을 foreach를 이용해 순서대로 c에 문자로 담아줌
            {
                Console.Write(c); //c에 담긴 문자를 출력
                Thread.Sleep(delay);// 설정한 딜레이만큼 슬립
            }// 문자열을 문자로 변환하여 차례대로 출력하면서 문자 사이사이에 딜레이를 주어 타이핑 효과를 만듦
        }

    }
}

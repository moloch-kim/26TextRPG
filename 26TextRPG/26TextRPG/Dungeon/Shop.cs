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
        Player playerData = Player.Instance;
        public List<Item> ItemsForSale { get; set; }
        MainScene mainScene = new MainScene();
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
                    ItemRepository.GetItemByID(3002)
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
            Console.WriteLine($"ItemsForSale.Count = {ItemsForSale.Count}");
            Console.WriteLine("상점 아이템 목록:");
            Console.WriteLine("--------------------------------------------------------------------");
            for (int i = 0; i < ItemsForSale.Count; i++)
            {
                var item = ItemsForSale[i];

                if (item == null)
                {
                    Console.WriteLine($"디버그: ItemsForSale[{i}]가 null입니다.");
                    continue;
                }

                // 각 프로퍼티가 null인지 확인
                //string name = item.Name ?? "이름 없음";
                //string description = item.Description ?? "설명 없음";
                //string itemType = item.GetType().Name ?? "타입 없음";
                //int value = item.Value;

                Console.WriteLine($"{i + 1}. {ItemsForSale[i].Name}({ItemsForSale[i].Value}Gold): {ItemsForSale[i].Description} - {ItemsForSale[i].GetType().Name}");
            }
            //for (int i = 0; i < ItemsForSale.Count; i++)
            //{
            //    if (ItemsForSale[i] != null)
            //    {
            //        Console.WriteLine($"{i + 1}. {ItemsForSale[i].Name}({ItemsForSale[i].Value}Gold): {ItemsForSale[i].Description}");
            //    }    
            //}
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void BuyItem() // 아이템 구매 메소드
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"현재 골드: {playerData.Gold}골드");
            DisplayItems();
            mainScene.TypingEffect("구매할 아이템의 번호를 입력하세요 (취소하려면 0 입력):" , 40);
            Console.WriteLine();


            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    mainScene.TypingEffect("구매를 취소했습니다.", 40);
                    Console.WriteLine();
                    return;
                }

                if (choice > 0 && choice <= ItemsForSale.Count)
                {
                    Item selectedItem = ItemsForSale[choice - 1];

                    if (playerData.Gold >= selectedItem.Value)
                    {
                        playerData.Gold -= selectedItem.Value;
                        playerData.Inventory.Add(selectedItem);
                        ItemsForSale.RemoveAt(choice - 1);
                        mainScene.TypingEffect($"{selectedItem.Name}을(를) 구매하여 인벤토리에 추가했습니다." , 40);
                        Console.WriteLine();
                        mainScene.TypingEffect($"남은 골드: {playerData.Gold}골드", 40);
                    }
                    else
                    {
                        mainScene.TypingEffect("골드가 부족하여 아이템을 구매할 수 없습니다.", 40);
                        Console.WriteLine();
                    }
                }
                else
                {
                    mainScene.TypingEffect("잘못된 선택입니다.", 40);
                    Console.WriteLine();
                }
            }
            else
            {
                mainScene.TypingEffect("숫자를 입력해주세요.", 40);
                Console.WriteLine();
            }
        }
    }
}

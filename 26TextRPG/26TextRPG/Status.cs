// using _26TextRPG;

// public class Status
// {
//     Player playerData = Player.Instance;
//     public Shop(Shoplist shoplist)
//     {
//         ItemsForSale = new List<Item>();
//         Random random = new Random();
//         switch ((int)shoplist)
//         {
//             case 0:
//                 ItemsForSale = new List<Item>
//             {
//                 ItemRepository.GetItemByID(1000),
//                 ItemRepository.GetItemByID(1001),
//                 ItemRepository.GetItemByID(1002),
//                 ItemRepository.GetItemByID(1003),
//                 ItemRepository.GetItemByID(2000),
//                 ItemRepository.GetItemByID(3000),
//                 ItemRepository.GetItemByID(3001),
//                 ItemRepository.GetItemByID(3002)
//             };
//                 break;
//             case 1:
//                 for (int i = 0; i < random.Next(6, 10); i++)
//                 {
//                     int coinflip = random.Next(1, 101);
//                     if (coinflip >= 50)
//                     {
//                         ItemsForSale.Add(ItemRepository.GetRandomWeapon());
//                     }
//                     else
//                     {
//                         ItemsForSale.Add(ItemRepository.GetRandomArmor());
//                     }
//                 }
//                 break;
//             case 2:
//                 for (int i = 0; i < random.Next(6, 10); i++)
//                 {
//                     ItemsForSale.Add(ItemRepository.GetRandomPotion());
//                 }
//                 break;
//             case 3:
//                 for (int i = 0; i < random.Next(6, 10); i++)
//                 {
//                     ItemsForSale.Add(ItemRepository.GetRandomArmor());
//                 }
//                 break;
//             case 4:
//                 for (int i = 0; i < random.Next(6, 10); i++)
//                 {
//                     ItemsForSale.Add(ItemRepository.GetRandomWeapon());
//                 }
//                 break;
//         }
//     }

//     public void DisplayStatus() // 스탯 출력
//     {
//         // 얘내 둘도 클래스에 집어넣어도될듯
//         int enforceAttack = playerData.AttackPower - playerData.BaseAttackPower;
//         int enforceDefense = playerData.DefensePower - playerData.BaseDefensePower;

//         Console.WriteLine("스탯 보기: ");
//         Console.WriteLine("캐릭터의 정보 및 스탯이 표시됩니다.");
//         Console.WriteLine("--------------------------------------------------------------------");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"직업 : ({playerData.Job} )");

//         if (enforceAttack == 0) { Console.WriteLine($"{playerData.AttackPower}"); }
//         else { Console.WriteLine($"{playerData.AttackPower} (+{enforceAttack})"); }

//         if (enforceDefense == 0) { Console.WriteLine($"{playerData.DefensePower}"); }
//         else { Console.WriteLine($"{playerData.DefensePower} (+{enforceDefense})"); }

//         Console.WriteLine($"체 력 : {playerData.MaxHealth}");
//         Console.WriteLine($"Gold : . {playerData.Gold}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine("--------------------------------------------------------------------");
//         Console.WriteLine();
//     }
//     public void BuyItem() // 아이템 구매 메소드
//     {
//         Player playerData = Player.Instance;
//         Console.Clear();
//         TypingEffect("상점에 입장했습니다!", 40);
//         bool InShop = true;
//         while (InShop)
//         {
            
//             Console.WriteLine();
//             Console.WriteLine("--------------------------------------------------------------------");
//             Console.WriteLine($"현재 골드: {playerData.Gold}골드");
//             DisplayItems();
//             Console.WriteLine("나가기 : P"); 
//             TypingEffect("구매할 아이템의 번호를 입력하세요 (취소하려면 0 입력):", 40);
//             Console.WriteLine(); Thread.Sleep(100);
//             string input = Console.ReadLine();
//             if (input == "p" || input == "P")
//             {
//                 InShop = false;
//                 TypingEffect("상점에서 나갔습니다.", 40);
//                 Console.WriteLine(); Thread.Sleep(100);
//             }
//             else if (int.TryParse(input, out int choice))
//             {
//                 if (choice == 0)
//                 {
//                     TypingEffect("구매를 취소했습니다.", 40);
//                     Console.WriteLine(); Thread.Sleep(100);
//                     return;
//                 }

//                 if (choice > 0 && choice <= ItemsForSale.Count)
//                 {
//                     Item selectedItem = ItemsForSale[choice - 1];

//                     if (playerData.Gold >= selectedItem.Value)
//                     {
//                         playerData.Gold -= selectedItem.Value;
//                         playerData.Inventory.Add(selectedItem);
//                         ItemsForSale.RemoveAt(choice - 1);
//                         TypingEffect($"{selectedItem.Name}을(를) 구매하여 인벤토리에 추가했습니다.", 40);
//                         Console.WriteLine();
//                             TypingEffect($"남은 골드: {playerData.Gold}골드", 40); Console.WriteLine(); Thread.Sleep(100);
//                     }
//                     else
//                     {
//                         TypingEffect("골드가 부족하여 아이템을 구매할 수 없습니다.", 40); 
//                         Console.WriteLine(); Thread.Sleep(100);
//                     }
//                 }
//                 else
//                 {
//                     TypingEffect("잘못된 선택입니다.", 40); 
//                     Console.WriteLine(); Thread.Sleep(100);
//                 }
//             }
//             else
//             {
//                 TypingEffect("숫자를 입력해주세요.", 40); 
//                 Console.WriteLine(); Thread.Sleep(100);
//             }
//             Console.Clear();
//         }
//     }
//     private void TypingEffect(string text, int delay) // (타이핑을 직접 치는것 같은 효과) srting 문자열과 int 딜레이 값을 넣어주면
//     {
//         foreach (char c in text)// text에 들어있는 문자열을 foreach를 이용해 순서대로 c에 문자로 담아줌
//         {
//             Console.Write(c); //c에 담긴 문자를 출력
//             Thread.Sleep(delay);// 설정한 딜레이만큼 슬립
//         }// 문자열을 문자로 변환하여 차례대로 출력하면서 문자 사이사이에 딜레이를 주어 타이핑 효과를 만듦
//     }

// }


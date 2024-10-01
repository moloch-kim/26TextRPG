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

//     public void DisplayStatus() // ���� ���
//     {
//         // �곻 �ѵ� Ŭ������ ����־�ɵ�
//         int enforceAttack = playerData.AttackPower - playerData.BaseAttackPower;
//         int enforceDefense = playerData.DefensePower - playerData.BaseDefensePower;

//         Console.WriteLine("���� ����: ");
//         Console.WriteLine("ĳ������ ���� �� ������ ǥ�õ˴ϴ�.");
//         Console.WriteLine("--------------------------------------------------------------------");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"���� : ({playerData.Job} )");

//         if (enforceAttack == 0) { Console.WriteLine($"{playerData.AttackPower}"); }
//         else { Console.WriteLine($"{playerData.AttackPower} (+{enforceAttack})"); }

//         if (enforceDefense == 0) { Console.WriteLine($"{playerData.DefensePower}"); }
//         else { Console.WriteLine($"{playerData.DefensePower} (+{enforceDefense})"); }

//         Console.WriteLine($"ü �� : {playerData.MaxHealth}");
//         Console.WriteLine($"Gold : . {playerData.Gold}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine($"Lv. {playerData.Level}");
//         Console.WriteLine("--------------------------------------------------------------------");
//         Console.WriteLine();
//     }
//     public void BuyItem() // ������ ���� �޼ҵ�
//     {
//         Player playerData = Player.Instance;
//         Console.Clear();
//         TypingEffect("������ �����߽��ϴ�!", 40);
//         bool InShop = true;
//         while (InShop)
//         {
            
//             Console.WriteLine();
//             Console.WriteLine("--------------------------------------------------------------------");
//             Console.WriteLine($"���� ���: {playerData.Gold}���");
//             DisplayItems();
//             Console.WriteLine("������ : P"); 
//             TypingEffect("������ �������� ��ȣ�� �Է��ϼ��� (����Ϸ��� 0 �Է�):", 40);
//             Console.WriteLine(); Thread.Sleep(100);
//             string input = Console.ReadLine();
//             if (input == "p" || input == "P")
//             {
//                 InShop = false;
//                 TypingEffect("�������� �������ϴ�.", 40);
//                 Console.WriteLine(); Thread.Sleep(100);
//             }
//             else if (int.TryParse(input, out int choice))
//             {
//                 if (choice == 0)
//                 {
//                     TypingEffect("���Ÿ� ����߽��ϴ�.", 40);
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
//                         TypingEffect($"{selectedItem.Name}��(��) �����Ͽ� �κ��丮�� �߰��߽��ϴ�.", 40);
//                         Console.WriteLine();
//                             TypingEffect($"���� ���: {playerData.Gold}���", 40); Console.WriteLine(); Thread.Sleep(100);
//                     }
//                     else
//                     {
//                         TypingEffect("��尡 �����Ͽ� �������� ������ �� �����ϴ�.", 40); 
//                         Console.WriteLine(); Thread.Sleep(100);
//                     }
//                 }
//                 else
//                 {
//                     TypingEffect("�߸��� �����Դϴ�.", 40); 
//                     Console.WriteLine(); Thread.Sleep(100);
//                 }
//             }
//             else
//             {
//                 TypingEffect("���ڸ� �Է����ּ���.", 40); 
//                 Console.WriteLine(); Thread.Sleep(100);
//             }
//             Console.Clear();
//         }
//     }
//     private void TypingEffect(string text, int delay) // (Ÿ������ ���� ġ�°� ���� ȿ��) srting ���ڿ��� int ������ ���� �־��ָ�
//     {
//         foreach (char c in text)// text�� ����ִ� ���ڿ��� foreach�� �̿��� ������� c�� ���ڷ� �����
//         {
//             Console.Write(c); //c�� ��� ���ڸ� ���
//             Thread.Sleep(delay);// ������ �����̸�ŭ ����
//         }// ���ڿ��� ���ڷ� ��ȯ�Ͽ� ���ʴ�� ����ϸ鼭 ���� ���̻��̿� �����̸� �־� Ÿ���� ȿ���� ����
//     }

// }


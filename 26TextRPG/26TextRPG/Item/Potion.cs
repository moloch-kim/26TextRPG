using _26TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    public class Potion : Item, IConsumable
    {
        public int ID { get; private set; }
        public int PotionType { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Effect { get; private set; }
        public int Duration { get; private set; }
        public int Value { get; private set; }

        public Potion(int iD, int potionType, string name, string description, int effect,int duration, int value)
        {
            ID = iD;
            PotionType = potionType;
            Name = name;
            Description = description;
            Effect = effect;
            Duration = duration;
            Value = value;
        }
        public void UseItem() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Consume();
        }
        public void Consume() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Player playerData = Player.Instance;
            Console.WriteLine($"당신은 {Name}을(를) 들이킵니다.");
            switch (PotionType) // 포션 타입에 따라 다른 효과
            {
                case 1: //체력 회복 포션
                    playerData.Health += Effect;
                    if(playerData.Health > playerData.MaxHealth) { playerData.Health = playerData.MaxHealth; }
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 체력이 {Effect}만큼 회복되었습니다.");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    break;
                case 2: //공격력 강화 포션
                    //playerData.AttackPower += Effect;
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 잠시 공격력이 {Effect}만큼 상승했습니다!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    playerData.ActivePotion.Add(this);
                    break;
                case 3: //방어력 강화 포션
                    //playerData.DefensePower += Effect;
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 잠시 방어력이 {Effect}만큼 상승했습니다!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    playerData.ActivePotion.Add(this);
                    break;
                case 4: //속도 강화 포션
                    //playerData.Speed += Effect;
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 잠시 속도가 {Effect}만큼 상승했습니다!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    playerData.ActivePotion.Add(this);
                    break;
                case 5: //전체 능력치 강화 포션
                    //playerData.AttackPower += Effect;
                    //playerData.DefensePower += Effect;
                    //playerData.Speed += Effect;
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 잠시 모든 능력치가 {Effect}만큼 상승했습니다!!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    playerData.ActivePotion.Add(this);
                    break;
                case 6: //마력 회복 포션
                    playerData.Mana += Effect;
                    if (playerData.Mana > playerData.MaxMana) { playerData.Mana = playerData.MaxMana; }
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 마력이 {Effect}만큼 회복되었습니다.");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    break;
                case 7: //완전 회복 포션
                    playerData.Mana = playerData.MaxMana;
                    playerData.Health = playerData.MaxHealth;
                    Console.WriteLine();
                    Console.WriteLine($"{Name}을(를) 사용하여 체력과 마력이 전부 회복되었습니다!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    break;
            }
            playerData.Inventory.Remove(this);
            // 인벤토리에서 제거
        }
    }
}

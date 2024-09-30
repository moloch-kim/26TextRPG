using _26TextRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item
{
    internal class Potion : Item, IConsumable
    {
        public int ID { get; private set; }
        public int PotionType { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Effect { get; private set; }
        public int Value { get; private set; }

        public Potion(int iD, int potionType, string name, string description, int effect, int value)
        {
            ID = iD;
            PotionType = potionType;
            Name = name;
            Description = description;
            Effect = effect;
            Value = value;
        }
        public void UseItem(Player player) //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Consume(player);
        }
        public void Consume(Player player) //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Console.WriteLine($"당신은 {Name}을(를) 들이킵니다.");
            switch (PotionType) // 포션 타입에 따라 다른 효과
            {
                case 1: //체력 회복 포션
                    player.Health += Effect;
                    Console.WriteLine($"{Name}을(를) 사용하여 체력이 {Effect}만큼 회복되었습니다.");
                    break;
                case 2: //공격력 강화 포션
                    player.TotalAttackPower += Effect; 
                    break;
                case 3: //방어력 강화 포션
                    player.TotalDefensePower += Effect;
                    break;
            }
            player.Inventory.Remove(this);
            // 인벤토리에서 제거
        }
    }
}

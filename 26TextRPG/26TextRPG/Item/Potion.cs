using _26TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    internal class Potion : Item, IConsumable
    {
        public new int ID { get; private set; }
        public int PotionType { get; private set; }
        public new string Name { get; private set; }
        public new string Description { get; private set; }
        public int Effect { get; private set; }
        public new int Value { get; private set; }

        Player playerData = Player.Instance;

        public Potion(int iD, int potionType, string name, string description, int effect, int value)
        {
            ID = iD;
            PotionType = potionType;
            Name = name;
            Description = description;
            Effect = effect;
            Value = value;
        }
        public void UseItem() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Consume();
        }
        public void Consume() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Console.WriteLine($"당신은 {Name}을(를) 들이킵니다.");
            switch (PotionType) // 포션 타입에 따라 다른 효과
            {
                case 1: //체력 회복 포션
                    playerData.Health += Effect;
                    Console.WriteLine($"{Name}을(를) 사용하여 체력이 {Effect}만큼 회복되었습니다.");
                    break;
                case 2: //공격력 강화 포션
                    playerData.TotalAttackPower += Effect; 
                    break;
                case 3: //방어력 강화 포션
                    playerData.TotalDefensePower += Effect;
                    break;
            }
            playerData.Inventory.Remove(this);
            // 인벤토리에서 제거
        }
    }
}

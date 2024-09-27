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

                    break;
                case 2: //
                    break;
                case 3: //
                    break;
            }
            // 인벤토리에서 제거
        }
    }
}

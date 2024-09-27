using _26TextRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item
{
    internal class Potion : IItem
    {
        public int ID { get; }
        public int PotionType { get; }
        public string Name { get; }
        public string Description { get; }
        public int Effect { get; }
        public int Value { get; }

        public Potion(int iD, int potionType, string name, string description, int effect, int value)
        {
            ID = iD;
            PotionType = potionType;
            Name = name;
            Description = description;
            Effect = effect;
            Value = value;
        }
        public void UseItem()
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
        }
    }
}

using _26TextRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item
{
    public class Weapon : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int Offense { get; }
        public int Value { get; }
        public bool IsEquip { get; }
        public Weapon(int id, string name, string description, int offense, int value) // 생성자
        {
            ID = id;
            Name = name;
            Description = description;
            Offense = offense;
            Value = value;
        }
        public void UseItem()
        {

        }

        public void Equip()
        {
            Console.WriteLine($"{Name}을(를) 장착했습니다.");
            //장착 메소드
        }
        public void Unequip()
        {
            Console.WriteLine($"{Name}을(를) 장착 해제했습니다.");
            //장착해제 메소드
        }
    }
}

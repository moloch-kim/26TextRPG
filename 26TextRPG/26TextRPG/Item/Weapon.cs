using _26TextRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item
{
    public class Weapon : Item , IEquipable
    {
<<<<<<< Updated upstream
        public int ID { get; }
        public int WeaponType { get; }
        public string Name { get; }
        public string Description { get; }
        public int Offense { get; }
        public int Speed { get; }
        public int Value { get; }
        public bool IsEquip { get; }
        public Weapon(int id,int weapontype, string name, string description, int offense,int speed, int value) // 생성자
=======
        public new int ID { get; }
        public new string Name { get; }
        protected new string Description;
        protected int Offense;
        protected new int Value;
        protected bool IsEquip;
        public Weapon(int id, string name, string description, int offense, int value) // 생성자
>>>>>>> Stashed changes
        {
            ID = id;
            WeaponType = weapontype;
            Name = name;
            Description = description;
            Offense = offense;
            Speed = speed;
            Value = value;
        }
        public void UseItem() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            if (IsEquip)
            {
                UnEquip();
            }
            else
            {
                Equip();
            }
        }

        public void Equip() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Console.WriteLine($"{Name}을(를) 장착했습니다.");
            //장착 메소드
        }
        public void UnEquip() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Console.WriteLine($"{Name}을(를) 장착 해제했습니다.");
            //장착해제 메소드
        }
    }
}

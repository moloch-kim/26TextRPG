using _26TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    public class Weapon : Item , IEquipable
    {
        public new int ID { get; private set; }
        public new string Name { get; private set; }
        public new string Description { get; private set; }
        public int Offense { get; private set; }
        public int Weight { get; private set; }
        public new int Value { get; private set; }
        public bool IsEquip { get; private set; }

        Player playerData = Player.Instance;
        public Weapon(int id, string name, string description, int offense,int weight, int value) // 생성자
        {
            ID = id;
            Name = name;
            Description = description;
            Offense = offense;
            Weight = weight;
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
            playerData.TotalAttackPower += Offense;
            playerData.Speed -= Weight;
            //장착 메소드
        }
        public void UnEquip() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Console.WriteLine($"{Name}을(를) 장착 해제했습니다.");
            playerData.TotalAttackPower -= Offense;
            playerData.Speed += Weight;
            //장착해제 메소드
        }
    }
}

using _26TextRPG.Item.Interface;

namespace _26TextRPG.Item
{
    public class Armor : Item, IEquipable
    {
<<<<<<< Updated upstream
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int Defense { get; }
        public int Encumbrance { get; }
        public int Value { get; }
        public bool IsEquip {  get; }
=======
        protected new int ID;
        protected new string Name;
        protected new string Description;
        protected int Defense;
        protected new int Value;
        protected bool IsEquip;
>>>>>>> Stashed changes

        public Armor(int id, string name, string description, int defense,int ecumbrance, int value) // 생성자
        {
            ID = id;
            Name = name;
            Description = description;
            Defense = defense;
            Encumbrance = ecumbrance;
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

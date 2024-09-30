using _26TextRPG;

namespace _26TextRPG
{
    public class Armor : Item, IEquipable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Defense { get; private set; }
        public int Weight { get; private set; }
        public int Value { get; private set; }
        public bool IsEquip {  get; private set; }

        Player playerData = Player.Instance;
        public Armor(int id, string name, string description, int defense,int weight, int value) // 생성자
        {
            ID = id;
            Name = name;
            Description = description;
            Defense = defense;
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
            Player playerData = Player.Instance;
            Console.WriteLine($"{Name}을(를) 장착했습니다.");
            playerData.EquipedArmor = this;
            playerData.DefensePower += Defense;
            playerData.Speed -= Weight;
            IsEquip = true;
            //장착 메소드
        }
        public void UnEquip() //괄호에 캐릭터 클래스 매개변수 삽입
        {
            Player playerData = Player.Instance;
            Console.WriteLine($"{Name}을(를) 장착 해제했습니다.");
            playerData.EquipedArmor = null;
            playerData.DefensePower -= Defense;
            playerData.Speed += Weight;
            IsEquip = false;
            //장착해제 메소드
        }
    }

}

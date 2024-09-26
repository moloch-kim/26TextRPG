using _26TextRPG.Item.Interface;

namespace _26TextRPG.Item
{
    public class Armor : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int Defense { get; }
        public int Value { get; }
        public bool IsEquip {  get; }

        public Armor(int id, string name, string description, int defense, int value) // 생성자
        {
            ID = id;
            Name = name;
            Description = description;
            Defense = defense;
            Value = value;
        }

        public void UseItem()
        {
            
        }

        public void Equip()
        {
            //장착 메소드
        }
        public void Unequip()
        {
            //장착해제 메소드
        }
    }

}

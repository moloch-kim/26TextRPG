public class Skill
{
    public string Name { get; } //스킬 이름
    public int ManaCost { get; } //마나 소모량
    public int Reference { get; } //참조 변수 1:공격력, 2:방어력, 3:최대체력, 4:최대마나 5:속도
    public float Multiplier { get; } //스킬 배율
    public bool IsArea { get; }  //  true 면 광역, false 면 단일
    public int Price { get; } // 가치

    public Skill(string name, int manaCost,int reference, float multiplier, bool isArea, int price)
    {
        Name = name;
        ManaCost = manaCost;
        Reference = reference;
        Multiplier = multiplier;
        IsArea = isArea;
        Price = price;
    }
}

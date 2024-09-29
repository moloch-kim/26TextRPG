public class Skill
{
    public string Name { get; } //스킬 이름
    public int ManaCost { get; } //마나 소모량
    public float Multiplier { get; } //스킬 배율
    public bool IsArea { get; }  //  true 면 광역, false 면 단일

    public Skill(string name, int manaCost, float multiplier, bool isArea)
    {
        Name = name;
        ManaCost = manaCost;
        Multiplier = multiplier;
        IsArea = isArea;
    }
}

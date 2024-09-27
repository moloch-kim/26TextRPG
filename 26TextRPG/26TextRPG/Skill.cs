public class Skill
{
    public string Name { get; } //��ų �̸�
    public int ManaCost { get; } //���� �Ҹ�
    public float Multiplier { get; } //��ų ����
    public bool IsArea { get; }  //  true �� ����, false �� ����

    public Skill(string name, int manaCost, float multiplier, bool isArea)
    {
        Name = name;
        ManaCost = manaCost;
        Multiplier = multiplier;
        IsArea = isArea;
    }
}

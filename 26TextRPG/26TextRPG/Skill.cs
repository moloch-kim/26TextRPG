public class Skill
{
    public string Name { get; } //��ų �̸�
    public int ManaCost { get; } //���� �Ҹ�
    public int reference { get; } //���� ����
    public float Multiplier { get; } //��ų ����
    public bool IsArea { get; }  //  true �� ����, false �� ����

    public Skill(string name, int manaCost,int reference, float multiplier, bool isArea)
    {
        Name = name;
        ManaCost = manaCost;
        Multiplier = multiplier;
        IsArea = isArea;
    }
}

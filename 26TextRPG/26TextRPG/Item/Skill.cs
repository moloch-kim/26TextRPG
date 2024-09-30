public class Skill
{
    public string Name { get; } //��ų �̸�
    public int ManaCost { get; } //���� �Ҹ�
    public int Reference { get; } //���� ���� 1:���ݷ�, 2:����, 3:�ִ�ü��, 4:�ִ븶�� 5:�ӵ�
    public double Multiplier { get; } //��ų ����
    public bool IsArea { get; }  //  true �� ����, false �� ����

    public Skill(string name, int manaCost,int reference, double multiplier, bool isArea)
    {
        Name = name;
        ManaCost = manaCost;
        Reference = reference;
        Multiplier = multiplier;
        IsArea = isArea;
    }
}

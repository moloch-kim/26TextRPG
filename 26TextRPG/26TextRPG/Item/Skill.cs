public class Skill
{
    public string Name { get; } //��ų �̸�
    public int ManaCost { get; } //���� �Ҹ�
    public int Reference { get; } //���� ���� 1:���ݷ�, 2:����, 3:�ִ�ü��, 4:�ִ븶�� 5:�ӵ�
    public float Multiplier { get; } //��ų ����
    public bool IsArea { get; }  //  true �� ����, false �� ����
    public int Price { get; } // ��ġ

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

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

//�� �κе� Character�� �־��ּ���
//public class Character
//{
//    public string Name { get; }
//    public string Mana { get; set; }

//    //�⺻����
//    public void Attack(Enemy enemy)
//    {
//        int damage = TotalAttackPower - enemy.DefensePower;
//        if (damage < 0) damage = 0;
//        enemy.Health -= damage;
//        Console.WriteLine($"{Name}��(��) {enemy.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
//    }

//    //��ų ����Ʈ
//    public string Name { get; }
//    public List<Skill> SkillList { get; } = new List<Skill>();

//    public Character(string name)
//    {
//        Name = name;
//    }

//    public void LearnSkill(Skill skill)
//    {
//        SkillList.Add(skill);
//    }

//    public void UseSkill(Skill skill, Enemy enemy)
//    {

//        mana -= skill.ManaCost;
//        int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
//        if (damage < 0) damage = 0;
//        enemy.Health -= damage;

//        Console.WriteLine($"{Name}��(��) {enemy.Name}���� {skill.Name}�� ����� {damage}��ŭ�� ���ظ� �������ϴ�.");
//    }

//}

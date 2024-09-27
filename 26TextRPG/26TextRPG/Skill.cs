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

//이 부분도 Character에 넣어주세요
//public class Character
//{
//    public string Name { get; }
//    public string Mana { get; set; }

//    //기본공격
//    public void Attack(Enemy enemy)
//    {
//        int damage = TotalAttackPower - enemy.DefensePower;
//        if (damage < 0) damage = 0;
//        enemy.Health -= damage;
//        Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}만큼의 피해를 입혔습니다.");
//    }

//    //스킬 리스트
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

//        Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {skill.Name}을 사용해 {damage}만큼의 피해를 입혔습니다.");
//    }

//}

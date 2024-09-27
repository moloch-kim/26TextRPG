using _26TextRPG;

public class Player
{
    // 초기값 설정(상태 보기 화면에 뜨는)
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public string Job { get; set; } = "전사";
    public int AttackPower { get; set; } = 10;
    public int TotalAttackPower { get; set; }
    public int DefensePower { get; set; } = 5;
    public int TotalDefensePower { get; set; }
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; }
    public int Gold { get; set; } = 1500;
    public int Speed { get; set; }
    public int Mana { get; set; }
    public int ActionGauge { get; set; }
    public bool IsDefending { get; set; }
    public List<Skill> SkillList { get; } = new List<Skill>();
    public List<_26TextRPG.Item.Item> Inventory { get; set; }
    public Quest Quest { get; set; }


    public Player(string name, int speed)
    {
        Name = name;
        // speed = _speed;
    }

    public void ChargeActionGauge()
	{
		ActionGauge += Speed;
		if (ActionGauge >= 100)
			ActionGauge = 100;
	}

    public bool CanAct()
	{
		return ActionGauge >= 100;
	}

    public void ResetActionGauge()
	{
		ActionGauge = 0;
	}

    public void Attack(Enemy enemy)
	{
		int damage = TotalAttackPower - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;
		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}만큼의 피해를 입혔습니다.");
	}

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}이(가) 방어 태세를 취했습니다.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{

		Mana -= skill.ManaCost;
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;

		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {skill.Name}을 사용해 {damage}만큼의 피해를 입혔습니다.");
	}

}

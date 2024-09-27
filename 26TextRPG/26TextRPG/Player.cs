using _26TextRPG;

public class Player
{
    // �ʱⰪ ����(���� ���� ȭ�鿡 �ߴ�)
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public string Job { get; set; } = "����";
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
		Console.WriteLine($"{Name}��(��) {enemy.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}��(��) ��� �¼��� ���߽��ϴ�.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{

		Mana -= skill.ManaCost;
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;

		Console.WriteLine($"{Name}��(��) {enemy.Name}���� {skill.Name}�� ����� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}

}

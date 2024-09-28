public class Enemy
{
	public string Name { get; }
	public int ID { get; } 
	public int Health { get; set; }
	public int MaxHealth { get; }
	public int AttackPower { get; }
	public int DefensePower { get; }
	public int Speed { get; }
	public int ExperienceReward { get; }
	public int GoldReward { get; }
	public int ActionGauge { get; private set; } = 0;

	public bool IsAlive()
	{
		return Health > 0;
	}

	public Enemy(string name, int id, int health, int attackPower, int defensePower, int speed, int experienceReward, int goldReward)
	{
		Name = name;
		ID = id;
		Health = MaxHealth = health;
		AttackPower = attackPower;
		DefensePower = defensePower;
		Speed = speed;
		ExperienceReward = experienceReward;
		GoldReward = goldReward;
	}

    public void ChargeActionGauge()
		{
			if (Health > 0) // ���� ������� ���� ������ ����
			{
				ActionGauge += Speed;
				if (ActionGauge >= 100)
					ActionGauge = 100;
			}
		}

	public bool CanAct()
	{
		return ActionGauge >= 100;
	}

	public void ResetActionGauge()
	{
		ActionGauge = 0;
	}

	public void Attack(Player player)
	{
		int damage = AttackPower - player.TotalDefensePower;
		if (damage < 0) damage = 0;
		player.Health -= damage;
		Console.WriteLine($"{Name}��(��) {player.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}
}
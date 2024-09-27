	public class Enemy: Character
	{
		public string Name { get; }
		public int Health { get; set; }
		public int MaxHealth { get; }
		public int AttackPower { get; }
		public int DefensePower { get; }
		public int Speed { get; }
		public int ExperienceReward { get; }
		public int GoldReward { get; }
		public int ActionGauge { get; private set; }

		public bool IsAlive()
		{
			return Health > 0;
		}

		public Enemy(string name, int health, int attackPower, int defensePower, int speed, int experienceReward, int goldReward)
		{
			Name = name;
			Health = MaxHealth = health;
			AttackPower = attackPower;
			DefensePower = defensePower;
			Speed = speed;
			ExperienceReward = experienceReward;
			GoldReward = goldReward;
			ActionGauge = 0; // 초기화
		}

    public void ChargeEnemyActionGauge()
		{
			if (Health > 0) // 적이 살아있을 때만 게이지 충전
			{
				ActionGauge += Speed;
				if (ActionGauge >= 100)
					ActionGauge = 100;
			}
		}

		public bool EnemyCanAct()
		{
			return ActionGauge >= 100;
		}

		public void ResetEnemyActionGauge()
		{
			ActionGauge = 0;
		}

		public void Attack(Character player)
		{
			int damage = AttackPower - player.TotalDefensePower;
			if (damage < 0) damage = 0;
			player.Health -= damage;
			Console.WriteLine($"{Name}이(가) {player.Name}에게 {damage}만큼의 피해를 입혔습니다.");
		}
}
	public class Enemy
	{
		string name { get; set; }
		int speed { get; set; }
		int ActionGauge { get; set; }
		int health { get; set; }

		public Enemy(string _name, int _speed)
		{
			name = _name;
			speed = _speed;
			ActionGauge = 0;
		}

		public void ChargeEnemyActionGauge()
		{
			if (health > 0) // 적이 살아있을 때만 게이지 충전
			{
				ActionGauge += speed;
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
	}
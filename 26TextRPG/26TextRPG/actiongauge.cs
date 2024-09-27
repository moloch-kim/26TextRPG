using System;
using System.Collections.Generic;

//public class Character
//{
//	public string Name { get; private set; }
//	public int Speed { get; private set; }
//	public int ActionGauge { get; private set; }

//	public Character(string name, int speed)
//	{
//		Name = name;
//		Speed = speed;
//		ActionGauge = 0;
//	}

//	public void ChargeCharacterActionGauge()
//	{
//		ActionGauge += Speed;
//		if (ActionGauge >= 100)
//			ActionGauge = 100;
//	}

//	public bool CharacterCanAct()
//	{
//		return ActionGauge >= 100;
//	}

//	public void ResetCharacterActionGauge()
//	{
//		ActionGauge = 0;
//	}
//}



//public class Enemy
//{
//	public string Name { get; private set; }
//	public int Speed { get; private set; }
//	public int ActionGauge { get; private set; }

//	public Enemy(string name, int speed)
//	{
//		Name = name;
//		Speed = speed;
//		ActionGauge = 0;
//	}

//	public void ChargeEnemyActionGauge()
//	{
//		if (Health > 0) // 적이 살아있을 때만 게이지 충전
//		{
//			ActionGauge += Speed;
//			if (ActionGauge >= 100)
//				ActionGauge = 100;
//		}
//	}

//	public bool EnemyCanAct()
//	{
//		return ActionGauge >= 100;
//	}

//	public void ResetEnemyActionGauge()
//	{
//		ActionGauge = 0;
//	}
//}


using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using System;

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

	MainScene mainScene = new MainScene();

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
			if (Health > 0) // 적이 살아있을 때만 게이지 충전
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
        int AttackRoll = Dice.Roll(1, 20);
        if (AttackRoll == 20)
        {
            int damage = AttackPower - player.DefensePower;
            if (damage < 0) damage = 0;
            player.Health -= damage * 2;
            mainScene.TypingEffect("정말 치명적인 일격입니다!!", 30);
            mainScene.TypingEffect($"{Name}이(가) {player.Name}에게 {damage}만큼의 피해를 입혔습니다!", 50);
        }
        else if (AttackRoll == 1)
        {
            mainScene.TypingEffect("어이없는 실수로 공격이 빗나갑니다!!", 50);
        }
        else
        {
            int damage = AttackPower - player.DefensePower;
            if (damage < 0) damage = 0;
            player.Health -= damage;
            Console.WriteLine($"{Name}이(가) {player.Name}에게 {damage}만큼의 피해를 입혔습니다.");
        }
    }
}
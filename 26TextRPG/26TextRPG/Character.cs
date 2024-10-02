using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;

public class Character
{
	public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
	public int AttackPower { get; set; }
	public int DefensePower { get; set; }
	public int Speed { get; set; }		
	public int ActionGauge { get; set; } = 0;

    // public Character(string name, int speed)
	// {
	// 	Name = name;
	// 	Speed = speed;
	// 	ActionGauge = 0;
	// }

	MainScene mainScene = new MainScene();

	public bool CanAct()
	{
		return ActionGauge >= 100;
	}	

	public void ResetActionGauge()
	{
		ActionGauge = 0;
	}

	public void Attack(Character character)
	{
		int AttackRoll = Dice.Roll(1, 20);
		int DamageRoll = Dice.Roll(2, 6);
        if (AttackRoll == 20)
		{
			int damage = (AttackPower + DamageRoll) - character.DefensePower;
			if (damage < 0) damage = 0;
			character.Health -= damage * 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("!!!!!!!!!! CRITICAL HIT !!!!!!!!!!");
            Console.WriteLine();
            mainScene.TypingEffect("정말 치명적인 일격입니다!!", 20);
            Console.ResetColor();
			mainScene.TypingEffect($"{Name}이(가) {character.Name}에게 {damage}만큼의 피해를 입혔습니다!", 20);
		}
		else if (AttackRoll == 1)
		{
			mainScene.TypingEffect("어이없는 실수로 공격이 빗나갑니다!!", 10);
		}
		else
		{
			int damage = (AttackPower + DamageRoll) - character.DefensePower;
			if (damage < 0) damage = 0;
			character.Health -= damage;
			Console.WriteLine($"{Name}이(가) {character.Name}에게 {damage}만큼의 피해를 입혔습니다.");
		}
	}

	public void ChargeActionGauge()
	{
		if ( IsAlive() ) // 적이 살아있을 때만 게이지 충전
		{
			ActionGauge += Speed;
			if (ActionGauge >= 100)
				ActionGauge = 100;
		}
	}

	public bool IsAlive()
	{
		return Health > 0;
	}

}


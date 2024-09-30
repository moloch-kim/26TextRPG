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
		if (AttackRoll == 20)
		{
			int damage = AttackPower - character.DefensePower;
			if (damage < 0) damage = 0;
			character.Health -= damage * 2;
			mainScene.TypingEffect("���� ġ������ �ϰ��Դϴ�!!", 30);
			mainScene.TypingEffect($"{Name}��(��) {character.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�!", 50);
		}
		else if (AttackRoll == 1)
		{
			mainScene.TypingEffect("���̾��� �Ǽ��� ������ �������ϴ�!!", 50);
		}
		else
		{
			int damage = AttackPower - character.DefensePower;
			if (damage < 0) damage = 0;
			character.Health -= damage;
			Console.WriteLine($"{Name}��(��) {character.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
		}
	}

	public void ChargeActionGauge()
	{
		if ( IsAlive() ) // ���� ������� ���� ������ ����
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


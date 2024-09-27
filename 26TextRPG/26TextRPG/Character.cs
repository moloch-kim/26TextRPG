using System;
using System.Collections.Generic;

public class Character
{
	public string Name { get; private set; }
	public int Speed { get; private set; }
	public int ActionGauge { get; private set; }
	public int TotalAttackPower { get; private set; }

	public Character(string name, int speed)
	{
		Name = name;
		Speed = speed;
		ActionGauge = 0;
	}

	public void ChargeCharacterActionGauge()
	{
		ActionGauge += Speed;
		if (ActionGauge >= 100)
			ActionGauge = 100;
	}

	public bool CharacterCanAct()
	{
		return ActionGauge >= 100;
	}

	public void ResetCharacterActionGauge()
	{
		ActionGauge = 0;
	}

	//기본공격
	public void Attack(Enemy enemy)
	{
		int damage = TotalAttackPower - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;
		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}만큼의 피해를 입혔습니다.");
	}

	//스킬 리스트
	public string Name { get; }
	public List<Skill> SkillList { get; } = new List<Skill>();

	public Character(string name)
	{
		Name = name;
	}

	public void LearnSkill(Skill skill)
	{
		SkillList.Add(skill);
	}

	public void UseSkill(Skill skill, Enemy enemy)
	{

		mana -= skill.ManaCost;
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;

		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {skill.Name}을 사용해 {damage}만큼의 피해를 입혔습니다.");
	}
}


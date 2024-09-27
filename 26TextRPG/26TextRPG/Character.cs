using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Character
{
	public string Name { get; private set; }
	public string Race { get; private set; }
	public string Job { get; private set; }
    public int Health { get; set; }
    public int MaxHealth { get; private set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
	public int Strength { get; private set; }		// 힘, 기본값 + 아이템값
	public int TotalAttack { get; private set; }
	public int TotalDefense { get; private set; }
	public int Agillity { get; private set; }		// 민첩
    public int Speed { get; private set; }
	public int Exp { get; private set; }
	public int Level { get; private set; }
	public int Gold { get; private set; }
	public int ActionGauge { get; private set; }
    public bool IsDefending { get; private set; }

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
		int damage = TotalAttack - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;
		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}만큼의 피해를 입혔습니다.");
	}

	//스킬 리스트
	public List<Skill> SkillList { get; } = new List<Skill>();

	public void LearnSkill(Skill skill)
	{
		SkillList.Add(skill);
	}

	public void UseSkill(Skill skill, Enemy enemy)
	{

		Mana -= skill.ManaCost;
		int damage = (int)(TotalAttack * skill.Multiplier) - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;

		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {skill.Name}을 사용해 {damage}만큼의 피해를 입혔습니다.");
	}

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}이(가) 방어 태세를 취했습니다.");
    }

    public void ResetDefense()
    {
        IsDefending = false;
    }
}


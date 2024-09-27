using System;
using System.Collections.Generic;

public class Character
{
	public string Name { get; private set; }
    public int Health { get; set; }
    public int MaxHealth { get; private set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int Speed { get; private set; }
	public int ActionGauge { get; private set; }
    public int BaseAttackPower { get; private set; }
    public int BaseDefensePower { get; private set; }

	public int TotalAttackPower => BaseAttackPower; //+ (EquippedWeapon?.Attack ?? 0); // 무기 공격력 포함
	public int TotalDefensePower => BaseDefensePower; //+ (EquippedArmor?.Defense ?? 0); // 방어구 방어력 포함
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
		int damage = TotalAttackPower - enemy.DefensePower;
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
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
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


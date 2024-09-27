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

	public int TotalAttackPower => BaseAttackPower; //+ (EquippedWeapon?.Attack ?? 0); // ���� ���ݷ� ����
	public int TotalDefensePower => BaseDefensePower; //+ (EquippedArmor?.Defense ?? 0); // �� ���� ����
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

	//�⺻����
	public void Attack(Enemy enemy)
	{
		int damage = TotalAttackPower - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;
		Console.WriteLine($"{Name}��(��) {enemy.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}

	//��ų ����Ʈ
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

		Console.WriteLine($"{Name}��(��) {enemy.Name}���� {skill.Name}�� ����� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}��(��) ��� �¼��� ���߽��ϴ�.");
    }

    public void ResetDefense()
    {
        IsDefending = false;
    }
}


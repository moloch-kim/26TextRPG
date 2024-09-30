using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using System;

public class Enemy : Character
{
	public int ID { get; } 
	public int ExperienceReward { get; }
	public int GoldReward { get; }

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
}
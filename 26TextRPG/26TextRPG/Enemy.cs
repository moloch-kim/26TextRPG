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

    public Enemy(Enemy original)
    {
        Name = original.Name;
        ID = original.ID;
        Health = original.Health;
        MaxHealth = original.MaxHealth;
        AttackPower = original.AttackPower;
        DefensePower = original.DefensePower;
        Speed = original.Speed;
        ExperienceReward = original.ExperienceReward;
        GoldReward = original.GoldReward;
    }

    public void Attack(Player player)
    {
        int playerarmor = 0;
        if (player.EquipedArmor != null) { playerarmor = player.EquipedArmor.Defense; }
        MainScene mainScene = new MainScene();
        int AttackRoll = Dice.Roll(1, 20);
        int DamageRoll = Dice.Roll(2, 6);
        if (AttackRoll == 20)
        {
            int damage = ((AttackPower + DamageRoll) * 2) - (player.DefensePower + playerarmor);
            if (damage < 0) damage = 0;
            player.Health -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("!!!!!!!!!! CRITICAL HIT !!!!!!!!!!");
            Console.WriteLine();
            mainScene.TypingEffect("정말 치명적인 일격입니다!!", 20);
            Console.ResetColor();
            mainScene.TypingEffect($"{Name}이(가) {player.Name}에게 {damage}만큼의 피해를 입혔습니다!", 20);
        }
        else if (AttackRoll == 1)
        {
            mainScene.TypingEffect("어이없는 실수로 공격이 빗나갑니다!!", 10);
        }
        else
        {
            int damage = (AttackPower + DamageRoll) - (player.DefensePower + playerarmor);
            if (damage < 0) damage = 0;
            player.Health -= damage;
            Console.WriteLine($"{Name}이(가) {player.Name}에게 {damage}만큼의 피해를 입혔습니다.");
        }
    }
}
using _26TextRPG;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using System.ComponentModel;
public class Player : Character
{
    private static Player instance;
    // �ʱⰪ ����(���� ���� ȭ�鿡 �ߴ�)
    public int Level { get; set; }
    public string Job { get; set; } 
    public int BaseAttackPower { get; set; }
    public int BaseDefensePower { get; set; }
    public int Gold { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int Exp { get; set; }
    public int ExpToNextLevel { get; set; } = 100;
    public int StatPoint;
    public bool IsDefending { get; set; }
    public List<Skill> SkillList { get; } = new List<Skill>();
    public List<Item> Inventory { get; } = new List<Item>();
    public Armor EquipedArmor { get; set; }
    public Weapon EquipedWeapon { get; set; }
    public new int AttackPower { get; set; }
    public new int DefensePower { get; set; }
    public List<Quest> Quest { get; } = new List<Quest>();
    public List<Potion> ActivePotion { get; set; } = null;
    public Player(string name, string job, int baseAttackPower, int baseDefensePower, int maxHealth, int speed, int maxMana, int gold)
    {
        Name = name;
        Job = job;
        BaseAttackPower = baseAttackPower;
        BaseDefensePower = baseDefensePower;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Speed = speed;
        Mana = maxMana;
        MaxMana = maxMana;
        Gold = gold;
        if(EquipedWeapon != null) AttackPower = baseAttackPower + EquipedWeapon.Offense;
        if(EquipedArmor != null) DefensePower = baseDefensePower + EquipedArmor.Defense;
        for(int i = 0; i < ActivePotion.Count; i++)
        {
            int potiontype = ActivePotion[i].PotionType;
            int potionEffect = ActivePotion[i].Effect;
            if(potiontype != 1)
            {
                switch (potiontype)
                {
                    case 2 :
                        AttackPower += potionEffect;
                        break;
                    case 3 :
                        DefensePower += potionEffect;
                        break;
                    case 4:
                        Speed += potionEffect;
                        break;
                    case 5:
                        AttackPower += potionEffect;
                        DefensePower += potionEffect;
                        Speed += potionEffect;
                        break;
                }
            }
        }
        // ����) ���� ����κп��� �ʱ�ȭó���� ���� �ϵ��� �����߽��ϴ�. 
        // ExpToNextLevel = 100;
        // Inventory = new List<Item>();
        // EquipedArmor = null;
        // EquipedWeapon = null;
        // SkillList = new List<Skill>();
    }

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    public static void LoadPlayer(Player loadedPlayer)
    {
        instance = loadedPlayer;
    }

    public new void Attack(Character character)
    {
        MainScene mainScene = new MainScene();
        int AttackRoll = Dice.Roll(1, 20);
        int DamageRoll = Dice.Roll(2, 6);
        if (AttackRoll == 20)
        {
            int damage = ((AttackPower + DamageRoll) * 2) - character.DefensePower;
            if (damage < 0) damage = 0;
            character.Health -= damage;
            mainScene.TypingEffect("���� ġ������ �ϰ��Դϴ�!!", 30);
            mainScene.TypingEffect($"{Name}��(��) {character.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�!", 50);
        }
        else if (AttackRoll == 1)
        {
            mainScene.TypingEffect("���̾��� �Ǽ��� ������ �������ϴ�!!", 50);
        }
        else
        {
            int damage = (AttackPower + DamageRoll) - character.DefensePower;
            if (damage < 0) damage = 0;
            character.Health -= damage;
            Console.WriteLine($"{Name}��(��) {character.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
        }
    }

    public void ChargeActionGauge()
    {
        if (IsAlive()) // ���� ������� ���� ������ ����
        {
            if (Speed <= 10)
            {
                Speed = 10;
            }
            ActionGauge += Speed;
            if (ActionGauge >= 100)
                ActionGauge = 100;
        }
    }

    public void ApplyPotion()
    {
        for (int i = 0; i < ActivePotion.Count; i++)
        {
            int count = 0;
            int maxCount = ActivePotion[i].Duration;
            count++;
            if (count > maxCount)
            {
                Console.WriteLine($"{ActivePotion[i].Name}�� ȿ���� ���Ͽ����ϴ�!");
                Console.WriteLine();
                ActivePotion.Remove(ActivePotion[i]);
            }
        }
    }

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}��(��) ��� �¼��� ���߽��ϴ�.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{
        int damage = 0; ;
		Mana -= skill.ManaCost;
        switch (skill.Reference)
        {
            case 1:
                damage = (int)(AttackPower * skill.Multiplier) - enemy.DefensePower;
                break;
            case 2:
                damage = (int)(DefensePower * skill.Multiplier) - enemy.DefensePower;
                break;
            case 3:
                damage = (int)(MaxHealth * skill.Multiplier) - enemy.DefensePower;
                break;
            case 4:
                damage = (int)(MaxMana * skill.Multiplier) - enemy.DefensePower;
                break;
            case 5:
                damage = (int)(Speed * skill.Multiplier) - enemy.DefensePower;
                break;
        }
		
		if (damage < 0) damage = 0;
		enemy.Health -= damage;

		Console.WriteLine($"{Name}��(��) {enemy.Name}���� {skill.Name}�� ����� {damage}��ŭ�� ���ظ� �������ϴ�.");
	}

    public void GainExp(int amount)
    {
        Exp += amount;
        Console.WriteLine($"{amount} ����ġ�� ȹ���߽��ϴ�.");
        if (Exp >= ExpToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Exp -= ExpToNextLevel;
        Level++;
        ExpToNextLevel = (int)(ExpToNextLevel * 1.5);
        StatPoint += 5;
        Console.WriteLine("������! ���� ����Ʈ 5���� ȹ���߽��ϴ�.");
        DistributeStatPoint();
    }

    public void DistributeStatPoint()
    {
        while (StatPoint > 0)
        {
            Console.Clear();
            Console.WriteLine("���� ����Ʈ�� �й��ϼ���.");
            Console.WriteLine($"���� ���� ����Ʈ: {StatPoint}");
            Console.WriteLine("1. ���ݷ�");
            Console.WriteLine("2. ����");
            Console.WriteLine("3. ü��");
            Console.WriteLine("4. ����");
            Console.WriteLine("5. �ӵ�");
            Console.Write("���ϴ� ������ �����ϼ���: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BaseAttackPower += 5;
                    Console.WriteLine("���ݷ��� �����߽��ϴ�.");
                    StatPoint--;
                    break;
                case "2":
                    BaseDefensePower += 5;
                    Console.WriteLine("������ �����߽��ϴ�.");
                    StatPoint--;
                    break;
                case "3":
                    MaxHealth += 5;
                    Health = MaxHealth;
                    Console.WriteLine("�ִ� ü���� �����߽��ϴ�.");
                    StatPoint--;
                    break;
                case "4":
                    MaxMana += 5;
                    Mana = MaxMana;
                    Console.WriteLine("�ִ� ������ �����߽��ϴ�.");
                    StatPoint--;
                    break;
                case "5":
                    Speed += 5;
                    Console.WriteLine("�ӵ��� �����߽��ϴ�.");
                    StatPoint--;
                    break;
                default:
                    Console.WriteLine("�߸��� �����Դϴ�.");
                    continue;
            }
        }
    }
}

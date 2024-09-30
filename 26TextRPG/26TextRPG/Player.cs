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
    public Quest Quest { get; set; }
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
<<<<<<< HEAD
        // ����) ���� ����κп��� �̹� ������ �κ��̶� �ּ�ó���߽��ϴ�. �ش� �ڵ� �ۼ��Ͻ� �� �̰� Ȯ���Ͻø� �ּ� �������ּ���!
        // ExpToNextLevel = 100;
        // Inventory = new List<Item>();
        // SkillList = new List<Skill>();
=======
        ExpToNextLevel = 100;
        Inventory = new List<Item>();
        EquipedArmor = null;
        EquipedWeapon = null;
        SkillList = new List<Skill>();
>>>>>>> Dev
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

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}��(��) ��� �¼��� ���߽��ϴ�.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{
        int damage = 0; ;
		Mana -= skill.ManaCost;
<<<<<<< HEAD
		int damage = (int)(AttackPower * skill.Multiplier) - enemy.DefensePower;
=======
        switch (skill.Reference)
        {
            case 1:
                damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
                break;
            case 2:
                damage = (int)(TotalDefensePower * skill.Multiplier) - enemy.DefensePower;
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
		
>>>>>>> Dev
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
            Console.WriteLine("4. �ӵ�");
            Console.Write("���ϴ� ������ �����ϼ���: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BaseAttackPower++;
                    Console.WriteLine("���ݷ��� �����߽��ϴ�.");
                    break;
                case "2":
                    BaseDefensePower++;
                    Console.WriteLine("������ �����߽��ϴ�.");
                    break;
                case "3":
                    MaxHealth += 10;
                    Health = MaxHealth;
                    Console.WriteLine("�ִ� ü���� �����߽��ϴ�.");
                    break;
                case "4":
                    Speed++;
                    Console.WriteLine("�ӵ��� �����߽��ϴ�.");
                    break;
                default:
                    Console.WriteLine("�߸��� �����Դϴ�.");
                    continue;
            }
            StatPoint--;
        }
    }
}

using _26TextRPG;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using System.ComponentModel;
public class Player
{
    private static Player instance;
    // �ʱⰪ ����(���� ���� ȭ�鿡 �ߴ�)
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public string Job { get; set; } = "����";
    public int AttackPower { get; set; } = 10;
    public int TotalAttackPower { get; set; }
    public int DefensePower { get; set; } = 5;
    public int TotalDefensePower { get; set; }
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; }
    public int Gold { get; set; } = 1500;
    public int Speed { get; set; }
    public int Mana { get; set; }
    public int Exp { get; set; }
    public int ExpToNextLevel { get; set; }
    public int StatPoint;
    public int ActionGauge { get; set; }
    public bool IsDefending { get; set; }
    public List<Skill> SkillList { get; } = new List<Skill>();
    public List<Item> Inventory { get; } = new List<Item>();
    public Quest Quest { get; set; }
    public Player(string name)
    {
        Name = name;
        Inventory = new List<Item>();
        // speed = _speed;
    }

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player("Default Name"); // �⺻��
            }
            return instance;
        }
    }

    public static void LoadPlayer(Player loadedPlayer)
    {
        instance = loadedPlayer;
    }

    MainScene mainScene = new MainScene();

    public void ChargeActionGauge()
	{
		ActionGauge += Speed;
		if (ActionGauge >= 100)
			ActionGauge = 100;
	}

    public bool CanAct()
	{
		return ActionGauge >= 100;
	}

    public void ResetActionGauge()
	{
		ActionGauge = 0;
	}

    public void Attack(Enemy enemy)
	{
        int AttackRoll = Dice.Roll(1, 20);
        if (AttackRoll == 20)
        {
            int damage = TotalAttackPower - enemy.DefensePower;
            if (damage < 0) damage = 0;
            enemy.Health -= damage * 2;
            mainScene.TypingEffect("���� ġ������ �ϰ��Դϴ�!!", 30);
            mainScene.TypingEffect($"{Name}��(��) {enemy.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�!", 50);
        }
        else if (AttackRoll == 1)
        {
            mainScene.TypingEffect("���̾��� �Ǽ��� ������ �������ϴ�!!", 50);
        }
        else
        {
            int damage = TotalAttackPower - enemy.DefensePower;
            if (damage < 0) damage = 0;
            enemy.Health -= damage;
            Console.WriteLine($"{Name}��(��) {enemy.Name}���� {damage}��ŭ�� ���ظ� �������ϴ�.");
        }
    }

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}��(��) ��� �¼��� ���߽��ϴ�.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{

		Mana -= skill.ManaCost;
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
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
                    AttackPower++;
                    Console.WriteLine("���ݷ��� �����߽��ϴ�.");
                    break;
                case "2":
                    DefensePower++;
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

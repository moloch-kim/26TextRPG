using _26TextRPG;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using System.ComponentModel;
public class Player : Character
{
    private static Player instance;
    // 초기값 설정(상태 보기 화면에 뜨는)
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
        // 유민) 변수 선언부분에서 이미 구현된 부분이라서 주석처리했습니다. 해당 코드 작성하신 분 이거 확인하시면 주석 제거해주세요!
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
        Console.WriteLine($"{Name}이(가) 방어 태세를 취했습니다.");
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

		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {skill.Name}을 사용해 {damage}만큼의 피해를 입혔습니다.");
	}

    public void GainExp(int amount)
    {
        Exp += amount;
        Console.WriteLine($"{amount} 경험치를 획득했습니다.");
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
        Console.WriteLine("레벨업! 스탯 포인트 5점을 획득했습니다.");
        DistributeStatPoint();
    }

    public void DistributeStatPoint()
    {
        while (StatPoint > 0)
        {
            Console.Clear();
            Console.WriteLine("스탯 포인트를 분배하세요.");
            Console.WriteLine($"남은 스탯 포인트: {StatPoint}");
            Console.WriteLine("1. 공격력");
            Console.WriteLine("2. 방어력");
            Console.WriteLine("3. 체력");
            Console.WriteLine("4. 속도");
            Console.Write("원하는 스탯을 선택하세요: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BaseAttackPower++;
                    Console.WriteLine("공격력이 증가했습니다.");
                    break;
                case "2":
                    BaseDefensePower++;
                    Console.WriteLine("방어력이 증가했습니다.");
                    break;
                case "3":
                    MaxHealth += 10;
                    Health = MaxHealth;
                    Console.WriteLine("최대 체력이 증가했습니다.");
                    break;
                case "4":
                    Speed++;
                    Console.WriteLine("속도가 증가했습니다.");
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    continue;
            }
            StatPoint--;
        }
    }
}

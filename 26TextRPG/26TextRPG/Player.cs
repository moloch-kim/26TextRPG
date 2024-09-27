using _26TextRPG.Item;
using _26TextRPG;
public class Player
{
    // 초기값 설정(상태 보기 화면에 뜨는)
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    public string Job { get; set; } = "전사";
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
    public List<Item> Inventory { get; set; }
    public Quest Quest { get; set; }
    public Player(string name)
    {
        Name = name;
        // speed = _speed;
    }

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
		int damage = TotalAttackPower - enemy.DefensePower;
		if (damage < 0) damage = 0;
		enemy.Health -= damage;
		Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}만큼의 피해를 입혔습니다.");
	}

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name}이(가) 방어 태세를 취했습니다.");
    }

    public void UseSkill(Skill skill, Enemy enemy)
	{

		Mana -= skill.ManaCost;
		int damage = (int)(TotalAttackPower * skill.Multiplier) - enemy.DefensePower;
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
                    AttackPower++;
                    Console.WriteLine("공격력이 증가했습니다.");
                    break;
                case "2":
                    DefensePower++;
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

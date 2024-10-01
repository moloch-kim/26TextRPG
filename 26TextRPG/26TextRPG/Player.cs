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
        // 유민) 변수 선언부분에서 초기화처리도 같이 하도록 수정했습니다. 
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
            mainScene.TypingEffect("정말 치명적인 일격입니다!!", 30);
            mainScene.TypingEffect($"{Name}이(가) {character.Name}에게 {damage}만큼의 피해를 입혔습니다!", 50);
        }
        else if (AttackRoll == 1)
        {
            mainScene.TypingEffect("어이없는 실수로 공격이 빗나갑니다!!", 50);
        }
        else
        {
            int damage = (AttackPower + DamageRoll) - character.DefensePower;
            if (damage < 0) damage = 0;
            character.Health -= damage;
            Console.WriteLine($"{Name}이(가) {character.Name}에게 {damage}만큼의 피해를 입혔습니다.");
        }
    }

    public void ChargeActionGauge()
    {
        if (IsAlive()) // 적이 살아있을 때만 게이지 충전
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
                Console.WriteLine($"{ActivePotion[i].Name}의 효과가 다하였습니다!");
                Console.WriteLine();
                ActivePotion.Remove(ActivePotion[i]);
            }
        }
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
            Console.WriteLine("4. 마력");
            Console.WriteLine("5. 속도");
            Console.Write("원하는 스탯을 선택하세요: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BaseAttackPower += 5;
                    Console.WriteLine("공격력이 증가했습니다.");
                    StatPoint--;
                    break;
                case "2":
                    BaseDefensePower += 5;
                    Console.WriteLine("방어력이 증가했습니다.");
                    StatPoint--;
                    break;
                case "3":
                    MaxHealth += 5;
                    Health = MaxHealth;
                    Console.WriteLine("최대 체력이 증가했습니다.");
                    StatPoint--;
                    break;
                case "4":
                    MaxMana += 5;
                    Mana = MaxMana;
                    Console.WriteLine("최대 마력이 증가했습니다.");
                    StatPoint--;
                    break;
                case "5":
                    Speed += 5;
                    Console.WriteLine("속도가 증가했습니다.");
                    StatPoint--;
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    continue;
            }
        }
    }
}

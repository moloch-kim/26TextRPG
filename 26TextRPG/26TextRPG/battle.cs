using System;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    Player player = Player.Instance;

    public Battle(Player player)
    {
        this.player = player;
    }

    public void Start(int Floor)
    {
        List<Enemy> enemies = new List<Enemy> //층 별로 등장할 수 있는 몬스터의 리스트 ex) enemyListByFloor[int Floor] 같은 것에서 받아올것
        {
            //에너미 리스트의 예시
            // 이름, id, 체력, 공격력, 방어력, 속도, 경험치보상, 골드보상 순서
            new Enemy("고블린", 1, 50, 10, 2, 8, 20, 50),
            new Enemy("오크", 2, 80, 12, 4, 6, 40, 100),
            new Enemy("트롤", 3, 100, 8, 6, 5, 60, 150)
        };

        Random random = new Random();
        int numberOfEnemies = random.Next(1, 5); // 1명에서 4명 사이의 적 생성
        var selectedEnemies = enemies.OrderBy(e => random.Next()).Take(numberOfEnemies).ToList();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== 당신은 몬스터를 조우했다. ====");
            Console.WriteLine($"{player.Name} VS 적들: {string.Join(", ", selectedEnemies.Select(e => e.Name))}");
            Console.WriteLine();

            player.ChargeActionGauge();
            foreach (var enemy in selectedEnemies)
            {
                enemy.ChargeActionGauge();
            }

            DisplayStatus(player, selectedEnemies);

            if (player.CanAct())
            {
                PlayerTurn(selectedEnemies);
            }

            foreach (var enemy in selectedEnemies)
            {
                if (enemy.Health > 0 && enemy.CanAct())
                {
                    EnemyTurn(enemy);
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("당신은 패배했습니다....");
                Console.WriteLine("아무키나 누르세요...");
                Console.ReadKey();
                break;
            }

            if (selectedEnemies.All(e => e.Health <= 0))
            {
                Console.WriteLine("모든 적을 물리쳤습니다!");
                Console.WriteLine("아무키나 누르세요...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("아무키나 누르세요...");
            Console.ReadKey();
        }

        ReturnToStage();
    }

    private void ReturnToStage()
    {
        Console.WriteLine($"{player.Name}은 다음 방으로 눈을 돌립니다...");
        Console.WriteLine("아무키나 누르세요...");
        Console.ReadKey();
    }


    private void DisplayStatus(Player player, List<Enemy> enemies)
    {
        Console.WriteLine($"{player.Name}: Health = {player.Health}/{player.MaxHealth}, Action Gauge = {player.ActionGauge}%");
        foreach (var enemy in enemies)
        {
            Console.WriteLine($"{enemy.Name}: Health = {enemy.Health}, Action Gauge = {enemy.ActionGauge}%");
        }
    }

    private void PlayerTurn(List<Enemy> enemies)
    {
        player.ResetActionGauge();
        Console.WriteLine("당신의 턴입니다. 할 행동을 선택하십시오.");
        Console.WriteLine("1. 공격");
        Console.WriteLine("2. 스킬");
        Console.WriteLine("3. 방어");
        Console.WriteLine("4. 도망치기");

        bool validInput = false;
        while (!validInput)
        {
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                AttackChoice(enemies);
                validInput = true;
            }
            else if (choice == "2")
            {
                SkillChoice(enemies);
                validInput = true;
            }
            else if (choice == "3")
            {
                player.Defend(); // 방어 메소드
                validInput = true;
            }
            else if (choice == "4")
            {
                Console.WriteLine("도망쳤습니다!");
                validInput = true; // 도망치기 로직 필요
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
            }
        }
    }

    private void AttackChoice(List<Enemy> enemies)
    {
        var aliveEnemies = enemies.Where(e => e.Health > 0).ToList();
        if (aliveEnemies.Count > 0)
        {
            Console.WriteLine("공격할 적의 번호를 선택하세요:");
            for (int i = 0; i < aliveEnemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aliveEnemies[i].Name}");
            }

            string input = Console.ReadLine();
            if (int.TryParse(input, out int targetIndex) && targetIndex > 0 && targetIndex <= aliveEnemies.Count)
            {
                player.Attack(aliveEnemies[targetIndex - 1]);
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
            }
        }
        else
        {
            Console.WriteLine("공격할 적이 없습니다.");
        }
    }

    private void SkillChoice(List<Enemy> enemies)
    {
        Console.WriteLine("사용할 스킬을 선택하세요:");
        for (int i = 0; i < player.SkillList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.SkillList[i].Name} (소모 마나: {player.SkillList[i].ManaCost})");
        }

        string input = Console.ReadLine();
        if (int.TryParse(input, out int skillIndex) && skillIndex > 0 && skillIndex <= player.SkillList.Count)
        {
            Skill selectedSkill = player.SkillList[skillIndex - 1];
            if (player.Mana >= selectedSkill.ManaCost)
            {
                if (selectedSkill.IsArea)
                {
                    foreach (var enemy in enemies.Where(e => e.Health > 0))
                    {
                        player.UseSkill(selectedSkill, enemy);
                    }
                }
                else
                {
                    AttackChoice(enemies);
                }
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
        else
        {
            Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
        }
    }

    private void EnemyTurn(Enemy enemy)
    {
        Console.WriteLine($"적 {enemy.Name}의 턴입니다....");
        enemy.Attack(player); //enemy클래스에 Attack(player) 메소드 필요
        enemy.ResetActionGauge();
    }
}

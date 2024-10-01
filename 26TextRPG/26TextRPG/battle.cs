using _26TextRPG;
using _26TextRPG.Dungeon;
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

    bool keepBattle = true;

    public void Start(int Floor)
    {
        List<Enemy> enemies = EnemyRepository.GetEnemyListByFloor(Floor);

        List<Enemy> selectedEnemies = new List<Enemy> {  };

        if (Floor % 5 != 0)
        {
            Random random = new Random();
            int numberOfEnemies = random.Next(1, 5); // 1명에서 4명 사이의 적 생성
            selectedEnemies = enemies.OrderBy(e => random.Next()).Select(e => new Enemy(e)).Take(numberOfEnemies).ToList();
        }
        else if (Floor % 5 == 0) {
            selectedEnemies = enemies;
        }
        

        Console.Clear();
        Console.WriteLine("==== 당신은 몬스터를 조우했다. ====");
        Console.WriteLine($"{player.Name} VS 적들: {string.Join(", ", selectedEnemies.Select(e => e.Name))}");
        Console.WriteLine();
        DisplayMono(player, selectedEnemies);

        
        while (keepBattle)
        {
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
                    EnemyTurn(enemy, enemies);
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("당신은 패배했습니다....");
                Console.WriteLine("아무키나 누르세요...");
                player.Health = 1;
                Console.ReadKey();
                Console.Clear();
                ReturnToStage();
            }

            if (selectedEnemies.All(e => e.Health <= 0))
            {
                Console.WriteLine("모든 적을 물리쳤습니다!");
                Console.WriteLine("아무키나 누르세요...");
                Console.ReadKey();
                Console.Clear();
                ReturnToStage();
            }

            //Console.WriteLine("아무키나 누르세요...");
            //Console.ReadKey();
            Thread.Sleep(50);
        }
    }

    private void ReturnToStage()
    {
        keepBattle = false;
        Console.WriteLine($"{player.Name}은 다음 방으로 눈을 돌립니다...");
        Console.WriteLine("아무키나 누르세요...");
        Console.ReadKey();
        
    }

    private void DisplayMono(Player player, List<Enemy> enemies)
    {
        // 플레이어 상태 출력
        Console.SetCursorPosition(0, 3);
        Console.Write($"{player.Name}: ");
        Console.SetCursorPosition(15, 3);
        Console.Write($"체력 =     /{player.MaxHealth}");
        Console.SetCursorPosition(33, 3);
        Console.Write($"행동력 =");


        // 적의 상태 출력
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.SetCursorPosition(0, 5 + i);
            Console.Write($"{enemies[i].Name}: ");
            Console.SetCursorPosition(15, 5 + i);
            Console.Write($"체력 =     /{enemies[i].MaxHealth}");
            Console.SetCursorPosition(33, 5 + i);
            Console.Write($"행동력 =");
        }
    }

    private void DisplayStatus(Player player, List<Enemy> enemies)
    {
        // 플레이어 상태 숫자 업데이트
        Console.SetCursorPosition(23, 3);
        Console.Write($"{player.Health} "); // 체력
        Console.SetCursorPosition(43, 3);
        Console.Write($"{player.ActionGauge}%    "); // 행동력

        // 적의 상태 숫자 업데이트
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.SetCursorPosition(23, 5 + i);
            Console.Write($"{enemies[i].Health} "); // 적 체력
            Console.SetCursorPosition(43, 5 + i);
            Console.Write($"{enemies[i].ActionGauge}%    "); // 적 행동력
        }

        Console.SetCursorPosition(0, enemies.Count + 2); // 다음 출력 위치 조정
    }


    private void PlayerTurn(List<Enemy> enemies)
    {
        player.ResetActionGauge();
        ClearLines(10, 20);
        Console.SetCursorPosition(0, 10);
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
                validInput = true;
                ReturnToStage();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
            }
        }

        Console.WriteLine("아무키나 누르세요...");
        Console.ReadKey();
        ClearLines(10,20);
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

    private void EnemyTurn(Enemy enemy, List<Enemy> enemies)
    {
        ClearLines(10, 20);
        Console.SetCursorPosition(0, 10);
        Console.WriteLine($"적 {enemy.Name}의 턴입니다....");
        enemy.Attack(player); //enemy클래스에 Attack(player) 메소드 필요
        enemy.ResetActionGauge();

        Console.WriteLine("아무키나 누르세요...");
        Console.ReadKey();
        ClearLines(10,20);
    }

    private void ClearLines(int startLine, int numberOfLines)
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            Console.SetCursorPosition(0, startLine + i);
            Console.Write(new string(' ', Console.WindowWidth)); // 해당 줄을 공백으로 덮어쓰기
        }
        Console.SetCursorPosition(0, startLine);
    }

}

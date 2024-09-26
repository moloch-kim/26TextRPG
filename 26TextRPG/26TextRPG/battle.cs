using System;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    Character player = new Character;

    public Battle(Character player)
    {
        this.player = player;
    }

    public void Start(int Floor)
    {
        List<Enemy> enemies = new List<Enemy>
        {
            //에너미 리스트의 예시
            // 이름, 속도, 체력 순서
            new Enemy("고블린", 10, 30), 
            new Enemy("오크", 12, 50),
            new Enemy("트롤", 8, 80)
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

            if (player.CharacterCanAct()) // 수정된 부분
            {
                PlayerTurn(selectedEnemies);
            }

            foreach (var enemy in selectedEnemies)
            {
                if (enemy.Health > 0 && enemy.EnemyCanAct())
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
        Console.WriteLine($"{player.name}은 다음 방으로 눈을 돌립니다...");
        Console.WriteLine("아무키나 누르세요...");
        Console.ReadKey();
    }


    private void DisplayStatus(Character player, List<Enemy> enemies)
    {
        Console.WriteLine($"{player.Name}: Health = {player.Health}/{player.MaxHealth}, Action Gauge = {player.ActionGauge}%");
        foreach (var enemy in enemies)
        {
            Console.WriteLine($"{enemy.Name}: Health = {enemy.Health}, Action Gauge = {enemy.ActionGauge}%");
        }
    }

    private void PlayerTurn(List<Enemy> enemies)
    {
        player.ResetCharacterActionGauge();
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
                // 살아있는 적만 필터링
                var aliveEnemies = enemies.Where(e => e.Health > 0).ToList();
                if (aliveEnemies.Count > 0)
                {
                    Console.WriteLine("공격할 적의 번호를 선택하세요:");
                    for (int i = 0; i < aliveEnemies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {aliveEnemies[i].Name}");
                    }

                    int targetIndex = int.Parse(Console.ReadLine()) - 1;
                    if (targetIndex >= 0 && targetIndex < aliveEnemies.Count)
                    {
                        player.Attack(aliveEnemies[targetIndex]); // Attack 메소드 필요
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다. 다시 선택하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("공격할 적이 없습니다.");
                    validInput = true; // 더 이상 선택할 적이 없으므로 종료
                }
            }
            else if (choice == "2")
            {
                // 스킬 사용 로직 추가 필요
                Console.WriteLine("스킬 사용 로직을 구현하세요.");
                validInput = true;
            }
            else if (choice == "3")
            {
                player.Defend(); // Defend 메소드 필요
                validInput = true;
            }
            else if (choice == "4")
            {
                Console.WriteLine("도망쳤습니다!");
                // 도망치기 로직 추가 필요
                validInput = true;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
            }
        }
    }


    private void EnemyTurn(Enemy enemy)
    {
        Console.WriteLine($"적 {enemy.Name}의 턴입니다....");
        enemy.Attack(player); //enemy클래스에 Attack(player) 메소드 필요
        enemy.ResetEnemyActionGauge();
    }
}

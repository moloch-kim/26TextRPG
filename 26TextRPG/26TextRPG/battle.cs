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
        List<Enemy> enemies = new List<Enemy> //�� ���� ������ �� �ִ� ������ ����Ʈ ex) enemyListByFloor[int Floor] ���� �Ϳ��� �޾ƿð�
        {
            //���ʹ� ����Ʈ�� ����
            // �̸�, id, ü��, ���ݷ�, ����, �ӵ�, ����ġ����, ��庸�� ����
            new Enemy("���", 1, 50, 10, 2, 8, 20, 50),
            new Enemy("��ũ", 2, 80, 12, 4, 6, 40, 100),
            new Enemy("Ʈ��", 3, 100, 8, 6, 5, 60, 150)
        };

        Random random = new Random();
        int numberOfEnemies = random.Next(1, 5); // 1���� 4�� ������ �� ����
        var selectedEnemies = enemies.OrderBy(e => random.Next()).Take(numberOfEnemies).ToList();

        Console.Clear();
        Console.WriteLine("==== ����� ���͸� �����ߴ�. ====");
        Console.WriteLine($"{player.Name} VS ����: {string.Join(", ", selectedEnemies.Select(e => e.Name))}");
        Console.WriteLine();
        DisplayMono(player, selectedEnemies);

        while (true)
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
                Console.WriteLine("����� �й��߽��ϴ�....");
                Console.WriteLine("�ƹ�Ű�� ��������...");
                Console.ReadKey();
                break;
            }

            if (selectedEnemies.All(e => e.Health <= 0))
            {
                Console.WriteLine("��� ���� �����ƽ��ϴ�!");
                Console.WriteLine("�ƹ�Ű�� ��������...");
                Console.ReadKey();
                break;
            }

            //Console.WriteLine("�ƹ�Ű�� ��������...");
            //Console.ReadKey();
            Thread.Sleep(50);
        }

        ReturnToStage();
    }

    private void ReturnToStage()
    {
        Console.WriteLine($"{player.Name}�� ���� ������ ���� �����ϴ�...");
        Console.WriteLine("�ƹ�Ű�� ��������...");
        Console.ReadKey();
    }

    private void DisplayMono(Player player, List<Enemy> enemies)
    {
        // �÷��̾� ���� ���
        Console.SetCursorPosition(0, 3);
        Console.Write($"{player.Name}: ");
        Console.SetCursorPosition(7, 3);
        Console.Write($"ü�� =     /{player.MaxHealth}");
        Console.SetCursorPosition(25, 3);
        Console.Write($"�ൿ�� =");


        // ���� ���� ���
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.SetCursorPosition(0, 5 + i);
            Console.Write($"{enemies[i].Name}: ");
            Console.SetCursorPosition(7, 5 + i);
            Console.Write($"ü�� =     /{enemies[i].MaxHealth}");
            Console.SetCursorPosition(25, 5 + i);
            Console.Write($"�ൿ�� =");
        }
    }

    private void DisplayStatus(Player player, List<Enemy> enemies)
    {
        // �÷��̾� ���� ���� ������Ʈ
        Console.SetCursorPosition(15, 3);
        Console.Write($"{player.Health} "); // ü��
        Console.SetCursorPosition(35, 3);
        Console.Write($"{player.ActionGauge}%    "); // �ൿ��

        // ���� ���� ���� ������Ʈ
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.SetCursorPosition(15, 5 + i);
            Console.Write($"{enemies[i].Health} "); // �� ü��
            Console.SetCursorPosition(35, 5 + i);
            Console.Write($"{enemies[i].ActionGauge}%    "); // �� �ൿ��
        }

        Console.SetCursorPosition(0, enemies.Count + 2); // ���� ��� ��ġ ����
    }


    private void PlayerTurn(List<Enemy> enemies)
    {
        player.ResetActionGauge();
        ClearLines(10, 20);
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("����� ���Դϴ�. �� �ൿ�� �����Ͻʽÿ�.");
        Console.WriteLine("1. ����");
        Console.WriteLine("2. ��ų");
        Console.WriteLine("3. ���");
        Console.WriteLine("4. ����ġ��");

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
                player.Defend(); // ��� �޼ҵ�
                validInput = true;
            }
            else if (choice == "4")
            {
                Console.WriteLine("�����ƽ��ϴ�!");
                validInput = true; // ����ġ�� ���� �ʿ�
            }
            else
            {
                Console.WriteLine("�߸��� �Է��Դϴ�. �ٽ� �����ϼ���.");
            }
        }

        Console.WriteLine("�ƹ�Ű�� ��������...");
        Console.ReadKey();
        ClearLines(15, 30);
    }

    private void AttackChoice(List<Enemy> enemies)
    {
        var aliveEnemies = enemies.Where(e => e.Health > 0).ToList();
        if (aliveEnemies.Count > 0)
        {
            Console.WriteLine("������ ���� ��ȣ�� �����ϼ���:");
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
                Console.WriteLine("�߸��� �����Դϴ�. �ٽ� �����ϼ���.");
            }
        }
        else
        {
            Console.WriteLine("������ ���� �����ϴ�.");
        }
    }

    private void SkillChoice(List<Enemy> enemies)
    {
        Console.WriteLine("����� ��ų�� �����ϼ���:");
        for (int i = 0; i < player.SkillList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.SkillList[i].Name} (�Ҹ� ����: {player.SkillList[i].ManaCost})");
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
                Console.WriteLine("������ �����մϴ�.");
            }
        }
        else
        {
            Console.WriteLine("�߸��� �����Դϴ�. �ٽ� �����ϼ���.");
        }
    }

    private void EnemyTurn(Enemy enemy, List<Enemy> enemies)
    {
        ClearLines(10, 20);
        Console.SetCursorPosition(0, 10);
        Console.WriteLine($"�� {enemy.Name}�� ���Դϴ�....");
        enemy.Attack(player); //enemyŬ������ Attack(player) �޼ҵ� �ʿ�
        enemy.ResetActionGauge();

        Console.WriteLine("�ƹ�Ű�� ��������...");
        Console.ReadKey();
        ClearLines(15, 30);
    }

    private void ClearLines(int startLine, int numberOfLines)
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            Console.SetCursorPosition(0, startLine + i);
            Console.Write(new string(' ', Console.WindowWidth)); // �ش� ���� �������� �����
        }
    }

}

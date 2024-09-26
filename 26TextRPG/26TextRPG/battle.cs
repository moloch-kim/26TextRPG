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
            //���ʹ� ����Ʈ�� ����
            // �̸�, �ӵ�, ü�� ����
            new Enemy("���", 10, 30), 
            new Enemy("��ũ", 12, 50),
            new Enemy("Ʈ��", 8, 80)
        };

        Random random = new Random();
        int numberOfEnemies = random.Next(1, 5); // 1���� 4�� ������ �� ����
        var selectedEnemies = enemies.OrderBy(e => random.Next()).Take(numberOfEnemies).ToList();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== ����� ���͸� �����ߴ�. ====");
            Console.WriteLine($"{player.Name} VS ����: {string.Join(", ", selectedEnemies.Select(e => e.Name))}");
            Console.WriteLine();

            player.ChargeActionGauge();
            foreach (var enemy in selectedEnemies)
            {
                enemy.ChargeActionGauge();
            }

            DisplayStatus(player, selectedEnemies);

            if (player.CharacterCanAct()) // ������ �κ�
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

            Console.WriteLine("�ƹ�Ű�� ��������...");
            Console.ReadKey();
        }

        ReturnToStage();
    }

    private void ReturnToStage()
    {
        Console.WriteLine($"{player.name}�� ���� ������ ���� �����ϴ�...");
        Console.WriteLine("�ƹ�Ű�� ��������...");
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
                // ����ִ� ���� ���͸�
                var aliveEnemies = enemies.Where(e => e.Health > 0).ToList();
                if (aliveEnemies.Count > 0)
                {
                    Console.WriteLine("������ ���� ��ȣ�� �����ϼ���:");
                    for (int i = 0; i < aliveEnemies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {aliveEnemies[i].Name}");
                    }

                    int targetIndex = int.Parse(Console.ReadLine()) - 1;
                    if (targetIndex >= 0 && targetIndex < aliveEnemies.Count)
                    {
                        player.Attack(aliveEnemies[targetIndex]); // Attack �޼ҵ� �ʿ�
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("�߸��� �����Դϴ�. �ٽ� �����ϼ���.");
                    }
                }
                else
                {
                    Console.WriteLine("������ ���� �����ϴ�.");
                    validInput = true; // �� �̻� ������ ���� �����Ƿ� ����
                }
            }
            else if (choice == "2")
            {
                // ��ų ��� ���� �߰� �ʿ�
                Console.WriteLine("��ų ��� ������ �����ϼ���.");
                validInput = true;
            }
            else if (choice == "3")
            {
                player.Defend(); // Defend �޼ҵ� �ʿ�
                validInput = true;
            }
            else if (choice == "4")
            {
                Console.WriteLine("�����ƽ��ϴ�!");
                // ����ġ�� ���� �߰� �ʿ�
                validInput = true;
            }
            else
            {
                Console.WriteLine("�߸��� �Է��Դϴ�. �ٽ� �����ϼ���.");
            }
        }
    }


    private void EnemyTurn(Enemy enemy)
    {
        Console.WriteLine($"�� {enemy.Name}�� ���Դϴ�....");
        enemy.Attack(player); //enemyŬ������ Attack(player) �޼ҵ� �ʿ�
        enemy.ResetEnemyActionGauge();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    Character player = new Character("",0);

    public Battle(Character player)
    {
        this.player = player;
    }

    public void Start(int Floor)
    {
        List<Enemy> enemies = new List<Enemy> //�� ���� ������ �� �ִ� ������ ����Ʈ ex) enemyListByFloor[int Floor] ���� �Ϳ��� �޾ƿð�
        {
            //���ʹ� ����Ʈ�� ����
            // �̸�, �ӵ�, ü�� ����
            new Enemy("���", 50, 10, 2, 8, 20, 50),
            new Enemy("��ũ", 80, 12, 4, 6, 40, 100),
            new Enemy("Ʈ��", 100, 8, 6, 5, 60, 150)
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

            player.ChargeCharacterActionGauge();
            foreach (var enemy in selectedEnemies)
            {
                enemy.ChargeEnemyActionGauge();
            }

            DisplayStatus(player, selectedEnemies);

            if (player.CharacterCanAct())
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
        Console.WriteLine($"{player.Name}�� ���� ������ ���� �����ϴ�...");
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



    private void EnemyTurn(Enemy enemy)
    {
        Console.WriteLine($"�� {enemy.Name}�� ���Դϴ�....");
        enemy.Attack(player); //enemyŬ������ Attack(player) �޼ҵ� �ʿ�
        enemy.ResetEnemyActionGauge();
    }
}

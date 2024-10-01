using _26TextRPG;

public class Status
{
    public void DisplayStatus() // ���� ���
    {
        Player playerData = Player.Instance;

        // �곻 �ѵ� Ŭ������ ����־�ɵ�
        int enforceAttack = playerData.AttackPower - playerData.BaseAttackPower;
        int enforceDefense = playerData.DefensePower - playerData.BaseDefensePower;

        Console.WriteLine("���� ����: ");
        Console.WriteLine("ĳ������ ���� �� ������ ǥ�õ˴ϴ�.");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"Lv. {playerData.Level}");
        Console.WriteLine($"���� : {playerData.Job}");

        if (enforceAttack == 0) { Console.WriteLine($"{playerData.AttackPower}"); }
        else { Console.WriteLine($"���ݷ� : {playerData.AttackPower} (+{enforceAttack})"); }

        if (enforceDefense == 0) { Console.WriteLine($"{playerData.DefensePower}"); }
        else { Console.WriteLine($"���� : {playerData.DefensePower} (+{enforceDefense})"); }

        Console.WriteLine($"ü �� : {playerData.MaxHealth}");
        Console.WriteLine($"Gold : {playerData.Gold}");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("������ : ESC");

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return;
        }
        else
        {
            TypingEffect("�߸��� �����Դϴ�.", 40); 
            Console.WriteLine(); Thread.Sleep(100);
        }
    }

    private void TypingEffect(string text, int delay) // (Ÿ������ ���� ġ�°� ���� ȿ��) srting ���ڿ��� int ������ ���� �־��ָ�
    {
        foreach (char c in text)// text�� ����ִ� ���ڿ��� foreach�� �̿��� ������� c�� ���ڷ� �����
        {
            Console.Write(c); //c�� ��� ���ڸ� ���
            Thread.Sleep(delay);// ������ �����̸�ŭ ����
        }// ���ڿ��� ���ڷ� ��ȯ�Ͽ� ���ʴ�� ����ϸ鼭 ���� ���̻��̿� �����̸� �־� Ÿ���� ȿ���� ����
    }

}


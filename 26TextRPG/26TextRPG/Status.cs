using _26TextRPG;

public class Status
{
    public void DisplayStatus() // 스탯 출력
    {
        Console.Clear();
        Player playerData = Player.Instance;

        // 얘내 둘도 클래스에 집어넣어도될듯

            int enforceAttack = playerData.AttackPower - playerData.BaseAttackPower;
            int enforceDefense = playerData.DefensePower - playerData.BaseDefensePower;

        Console.WriteLine("스탯 보기: ");
        TypingEffect("캐릭터의 정보 및 스탯이 표시됩니다.", 40);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Lv. {playerData.Level} , Exp. {playerData.Exp} ");
        Console.WriteLine($"직업 : {playerData.Job}");

        if (playerData.EquipedWeapon != null) { Console.WriteLine($"공격력 : {playerData.BaseAttackPower} (+ {playerData.EquipedWeapon.Offense})"); }
        else { Console.WriteLine($"공격력 : {playerData.BaseAttackPower}"); }

        if (playerData.EquipedArmor != null) { Console.WriteLine($"방어력 : {playerData.BaseDefensePower} (+ {playerData.EquipedArmor.Defense})"); }
        else { Console.WriteLine($"방어력 : {playerData.BaseDefensePower}"); }

        Console.WriteLine($"체력 : {playerData.MaxHealth} , 마력 : {playerData.MaxMana} ");
        Console.WriteLine($"Gold : {playerData.Gold}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("나가기 : ESC");

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return;
        }
        else
        {
            TypingEffect("잘못된 선택입니다.", 40);
            Console.WriteLine(); Thread.Sleep(100);
        }
    }

    private void TypingEffect(string text, int delay) // (타이핑을 직접 치는것 같은 효과) srting 문자열과 int 딜레이 값을 넣어주면
    {
        foreach (char c in text)// text에 들어있는 문자열을 foreach를 이용해 순서대로 c에 문자로 담아줌
        {
            Console.Write(c); //c에 담긴 문자를 출력
            Thread.Sleep(delay);// 설정한 딜레이만큼 슬립
        }// 문자열을 문자로 변환하여 차례대로 출력하면서 문자 사이사이에 딜레이를 주어 타이핑 효과를 만듦
    }

}
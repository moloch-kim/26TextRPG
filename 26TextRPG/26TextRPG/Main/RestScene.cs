namespace _26TextRPG.Main
{
    public class RestScene
    {
        Player currentPlayer = Player.Instance;
        public void Rest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================================");
            Console.WriteLine("||                                                   ||");
            Console.Write("||       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("휴식한다 : R          메인으로 : ESC");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ||");
            Console.Write("||       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"현재 체력 : {currentPlayer.Health}        최대 체력 : {currentPlayer.MaxHealth}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ||");
            Console.WriteLine("||                                                   ||");
            Console.WriteLine("=======================================================");
            Console.ResetColor();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.R:
                    RestEffect(30);
                    break;
                case ConsoleKey.Escape:
                    break;
            }
            return;
        }
        public void RestEffect(int delay)
        {
            for (int i = 0; i < 101; i++)
            {
                Console.Clear();
                if (i > 0) { Console.ForegroundColor = ConsoleColor.Red; };
                if (i > 30) { Console.ForegroundColor = ConsoleColor.DarkYellow; };
                if (i > 70) { Console.ForegroundColor = ConsoleColor.Green; };
                Console.WriteLine($"{i}% 회복됨");
                Console.ResetColor();
                int restTime = (i/4);
                Console.WriteLine($"휴식한 시간 : 00:{restTime}분");
                Thread.Sleep(delay);
            }
            Console.Clear();
            Console.WriteLine("휴식한 시간 : 00:26분");
            Console.WriteLine("26분간 휴식을 취했습니다.. !");
            Console.WriteLine("적당한 휴식을 완료하여 체력이 모두 회복되었습니다 !");
            currentPlayer.Health = currentPlayer.MaxHealth;
            Thread.Sleep(2000);
        }
    }
}
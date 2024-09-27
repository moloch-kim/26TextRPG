namespace _26TextRPG.Main
{
    public class RestScene
    {
        public void Rest()
        {
            Console.WriteLine("휴식을 시작 어쩌구 하겠슴까");
            Console.WriteLine("시작하려면 a 아님 esc");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
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
                Thread.Sleep(delay);
                Console.ResetColor();
            }
            Console.WriteLine("휴식완료됐음");
            Thread.Sleep(2000);
        }
    }
}
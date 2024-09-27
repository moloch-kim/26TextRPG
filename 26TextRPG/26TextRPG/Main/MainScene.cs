using System.Net.Sockets;

namespace _26TextRPG.Main
{
    public class MainScene
    {
        public void Opening()
        {
            Logo();
            string message = "게임 내 기능에 알맞은 스토리 내용 등 초반이야기";
            TypingEffect(message, 50);
            Thread.Sleep(1000);
            Console.Clear();
            Logo();
            message = "혹은 저장된 게임을 불러오는 중...";
            TypingEffect(message, 50);
            Thread.Sleep(1000);
            Console.Clear();
            Logo();
            message = "저장된 게임 없음 새로운 게임 시작...";
            TypingEffect(message, 50);
            Thread.Sleep(1000);

        }

        public void Logo()
        {
            Console.WriteLine("______                                            _____   ____  _    _     ");
            Console.WriteLine("|  _  \\                                          / __  \\ / ___|| |  | |    ");
            Console.WriteLine("| | | | _   _  _ __    __ _   ___   ___   _ __   `' / /'/ /___ | |_ | |__  ");
            Console.WriteLine("| | | || | | || '_ \\  / _` | / _ \\ / _ \\ | '_ \\    / /  | ___ \\| __|| '_ \\ ");
            Console.WriteLine("| |/ / | |_| || | | || (_| ||  __/| (_) || | | | ./ /___| \\_/ || |_ | | | |");
            Console.WriteLine("|___/   \\__,_||_| |_| \\__, | \\___| \\___/ |_| |_| \\_____/\\_____/ \\__||_| |_|");
            Console.WriteLine("                       __/ |                                               ");
            Console.WriteLine("                      |___/                                                   ");
        }

        public void RunGame()
        {
            Console.Clear();
            Console.WriteLine("26TextRpg에 오신것을 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("s. 능력치");
            Console.WriteLine("i. 인벤토리");
            Console.WriteLine("p. 상점");
            Console.WriteLine("d. 던전 입장");
            Console.WriteLine("r. 휴식하기");
            Console.WriteLine("esc. 종료");
            Console.WriteLine("");// 사용감의 답답함을 없애기 위해 readkey 사용예정

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.S:
                    Console.WriteLine("S");
                    break;
                case ConsoleKey.I:
                    Console.WriteLine("I");
                    break;
                case ConsoleKey.P:
                    Console.WriteLine("P");
                    break;
                case ConsoleKey.D:
                    RunStage();
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("R");
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Esc");
                    break;
            }
        }

        public void TypingEffect(string text, int delay) // (타이핑을 직접 치는것 같은 효과) srting 문자열과 int 딜레이 값을 넣어주면
        {
            foreach (char c in text)// text에 들어있는 문자열을 foreach를 이용해 순서대로 c에 문자로 담아줌
            {
                Console.Write(c); //c에 담긴 문자를 출력
                Thread.Sleep(delay);// 설정한 딜레이만큼 슬립
            }// 문자열을 문자로 변환하여 차례대로 출력하면서 문자 사이사이에 딜레이를 주어 타이핑 효과를 만듦
        }

        public void RunStage()
        {
             _26TextRPG.Stage.Stage runstage = new _26TextRPG.Stage.Stage(1);
            while (true)
            {
                runstage.Explore();
            }
        }



    }
}
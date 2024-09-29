using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;

using static System.Net.Mime.MediaTypeNames;

namespace _26TextRPG.Main
{

    public class MainScene
    {
        private Player currentPlayer;// 진행상황 저장용
        public void Save()// 저장
        {
            SaveLoadSystem.SaveGame(currentPlayer);
        }
        public void Load()//불러오기
        {

            Player loadedPlayer = SaveLoadSystem.LoadGame();

            if (loadedPlayer != null)
            {
                currentPlayer = loadedPlayer;
                Console.WriteLine($"{currentPlayer.Name}의 데이터를 성공적으로 불러왔습니다.");
                Thread.Sleep( 2000 );
            }
            else
            {
                Console.WriteLine("저장된 파일이 없습니다. 새로운 플레이어를 생성합니다.");
                CreatePlayer(); // 닉네임 생성
            }
        }
        public void CreatePlayer()// 닉네임 생성
        {
            Console.WriteLine("게임에 처음 접속하셨습니다.");
            Console.WriteLine("원하는 닉네임을 입력해주세요.");
            string nickName = Console.ReadLine();
            currentPlayer = new Player(nickName);
            //currentPlayer.Level = 1; 초기값 설정
            //currentPlayer.Gold = 1500;
            Console.WriteLine($"닉네임 : {nickName}");
            Save();
            Thread.Sleep(2000);
        }

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

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("26TextRpg에 오신것을 환영합니다.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================================");
            Console.WriteLine("||                                                   ||");
            Console.Write("||       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("능력치 : S    인벤토리 : I    상점 : P");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("      ||");
            Console.Write("||         ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("던전 : D    휴식 : R    종료 : ESC");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ||");
            Console.WriteLine("||                                                   ||");
            Console.WriteLine("=======================================================");
            Console.ResetColor();
            Console.WriteLine("");// 사용감의 답답함을 없애기 위해 readkey 사용예정
        }

        public void RunGame()
        {
            Player player = currentPlayer;
            RestScene restScene = new RestScene();

            while (true)
            {
                MainMenu();
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
                        Shop shop = new Shop(Shoplist.WeaponShop);
                            shop.BuyItem(player);
                        break;
                    case ConsoleKey.D:
                        RunStage(player);
                        break;
                    case ConsoleKey.R:
                        restScene.Rest();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
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
        
        public void RunStage(Player player)
        {
            Stage runStage = new(1);
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("탐험하기 : A");

                // 다음층 확인
                if (runStage.StairFound)
                {
                    Console.WriteLine("다음층으로 : S");
                }

                Console.WriteLine("나가기 : ESC");
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        runStage.Explore(player);
                        break;
                    case ConsoleKey.Escape:
                        RunGame();
                        break;
                    case ConsoleKey.S:
                        if(runStage.StairFound)
                        {
                            ++runStage.StageFloor;
                            runStage.StairFound = false;
                        }
                        break;
                }
            }
        }



    }
}
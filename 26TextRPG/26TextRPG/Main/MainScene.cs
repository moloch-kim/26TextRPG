using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using _26TextRPG.Dungeon;
using _26TextRPG.Main;
using _26TextRPG;

using static System.Net.Mime.MediaTypeNames;

namespace _26TextRPG.Main
{

    public class MainScene
    {
        Player playerData = Player.Instance;
        //저장, 불러오기, 싱글톤 업데이트
        public void Loading()
        {
            Save();
            Console.Clear();
            Logo();
            Player.LoadPlayer(playerData);
        }

        public void Save()// 저장
        {
            SaveLoadSystem.SaveGame(playerData);
        }
        public void Load()//불러오기
        {
            Player loadedPlayer = SaveLoadSystem.LoadGame();

            if (loadedPlayer != null)
            {
                playerData = loadedPlayer;
                Player.LoadPlayer(playerData);//싱글톤화시킨 Player에 불러온값 넣어주기
                Console.WriteLine($"{playerData.Name}의 기억을 성공적으로 불러왔습니다.");
                Thread.Sleep( 2000 );
            }
            else
            {
                Console.WriteLine("저장된 기억이 없습니다. 새로운 기억을 생성합니다.");
                Thread.Sleep(1000);
                CreatePlayer(); // 닉네임 생성
            }
        }
        
        public void Opening()
        {
            Logo();
            string message = "눈을 떠보니 아무것도 기억나질 않는다...";
            TypingEffect(message, 50);
            Thread.Sleep(1000);
            Console.Clear();
            Logo();
            message = "저장된 기억을 떠올리는중...";
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
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"이름 : {playerData.Name}    직업: {playerData.Job}    골드 : {playerData.Gold}");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================================");
            Console.WriteLine("||                                                   ||");
            Console.Write("|| ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("능력치 : S   인벤토리 : I   상점 : P   훈련장 : Q");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ||");
            Console.Write("||     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("던전 : D       휴식 : R       종료 : ESC");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("      ||");
            Console.WriteLine("||                                                   ||");
            Console.WriteLine("=======================================================");
            Console.WriteLine("");// 사용감의 답답함을 없애기 위해 readkey 사용예정
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                         기억초기화 : K");
            Console.ResetColor();
        }

        public void RunGame()
        {
            Player playerData = Player.Instance;
            Shop shop = new Shop(Shoplist.Startshop);
            RestScene restScene = new RestScene();
            Status status = new Status();

            while (true)
            {
                Loading();
                MainMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.S://능력치
                        Console.WriteLine("S");
                        status.DisplayStatus();
                        break;
                    case ConsoleKey.I://인벤토리
                        ItemRepository.Inventory();
                        break;
                    case ConsoleKey.P://상점
                        Console.WriteLine("P");
                        shop.BuyItem();
                        break;
                    case ConsoleKey.D://던전
                        Player player = Player.Instance;
                        if (player.Inventory.Count <= 0)
                        {
                            Console.WriteLine("당신은 아무 장비도 없습니다! 진행하시겠습니까?");
                            Console.WriteLine("[예 : Yes ]");
                            string input = Console.ReadLine();
                            if (input == "Yes")
                            {
                                RunStage();
                                break;
                            }
                            else if (input == "yes")
                            {
                                Console.WriteLine("정확히 Yes라고 입력해주세요.");
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            RunStage();
                            break;
                        }
                    case ConsoleKey.R://휴식
                        restScene.Rest();
                        break;
                    case ConsoleKey.K://데이터초기화
                        ResetDataScene();
                        break;
                    case ConsoleKey.Q://훈련장
                        TrainingRoom room = new TrainingRoom();
                        room.BuySkill();
                        break;
                    case ConsoleKey.Escape:
                        Save();
                        Console.WriteLine("게임을 종료하겠습니다.");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        RunGame();
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
        
        public void RunStage()
        {
            Stage runStage = new(1);
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("탐험하기 : A");
                Console.WriteLine("인벤토리 : I");
                // 다음층 확인
                if (runStage.StairFound)
                {
                    Console.WriteLine("다음층으로 : S");
                }
                if (runStage.ShopFound)
                {
                    Console.WriteLine("상점으로 : P");
                }
                Console.WriteLine("나가기 : ESC");
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        runStage.Explore();
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
                    case ConsoleKey.P:
                        if (runStage.ShopFound)
                        {
                            Random random = new Random();
                            int randomShop = random.Next(1, 5);
                            Shop shop = new Shop((Shoplist)randomShop);
                            runStage.ShopFound = false;
                            shop.BuyItem();
                        }
                        break;
                    case ConsoleKey.I:
                        ItemRepository.Inventory();
                        break;
                }
            }
        }

        public void ResetDataScene()
        {
            Console.Clear();
            Console.WriteLine("기억을 초기화 하시겠습니까 ?");
            Console.WriteLine("K : 초기화      ESC : 메인으로");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.K:
                    ResetData();
                    break;
                case ConsoleKey.Escape:
                    RunGame();
                    break;
            }
        }
        public void ResetData()
        {
            string filePath = "playerData.json";

                File.Delete(filePath);
                Console.WriteLine("저장된 기억을 삭제했습니다. 게임을 종료하겠습니다.");
                Environment.Exit(0);
        }

        public void CreatePlayer()// 닉네임 생성
        {
            Console.Clear();
            TypingEffect("내가 누군지조차 모르겠다. 생각을 하기 시작하자 알수없는 두려움이 느껴진다..", 30);
            Console.WriteLine();
            Console.WriteLine("계속하려면 아무 키나 누르십시오...");
            Console.ReadKey();
            Console.WriteLine();
            TypingEffect("내 이름을 떠올려보자", 30);
            Console.WriteLine();
            Console.Write("내 이름은 : ");
            string nickName = Console.ReadLine();
            Console.WriteLine($"이름 : {nickName}");
            Console.WriteLine();
            TypingEffect("이름은 기억을 해냈다. 하지만 나는 뭘 하던 사람이지..?", 30);
            Console.WriteLine();
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");
            Console.WriteLine();
            Console.Write("내 직업은 : ");
            string jobChoice = Console.ReadLine();
            Console.WriteLine();
            string job = "전사";
            int attackPower = 15;
            int defensePower = 5;
            int maxHealth = 120;
            int speed = 10;
            int maxMana = 30;
            int gold = 1500;

            switch (jobChoice)
            {
                case "1":
                    job = "전사";
                    attackPower = 15;
                    maxHealth = 150;
                    speed = 10;
                    break;
                case "2":
                    job = "마법사";
                    attackPower = 10;
                    maxHealth = 80;
                    maxMana = 50;
                    break;
                case "3":
                    job = "궁수";
                    attackPower = 12;
                    maxHealth = 100;
                    speed = 13;
                    break;
                default:
                    Console.WriteLine("실수로 아무말이나 해버렸다... 첫번째로 기억났던 전사를 하자");
                    break;
            }

            playerData = new Player(nickName, job, attackPower, defensePower, maxHealth, speed, maxMana, gold);
            TypingEffect($"내가 {playerData.Job} 라고 ? {playerData.Job}라면 모험을 시작해야지 기억을 찾기 위한 모험을 하자 ! ", 30);
            Console.WriteLine();
            Console.WriteLine("계속하려면 아무 키나 누르십시오...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"{playerData.Name} 님 ! 대부분의 기억이 살아났습니다 !");
            Console.WriteLine($"직업: {playerData.Job}, 체력: {playerData.MaxHealth}, 공격력: {playerData.AttackPower}");

            Thread.Sleep(2000);
        }

    }
}
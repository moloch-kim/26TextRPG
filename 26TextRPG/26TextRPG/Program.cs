using _26TextRPG.Main;

namespace _26TextRPG
{
    public class Program
    {
        static void Main()
        {
            Program program = new Program();
            Player player = program.CreatePlayer();
            MainScene mainScene = new MainScene();
            mainScene.Opening();
            mainScene.RunGame(player);
        }

        public Player CreatePlayer()
        {
            Console.WriteLine("게임에 처음 접속하셨습니다.");
            Console.WriteLine("원하는 닉네임을 입력해주세요.");
            string nickName = Console.ReadLine();
            Player player = new Player(nickName);
            Console.WriteLine($"닉네임 : {player.Name}");
            Thread.Sleep(2000);
            return player;
        }
    }

    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}

using _26TextRPG.Main;

namespace _26TextRPG
{
    public class Program
    {

        public void Stat()
        {
            
        }

        static void Main()
        {
            CreateAcc createAcc = new CreateAcc();
            Player player = new Player(createAcc.nickName);
            player.Name = createAcc.nickName;
            Console.WriteLine($"닉네임 : {player.Name}");
            MainScene mainScene = new MainScene();
            mainScene.Opening();
            mainScene.RunGame(player);
            //게임시작
        }
    }
}

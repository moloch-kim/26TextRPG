using _26TextRPG.Main;

namespace _26TextRPG
{
    public class Program
    {
        static void Main()
        {
            MainScene mainScene = new MainScene();
            mainScene.Opening();
            mainScene.Load();
            mainScene.RunGame();
        }
    }
}

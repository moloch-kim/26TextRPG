﻿using _26TextRPG.Main;

namespace _26TextRPG
{
    public class Program
    {
        private Player currentPlayer;
        static void Main()
        {
            MainScene mainScene = new MainScene();
            mainScene.Opening();
            mainScene.RunGame();
        }
    }
}

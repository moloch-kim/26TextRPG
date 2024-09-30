using System.Reflection.Emit;
using Newtonsoft.Json;

namespace _26TextRPG.Main
{

    public class SaveLoadSystem
    {
        private static string filePath = "playerData.json";
        static MainScene mainScene = new MainScene();
        public static void SaveGame(Player player)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            string json = JsonConvert.SerializeObject(player, Formatting.Indented, settings);
            File.WriteAllText(filePath, json);
        }
        public static Player LoadGame()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };
                Player player = JsonConvert.DeserializeObject<Player>(json, settings);
                return player;
            }
            else
            {
                Console.WriteLine("불러올 파일이 없습니다.");
                Thread.Sleep(1500);
                return null;
                mainScene.CreatePlayer();
            }
        }
    }
}
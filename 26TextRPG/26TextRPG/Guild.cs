using _26TextRPG.Main;

namespace _26TextRPG
{
    public class Guild
    {
        public List<Quest> QuestList = new List<Quest>();
        MainScene mainScene = new MainScene();
        public Guild()
        {
            // 예시 퀘스트 추가
            QuestList.Add(new Quest("고블린 죽이기", "오크를 5마리 처치하시오.", "오크", 5, 1000, 100, ItemRepository.GetRandomWeapon()));
        }

        public void DisplayQuests()
        {
            Console.WriteLine("길드에서 수주할 수 있는 의뢰:");
            Console.WriteLine("--------------------------------------------------------------------");
            for (int i = 0; i < QuestList.Count; i++)
            {
                var item = QuestList[i];

                if (item == null)
                {
                    Console.WriteLine($"디버그: QuestList[{i}]가 null입니다.");
                    continue;
                }
                switch (QuestList[i].IsCommissioned)
                {
                    case true:
                        if (!QuestList[i].IsCompleted)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"{i + 1}.  {QuestList[i].Name} : {QuestList[i].Description} - 수주됨");
                            Console.ResetColor(); 
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"{i + 1}.  {QuestList[i].Name} : {QuestList[i].Description} - 완료");
                            Console.ResetColor();
                        }
                        break;
                    case false:
                        Console.WriteLine($"{i + 1}.  {QuestList[i].Name} : {QuestList[i].Description} ");
                        break;
                }
            }
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
            //foreach (var quest in availableQuests)
            //{
            //    Console.WriteLine($"- {quest.Name}: {quest.Description}");
            //}
        }
        public void ObtainQuests()
        {
            Player playerData = Player.Instance;
            Console.Clear();
            mainScene.TypingEffect("길드에 입장했습니다!", 40);
            bool InShop = true;
            while (InShop)
            {

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------");
                DisplayQuests();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("나가기 : P ");
                mainScene.TypingEffect("수주할 의뢰의 번호를 입력하세요. (취소하려면 0 입력):", 40);
                Console.WriteLine(); Thread.Sleep(100);
                string input = Console.ReadLine();
                if (input == "p" || input == "P")
                {
                    InShop = false;
                    mainScene.TypingEffect("길드에서 나갔습니다.", 40);
                    Console.WriteLine(); Thread.Sleep(100);
                }
                else if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        mainScene.TypingEffect("수주를 취소했습니다.", 40);
                        Console.WriteLine(); Thread.Sleep(100);
                        return;
                    }

                    if (choice > 0 && choice <= QuestList.Count)
                    {
                        Quest selectedQuest = QuestList[choice - 1];
                        playerData.Quest.Add(selectedQuest);
                        selectedQuest.IsCommissioned = true; 
                        mainScene.TypingEffect($"{selectedQuest.Name}을(를) 수주하여 퀘스트에 추가했습니다.", 40);
                        Console.WriteLine();
                        Thread.Sleep(100);
                    }
                    else
                    {
                        mainScene.TypingEffect("잘못된 선택입니다.", 40);
                        Console.WriteLine(); Thread.Sleep(100);
                    }
                }
                else
                {
                    mainScene.TypingEffect("숫자를 입력해주세요.", 40);
                    Console.WriteLine(); Thread.Sleep(100);
                }
                Console.Clear();
            }
        }
        public void CompleteQuest()
        {
            Player playerData = Player.Instance;
            for (int i = 0; i < playerData.Quest.Count; i++)
            {
                if (playerData.Quest[i].IsCompleted)
                {
                    Console.WriteLine($"[{playerData.Quest[i].Name}] 의뢰가 완료되었습니다.");
                }
                else
                {

                }
            }
        }
    }
}

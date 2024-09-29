namespace _26TextRPG
{
    public class Guild
    {
        private List<Quest> availableQuests = new List<Quest>();

        public Guild()
        {
            // 예시 퀘스트 추가
            availableQuests.Add(new Quest("오크 죽이기", "오크를 5마리 처치하시오.", "오크", 5, 1000, 100, null));
            
        }

        public void ShowAvailableQuests()
        {
            Console.WriteLine("길드에서 수주할 수 있는 퀘스트:");
            foreach (var quest in availableQuests)
            {
                Console.WriteLine($"- {quest.Name}: {quest.Description}");
            }
        }

        public void CompleteQuest(Player player)
        {
            Quest quest = player.Quest;

            if (quest.IsCompleted)
            {
                quest.CompleteQuest(player);
                availableQuests.Remove(quest);
                Console.WriteLine($"{quest.Name} 퀘스트가 완료되었습니다.");
            }
            else
            {
                Console.WriteLine($"{quest.Name} 퀘스트는 아직 완료되지 않았습니다.");
            }
        }
    }
}

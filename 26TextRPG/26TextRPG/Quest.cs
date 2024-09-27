namespace _26TextRPG
{
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetRace { get; }
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public bool IsCompleted => CurrentCount >= TargetCount;

        public int RewardGold { get; set; }
        public int RewardExp { get; set; }

        public _26TextRPG.Item.Item RewardItem { get; set; }



        public Quest(string name, string description, string targetRace, int targetCount, int rewardGold, int rewardExp, _26TextRPG.Item.Item rewardItem)
        {
            Name = name;
            Description = description;
            TargetRace = targetRace;
            TargetCount = targetCount;
            CurrentCount = 0;
            RewardGold = rewardGold;
            RewardExp = rewardExp;
            RewardItem = rewardItem;
        }

        public void UpdateQuest(Enemy enemy)
        {
            if (enemy.Name.Contains(TargetRace, StringComparison.OrdinalIgnoreCase))
            {
                CurrentCount++;
            }
        }


        public void DisplayQuestStatus()
        {
            Console.WriteLine($"{Name} - {Description}");
            Console.WriteLine($"목표: {CurrentCount}/{TargetCount} ({TargetRace} 처치)");
        }

        public void CompleteQuest(Player player)
        {
            if (IsCompleted)
            {
                player.Gold += RewardGold;
                player.Exp += RewardExp;

                if (RewardItem != null)
                {
                    player.Inventory.Add(RewardItem);
                }

                Console.WriteLine($"{Name} 퀘스트를 완료했습니다! 보상: {RewardGold} 골드, {RewardExp} 경험치, 아이템: {RewardItem?.Name}");
            }
            else
            {
                Console.WriteLine("퀘스트가 아직 완료되지 않았습니다.");
            }
        }
    }
}

using _26TextRPG.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Dungeon
{
    public class TrainingRoom
    {
        MainScene mainScene = new MainScene();
        public List<Skill> SkillList {  get; set; }
        public TrainingRoom()
        {
            Player playerData = Player.Instance;
            SkillList = new List<Skill>();
            if (playerData.Job == "전사")
            {
                SkillList = SkillRepository.Warrior;
            }
            else if (playerData.Job == "마법사")
            {
                SkillList = SkillRepository.Wizard;
            }
            else if (playerData.Job == "궁수")
            {
                SkillList = SkillRepository.Archer;
            }
        }
        public void DisplaySkills() // 판매 아이템 출력
        {
            Console.WriteLine("상점 아이템 목록:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < SkillList.Count; i++)
            {
                var item = SkillList[i];

                if (item == null)
                {
                    Console.WriteLine($"디버그: SkillList[{i}]가 null입니다.");
                    continue;
                }
                Console.WriteLine($"{i + 1}. {SkillList[i].Name} - {SkillList[i].Value}Gold ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void BuySkill() // 아이템 구매 메소드
        {
            MainScene mainScene = new MainScene();
            Player playerData = Player.Instance;
            Console.Clear();
            mainScene.TypingEffect("훈련장에 입장했습니다!", 40);
            bool InShop = true;
            while (InShop)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine($"현재 골드: {playerData.Gold}골드");
                DisplaySkills();
                Console.WriteLine("구매하기 : D");
                Console.WriteLine("나가기 : ESC ");
                Console.WriteLine(); Thread.Sleep(100);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        InShop = false;
                        mainScene.TypingEffect("훈련장에서 나갔습니다.", 40);
                        Console.WriteLine(); Thread.Sleep(100);
                        break;
                    case ConsoleKey.D:
                        mainScene.TypingEffect("습득할 스킬의 번호를 입력하세요 (취소하려면 0 입력):", 40);
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 0)
                        {
                            mainScene.TypingEffect("구매를 취소했습니다.", 40);
                            Console.WriteLine(); Thread.Sleep(100);
                        }
                        else if (choice > 0 && choice <= SkillList.Count)
                        {
                            Skill selectedSkill = SkillList[choice - 1];

                            if (playerData.Gold >= selectedSkill.Value)
                            {
                                playerData.Gold -= selectedSkill.Value;
                                playerData.SkillList.Add(selectedSkill);
                                SkillList.RemoveAt(choice - 1);
                                mainScene.TypingEffect($"{selectedSkill.Name}을(를) 습득하여 스킬 리스트에 추가했습니다.", 40);
                                Console.WriteLine();
                                mainScene.TypingEffect($"남은 골드: {playerData.Gold}골드", 40); Console.WriteLine(); Thread.Sleep(100);
                            }
                            else
                            {
                                mainScene.TypingEffect("골드가 부족하여 스킬을 습득할 수 없습니다.", 40);
                                Console.WriteLine(); Thread.Sleep(100);
                            }
                        }
                        else
                        {
                            mainScene.TypingEffect("잘못된 선택입니다.", 40);
                            Console.WriteLine(); Thread.Sleep(100);
                        }
                        break;
                } 
            }
        }
    }
}

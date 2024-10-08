using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _26TextRPG;
using _26TextRPG.Main;

namespace _26TextRPG.Dungeon
{
    public class Stage
    {
        Player currentPlayer = Player.Instance; // 플레이어 싱글톤에 접근
        //public 변수 
        public int StageFloor { get; set; }
        public int Progress { get; set; }
        public int MaxProgress { get; set; }
        public bool StairFound { get; set; }
        public bool ShopFound { get; set; }
        public bool IsCompleted { get; set; }

        //private 변수
        private Random Random;
        private int StairPosition;

        
        MainScene mainScene = new MainScene();
        public Stage(int stagefloor) //생성자 Stage
        {
            StageFloor = stagefloor;
            Progress = 0;
            MaxProgress = 90 + (stagefloor * 10);
            StairFound = false;
            ShopFound = false;
            IsCompleted = false;

            Random = new Random();

           
        }
        public void Explore() 
        {
            if (StageFloor == 5)
            {
                if (Progress == 0)
                {
                    mainScene.TypingEffect("당신은 던전에 입장했습니다...", 50);
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"[ 던전 {StageFloor}층 ]");
                Console.WriteLine();
                Console.WriteLine();
                Progress = MaxProgress;
                FindStair();
                Console.Clear();
                BossEncounter5();
            }
            else if (StageFloor == 10)
            {
                Console.Clear();
                if (Progress == 0)
                {
                    mainScene.TypingEffect("당신은 던전에 입장했습니다...", 50);
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"[ 던전 {StageFloor}층 ]");
                Console.WriteLine();
                Console.WriteLine();
                Progress = MaxProgress;
                FindStair();
                BossEncounter10();
            }
            else 
            {
                Console.Clear();
                if (Progress == 0)
                {
                    mainScene.TypingEffect("당신은 던전에 입장했습니다...", 50);
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"[ 던전 {StageFloor}층 ]");
                Console.WriteLine($"진행도 : {Progress}/{MaxProgress}");
                Console.WriteLine(); // 진행도 출력
                Console.WriteLine();
                if (!IsCompleted)
                {
                    Progress += 10;
                    if (Progress > MaxProgress) { Progress = MaxProgress; }
                    int Randomtext = Random.Next(1, 4);
                    switch (Randomtext)
                    {
                        case 1:
                            mainScene.TypingEffect("당신은 어두운 방과 던전 사이를 걷습니다.", 50);
                            break;
                        case 2:
                            mainScene.TypingEffect("당신의 길은 어둠과 미지로 가득차있습니다.", 50);
                            break;
                        case 3:
                            mainScene.TypingEffect($"{currentPlayer.Name} : 온통 어둠과 먼지 뿐이군.", 50); // 플레이어 이름 값 삽입
                            break;
                    }
                    // ... 삽입 딜레이 연출
                    Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine(".");
                    Console.WriteLine();
                    FindStair();
                    TriggerEvent();
                    Thread.Sleep(200);
                }
                else
                {
                    mainScene.TypingEffect("더 탐험할게 없습니다.", 50);
                    Console.WriteLine();
                    return;
                }

                if (Progress >= MaxProgress)
                {
                    if (!StairFound)
                    {
                        FindStair();
                    }
                    else
                    {
                        mainScene.TypingEffect($"{StageFloor}층 탐험이 완료되었습니다!", 50);
                        IsCompleted = true;
                        Console.WriteLine();
                    }
                }
            }
            
            
        }
        public void FindStair() 
        {
            StairPosition = Random.Next(20, MaxProgress); // 계단의 위치 = 진행도 최소 20부터 등장
            if (Progress >= StairPosition && !StairFound)
            {
                StairFound = true; // '다음 스테이지로 진행' 선택지 활성화에 사용
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                mainScene.TypingEffect("계단을 발견했습니다! 다음 스테이지로 이동 가능합니다.", 50);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
            } 
            else
            {
                return;
            }
        }
        public void TriggerEvent() 
        {
            int eventChance = Random.Next(1, 101);

            if (eventChance <= 40)
            {
                EncounterEnemy();//적 조우 메소드 - 50퍼센트
            }
            else if (eventChance <= 50)
            {
                Trap();
            }
            else if (eventChance <= 70)
            {
                FindShop();//상점 발견 메소드 - 30퍼센트
            }
            else if (eventChance <= 90)
            {
                FindItem();//아이템 발견 메소드 - 10퍼센트
            }
            else
            {
                // 아무일도 없음 - 랜덤 택스트 출력
                int Randomtext = Random.Next(1, 4);
                switch (Randomtext)
                {
                    case 1:
                        mainScene.TypingEffect("조심스런 발소리만이 복도에 이어질 뿐입니다...", 50);
                        Console.WriteLine(); Console.WriteLine();
                        break;
                    case 2:
                        mainScene.TypingEffect("아무일도 일어나지 않았습니다...", 50);
                        Console.WriteLine(); Console.WriteLine();
                        break;
                    case 3:
                        mainScene.TypingEffect($"{currentPlayer.Name} : 아무것도 없군...", 50);
                        Console.WriteLine(); Console.WriteLine();
                        break;
                }
            }

        }
        public void EncounterEnemy() 
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            mainScene.TypingEffect("어둠속에서 무언가가 움직입니다....!!" , 50);
            Thread.Sleep(800);
            Console.WriteLine();
            Console.WriteLine();
            int Randomtext = Random.Next(1, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            switch (Randomtext)
            {
                case 1:
                    mainScene.TypingEffect("역시 적입니다! 전투 준비!", 50);
                    Console.WriteLine();
                    break;
                case 2:
                    mainScene.TypingEffect("적을 만났습니다! 전투에 들어갑니다!", 50);
                    Console.WriteLine();
                    break;
                case 3:
                    mainScene.TypingEffect($"{currentPlayer.Name} : 덤벼라!! 너같은 애송이가 내 길을 막게 두지 않겠다!", 50);
                    Console.WriteLine();
                    break;
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("계속_(아무키나 입력해 진행)");
            Console.ReadLine();

            Battle battle = new (currentPlayer);
            battle.Start(StageFloor); // 전투 돌입 메소드 호출

        }

        public void FindShop()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            mainScene.TypingEffect("상점을 발견했습니다!", 50); Console.WriteLine(); Console.WriteLine();
            Thread.Sleep(500);
            int encountertext = Random.Next(1, 3);
            Console.ResetColor();
            switch (encountertext)
            {
                case 1:
                    mainScene.TypingEffect("이런곳에 상점이라니 기이하군요.", 50); 
                    Console.WriteLine();
                    break;
                case 2:
                    mainScene.TypingEffect("이곳에서 물건을 사거나 휴식할수 있습니다.", 50); 
                    Console.WriteLine();
                    break;
                case 3:
                    mainScene.TypingEffect($"{currentPlayer.Name} : 이런곳에 상점이라니?", 50); 
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine();
            ShopFound = true; // '상점' 선택지 활성화에 사용
        }

        private void FindItem()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            mainScene.TypingEffect("무언가 반짝이는게 보입니다!", 50); 
            Console.WriteLine(); Console.WriteLine();
            Thread.Sleep(500);
            int eventChance = Random.Next(1, 101);
            if (eventChance <= 50)
            {
                int RandomGold = Random.Next(5 + (StageFloor * 2), 500 + (StageFloor * 5));
                mainScene.TypingEffect("금화를 발견했습니다!", 50); 
                Console.WriteLine();
                currentPlayer.Gold += RandomGold;
            }
            else if (eventChance <= 70)
            {
                mainScene.TypingEffect("포션을 발견했습니다!", 50); 
                Console.WriteLine();
                currentPlayer.Inventory.Add(ItemRepository.GetRandomPotion()); // 인벤토리에 포션 추가
            }
            else
            {
                int num = Random.Next(1, 100);
                if (num <= 50)
                {
                    mainScene.TypingEffect("방어구를 발견했습니다!", 50); 
                    Console.WriteLine();
                    currentPlayer.Inventory.Add(ItemRepository.GetRandomArmor());  // 인벤토리에 방어구 추가
                }
                else
                {
                    mainScene.TypingEffect("무기를 발견했습니다!", 50); 
                    Console.WriteLine();
                    currentPlayer.Inventory.Add(ItemRepository.GetRandomWeapon()); 
                }
            }
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(500);
            int encountertext = Random.Next(1, 3);
            switch (encountertext)
            {
                case 1:
                    mainScene.TypingEffect("횡재로군요.", 50); Console.WriteLine();
                    break;
                case 2:
                    mainScene.TypingEffect("앞으로의 여정에 도움이 될겁니다.", 50); Console.WriteLine();
                    break;
                case 3:
                    mainScene.TypingEffect($"{currentPlayer.Name} : 횡재로군.", 50); Console.WriteLine();
                    break;
            }
            Console.WriteLine();
        }

        private void Trap()
        {
            int eventChance = Random.Next(1, 101);
            if (eventChance >= 80)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                int Randomtext = Random.Next(1, 3);
                switch (Randomtext)
                {
                    case 1:
                        mainScene.TypingEffect("함정입니다!! 피하세요!!", 50);
                        Console.WriteLine();
                        break;
                    case 2:
                        mainScene.TypingEffect("함정을 밟았습니다!! 조치를 취하셔야 합니다!!", 50);
                        Console.WriteLine();
                        break;
                    case 3:
                        mainScene.TypingEffect($"{currentPlayer.Name} : 함정이였군!!", 50);
                        Console.WriteLine();
                        break;
                }
                Console.ResetColor();
                Console.WriteLine();
                int EvasionRoll = Dice.Roll(1, 20);
                int Evasion = EvasionRoll + currentPlayer.Speed;
                int TrapDamage = Dice.Roll(StageFloor, 4);
                if (Evasion > 15)
                {
                    mainScene.TypingEffect("함정을 성공적으로 피했습니다!", 50);
                    Console.WriteLine();
                }
                else
                {
                    mainScene.TypingEffect("함정에 당하고 말았습니다!", 50);
                    Console.WriteLine();
                    currentPlayer.Health -= TrapDamage;
                    mainScene.TypingEffect($"{TrapDamage}만큼의 피해를 받았습니다!", 50);
                    Console.WriteLine();
                }
                Console.WriteLine();
                if (EvasionRoll == 20)
                {
                    mainScene.TypingEffect("함정의 잔해에..", 50);
                    FindItem();
                }
                else if (EvasionRoll == 1)
                {
                    mainScene.TypingEffect("함정에서 빠져나오려다 상처가 더 생겼습니다!!", 50);
                    Console.WriteLine();
                    currentPlayer.Health -= TrapDamage;
                }
                Console.WriteLine();
            }

        }
        private void BossEncounter5()
        {
            mainScene.TypingEffect("당신은 어두운 던전 복도를 걷습니다.", 50);
            Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine(".");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            mainScene.TypingEffect("저 멀리서 불길한 불빛과 북소리, 그리고 환호하는 괴물의 목소리가 들립니다.", 50);
            Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine(".");
            Console.WriteLine();
            mainScene.TypingEffect(" [???] : 잊혀진 제물이 제 발로 걸어들어오는구나!! 가까이 오거라!!", 50);
            Console.WriteLine();
            Console.ResetColor();
            mainScene.TypingEffect("힘든 싸움이 될것 같습니다....", 50);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("계속_(아무키나 입력해 진행)");
            Console.ReadLine();
            Battle battle = new(currentPlayer);
            battle.Start(StageFloor);
        }
        private void BossEncounter10()
        {
            mainScene.TypingEffect("당신은 어두운 던전 복도를 걷습니다.", 50);
            Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine(".");
            Console.WriteLine(); Console.WriteLine();
            mainScene.TypingEffect("이곳이 마지막입니다. 이 길 앞에 기다리는게 무엇이든, 당신은 준비가 되었습니다.", 50);
            Thread.Sleep(1000); Console.WriteLine(); 
            mainScene.TypingEffect("당신은 무거운 석문 앞에 서서 문을 힘차게 열어봅니다.", 50);
            Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine(".");
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            mainScene.TypingEffect("[???] : 아이야, 내 품을 떠나 자리를 잡은줄 알았건만, 기여코 이곳에 돌아왔구나.", 50);
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.WriteLine(); Console.WriteLine();
            mainScene.TypingEffect("당신은 이자에게 알수없는 분노가 생긴다는것 말곤 기억나는게 없지만, 이자는 당신을 아는것같습니다.", 50);
            Thread.Sleep(500); Console.WriteLine(); Console.WriteLine();
            mainScene.TypingEffect("분명 당신의 잃어버린 기억에 대해 알고있는게 분명합니다.", 50);
            Thread.Sleep(1000); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            mainScene.TypingEffect("[???] : 오거라, 너의 여정도 이제는 끝이다.", 50);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("계속_(아무키나 입력해 진행)");
            Console.ReadLine();
            Battle battle = new(currentPlayer);
            battle.Start(StageFloor);
        }
    }
}

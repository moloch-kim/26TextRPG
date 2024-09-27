﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _26TextRPG.Main;

namespace _26TextRPG.Dungeon
{
    public class Stage
    {
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

            StairPosition = Random.Next(20, MaxProgress); // 계단의 위치 = 진행도 최소 20부터 등장
            Console.Clear(); // 해당 층 최초 입장시 콘솔 초기화
            mainScene.TypingEffect("당신은 던전에 입장했습니다...", 50);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            mainScene.TypingEffect($"[ 던전 {StageFloor}층 ]", 50);
            Console.WriteLine();
        }
        public void Explore() 
        {
            Console.Clear();
            if (!IsCompleted)
            {
                Progress += 10;
                int randomtext = Random.Next(1, 4);
                switch (randomtext)
                {
                    case 1:
                        Console.Write("당신은 어두운 방과 던전 사이를 걷습니다.");
                        break;
                    case 2:
                        Console.Write("당신의 길은 어둠과 미지로 가득차있습니다.");
                        break;
                    case 3:
                        Console.Write(" 당신 : 온통 어둠과 먼지 뿐이군."); // 플레이어 이름 값 삽입
                        break;
                }
                // ... 삽입 딜레이 연출
                Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.Write("."); Thread.Sleep(500); Console.WriteLine("."); 
            }
            else
            {
                Console.WriteLine("더 탐험할게 없습니다.");
                return;
            }

            Console.WriteLine($"진행도 : {Progress}/{MaxProgress}"); // 진행도 출력
            Thread.Sleep(200);

            if(Progress >= MaxProgress) 
            {
                if (!StairFound)
                {
                    Console.WriteLine("무언가 잘못되었습니다. 스테이지를 다시 시작합니다.");
                    //리스타트
                }
                else
                {
                    Console.WriteLine($"{StageFloor}층 탐험이 완료되었습니다!");
                }
            }
            
        }
        public void FindStair() 
        {
            if (Progress >= StairPosition && !StairFound)
            {
                StairFound = true; // '다음 스테이지로 진행' 선택지 활성화에 사용
                Console.WriteLine("계단을 발견했습니다! 다음 스테이지로 이동 가능합니다.");
            }
            else
            {
                return;
            }
        }
        public void TriggerEvent(Character player) 
        {
            int eventChance = Random.Next(1, 101);

            if (eventChance <= 50)
            {
                EncounterEnemy(player);//적 조우 메소드 - 50퍼센트
            }
            else if (eventChance <= 70)
            {
                //상점 발견 메소드 - 30퍼센트
            }
            else if (eventChance <= 90)
            {
                //아이템 발견 메소드 - 10퍼센트
            }
            else
            {
                // 아무일도 없음 - 랜덤 택스트 출력
                int randomtext = Random.Next(1, 3);
                switch (randomtext)
                {
                    case 1:
                        Console.WriteLine("조심스런 발소리만이 복도에 이어질 뿐입니다...");
                        break;
                    case 2:
                        Console.WriteLine("아무일도 일어나지 않았습니다...");
                        break;
                    case 3:
                        Console.WriteLine(" 당신 : 아무것도 없군...");
                        break;
                }
            }

        }
        public void EncounterEnemy(Character player) 
        {
            Console.WriteLine("어둠속에서 무언가가 움직입니다....!!");
            Thread.Sleep(800);
            Console.WriteLine();
            int randomtext = Random.Next(1, 3);
            switch (randomtext)
            {
                case 1:
                    Console.WriteLine("역시 적입니다! 전투 준비!");
                    break;
                case 2:
                    Console.WriteLine("적을 만났습니다! 전투에 들어갑니다!");
                    break;
                case 3:
                    Console.WriteLine("당신 : 덤벼라!! 너같은 애송이가 내 길을 막게 두지 않겠다!");
                    break;
            }
            Thread.Sleep(800);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("계속_(아무키나 입력해 진행)");
            Console.ReadLine();

            Battle battle = new (player);
            battle.Start(StageFloor);

            // 전투 돌입 메소드 호출

        }

        public void FindShop()
        {
            Console.WriteLine("상점을 발견했습니다!");
            Thread.Sleep(500);
            int encountertext = Random.Next(1, 3);

            switch (encountertext)
            {
                case 1:
                    Console.WriteLine("이런곳에 상점이라니 기이하군요.");
                    break;
                case 2:
                    Console.WriteLine("이곳에서 물건을 사거나 휴식할수 있습니다.");
                    break;
                case 3:
                    Console.WriteLine("당신 : 이런곳에 상점이라니?");
                    break;
            }
            ShopFound = true; // '상점' 선택지 활성화에 사용
        }

    }
}

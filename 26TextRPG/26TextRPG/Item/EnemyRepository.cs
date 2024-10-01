using _26TextRPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    public class EnemyRepository
    {
        public static List<Enemy> floor1List {  get; private set; }
        public static List<Enemy> floor2List { get; private set; }
        public static List<Enemy> floor3List { get; private set; }
        public static List<Enemy> floor4List { get; private set; }
        public static List<Enemy> floor5List { get; private set; }
        public static List<Enemy> floor6List { get; private set; }
        public static List<Enemy> floor7List { get; private set; }
        public static List<Enemy> floor8List { get; private set; }
        public static List<Enemy> floor9List { get; private set; }
        public static List<Enemy> floor10List { get; private set; }
        public static List<Enemy>[] EnemyList { get; private set; } = { floor1List, floor2List, floor3List, floor4List, floor5List, floor6List, floor7List, floor8List, floor9List, floor10List };

        // 정렬 기준은 솔루션 탐색기
        static EnemyRepository()
        {
            //public Enemy(string name, int id, int health, int attackPower, int defensePower, int speed, int experienceReward, int goldReward)
            floor1List = new List<Enemy>()
            {
                new Enemy("들개", 1, 30, 5, 3, 8, 7, 0),
                new Enemy("시궁쥐", 2, 10, 3, 3, 12, 3, 0),
                new Enemy("뿔토끼", 3, 20, 7, 3, 15, 6, 0),
                new Enemy("거미", 4, 25, 6, 3, 10, 8, 0),
                new Enemy("검은 들개", 5, 35, 6, 4, 9, 10, 5),
                new Enemy("독거미", 8, 22, 5, 3, 10, 7, 0),
                new Enemy("쥐", 9, 12, 2, 1, 13, 4, 0),
                new Enemy("검은 뿔토끼", 10, 18, 7, 3, 15, 6, 0),
            };
            floor2List = new List<Enemy>() 
            {
                new Enemy("검은 들개", 5, 35, 6, 4, 9, 10, 5),
                new Enemy("검은 뿔토끼", 10, 18, 7, 3, 15, 6, 0),
                new Enemy("독거미", 8, 22, 5, 3, 10, 7, 0),
                new Enemy("늑대", 7, 40, 8, 4, 11, 9, 1),
                new Enemy("다이어울프", 7, 60, 11, 6, 11, 15, 20),
                new Enemy("흉악한 거미", 73, 80, 18, 10, 5, 40, 20),
                new Enemy("고블린", 23, 30, 7, 3, 10, 10, 5),
            };
            floor3List = new List<Enemy>() 
            {
                new Enemy("고블린", 23, 30, 7, 3, 10, 10, 5),
                new Enemy("혈거미", 15, 30, 6, 3, 9, 8, 3),
                new Enemy("오크", 11, 50, 10, 5, 7, 15, 10),
                new Enemy("홉고블린", 12, 45, 9, 4, 6, 12, 8),
                new Enemy("좀비", 21, 55, 11, 6, 7, 16, 10),
                new Enemy("스켈레톤", 22, 40, 9, 5, 8, 12, 8),
                new Enemy("고블린 전사", 23, 30, 7, 3, 10, 10, 5),
            };
            floor4List = new List<Enemy>()
            {
                new Enemy("고블린 전사", 23, 30, 7, 3, 10, 10, 5),
                new Enemy("오크 전사", 11, 50, 10, 5, 7, 15, 10),
                new Enemy("오크 주술사", 12, 45, 9, 4, 6, 12, 8),
                new Enemy("스켈레톤 전사", 22, 40, 9, 5, 8, 12, 8),
                new Enemy("구울", 21, 55, 11, 6, 12, 16, 10),
                new Enemy("트롤", 21, 80, 20, 15, 4, 16, 10),
            };
            floor5List = new List<Enemy>()
            {
                new Enemy("오크 제사장", 63, 75, 15, 9, 6, 28, 18),
                new Enemy("오크 전사", 11, 50, 10, 5, 7, 15, 10),
                new Enemy("오크 전사", 11, 50, 10, 5, 7, 15, 10),
                new Enemy("오크 전사", 11, 50, 10, 5, 7, 15, 10),
            };
            floor6List = new List<Enemy>()
            {
                new Enemy("구울", 21, 55, 11, 6, 12, 16, 10),
                new Enemy("스켈레톤 전사", 22, 40, 9, 5, 8, 12, 8),
                new Enemy("트롤", 21, 80, 20, 15, 4, 16, 10),
                new Enemy("얼음 정령", 65, 60, 12, 6, 9, 20, 15),
                new Enemy("불의 정령", 66, 65, 13, 7, 8, 22, 18),
                new Enemy("악령", 69, 40, 8, 3, 14, 14, 8),
                new Enemy("타락한 전사", 71, 100, 22, 13, 6, 45, 25),
            };
            floor7List = new List<Enemy>()
            {
                new Enemy("악령", 69, 40, 8, 3, 14, 14, 8),
                new Enemy("타락한 전사", 71, 100, 22, 13, 6, 45, 25),
                new Enemy("오크 대전사", 61, 80, 18, 10, 8, 35, 20),
            };
            floor8List = new List<Enemy>()
            {
                new Enemy("오크 대전사", 61, 80, 18, 10, 8, 35, 20),
                new Enemy("사악한 마법사", 73, 65, 10, 8, 8, 20, 15),
                new Enemy("저주받은 전사", 74, 90, 16, 9, 6, 28, 18),
                new Enemy("흡혈귀", 72, 85, 18, 10, 7, 25, 20),
            };
            floor9List = new List<Enemy>()
            {
                new Enemy("흡혈귀", 72, 85, 18, 10, 7, 25, 20),
                new Enemy("어둠의 사제", 62, 70, 12, 7, 6, 20, 15),
                new Enemy("죽음의 기사", 63, 90, 15, 10, 5, 25, 20),
                new Enemy("흡혈귀군주", 72, 100, 25, 15, 10, 35, 30),
            };
            floor10List = new List<Enemy>()
            {
                new Enemy("마왕", 91, 200, 50, 30, 3, 150, 100),
            };

            EnemyList = new List<Enemy>[] 
            {
                floor1List, floor2List, floor3List, floor4List, floor5List, floor6List, floor7List, floor8List, floor9List, floor10List
            };

        }

        public static List<Enemy> GetEnemyListByFloor(int floor)
        {
            return EnemyList[floor - 1];
        }

        

    }
}

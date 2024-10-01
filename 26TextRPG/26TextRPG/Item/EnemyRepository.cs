using _26TextRPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Random random = new Random();
            //public Enemy(string name, int id, int health, int attackPower, int defensePower, int speed, int experienceReward, int goldReward)
            floor1List = new List<Enemy>()
            {
                new Enemy("들개", 1, 30, 5, 3, 8, 7, 0),
                new Enemy("시궁쥐", 1, 10, 3, 3, 12, 3, 0),
                new Enemy("뿔토끼", 1, 20, 7, 3,15, 6, 0),
            };
            floor2List = new List<Enemy>() 
            {
                new Enemy("들개2", 1, 30, 5, 3, 8, 7, 0),
            };
            floor3List = new List<Enemy>() 
            {
                new Enemy("들개3", 1, 30, 5,3,  8, 7, 0),
            };
            floor4List = new List<Enemy>()
            {
                new Enemy("들개4", 1, 30, 5,3,  8, 7, 0),
            };
            floor5List = new List<Enemy>()
            {
                new Enemy("들개5", 1, 30, 5, 3, 8, 7, 0),
            };
            floor6List = new List<Enemy>()
            {
                new Enemy("들개6", 1, 30, 5, 3, 8, 7, 0),
            };
            floor7List = new List<Enemy>()
            {
                new Enemy("들개7", 1, 30, 5, 3, 8, 7, 0),
            };
            floor8List = new List<Enemy>()
            {
                new Enemy("들개8", 1, 30, 5, 3, 8, 7, 0),
            };
            floor9List = new List<Enemy>()
            {
                new Enemy("들개9", 1, 30, 5, 3, 8, 7, 0),
            };
            floor10List = new List<Enemy>()
            {
                new Enemy("들개10", 1, 30, 5, 3, 8, 7, 0),
            };

        }

        public static List<Enemy> GetEnemyListByFloor(int floor)
        {
            return EnemyList[floor - 1];
        }


    }
}

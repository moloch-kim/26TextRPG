using _26TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    internal class QuestRepository
    {
        public static List<Quest> QuestList { get; private set; }

        // 정렬 기준은 솔루션 탐색기
        static QuestRepository()
        {
            //public Quest(string name, string description, string targetRace, int targetCount, int rewardGold, int rewardExp, Item rewardItem)
            QuestList = new List<Quest>() // 퀘스트 리스트
            {
                new Quest("고블린 죽이기1", "닭을 훔쳐가는 고블린들을 죽여주세요", "고블린", 5, 150, 50, null),
                new Quest("고블린 죽이기2", "닭을 훔쳐가는 고블린들을 죽여주세요", "고블린", 10, 300, 100, null),
                new Quest("고블린 죽이기3", "닭을 훔쳐가는 고블린들을 죽여주세요", "고블린", 20, 500, 200, null),
                new Quest("오크 죽이기1", "돼지을 훔쳐가는 오크들을 죽여주세요", "오크", 5, 250, 100, null),
                new Quest("오크 죽이기2", "돼지을 훔쳐가는 오크들을 죽여주세요", "오크", 10, 500, 200, null),
                new Quest("오크 죽이기3", "돼지을 훔쳐가는 오크들을 죽여주세요", "오크", 20, 1000, 400, null),
                new Quest("트롤 죽이기1", "말을 훔쳐가는 트롤들을 죽여주세요", "트롤", 5, 500, 50, null),
                new Quest("트롤 죽이기2", "말을 훔쳐가는 트롤들을 죽여주세요", "트롤", 10, 1000, 100, null),
                new Quest("트롤 죽이기3", "말을 훔쳐가는 트롤들을 죽여주세요", "트롤", 20, 2000, 200, null),
				//퀘스트 추가
			};
        }

        public static Quest GetQuestByName(string name)
        {
            return QuestList.FirstOrDefault(Quest => Quest.Name == name);
        }
    }
}
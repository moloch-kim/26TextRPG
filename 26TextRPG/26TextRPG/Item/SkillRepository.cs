using _26TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    internal class SkillRepository
    {
        public static List<Skill> Warrior { get; private set; }
        public static List<Skill> Archer { get; private set; }
        public static List<Skill> Wizard { get; private set; }
        private static List<Skill> AllSkills;

        // 정렬 기준은 솔루션 탐색기
        static SkillRepository()
        {
            //Skill(string name, int manaCost,int reference, float multiplier, bool isArea)
            //Reference 1:공격력, 2:방어력, 3:최대체력, 4:최대마나 5:속도
            Warrior = new List<Skill>() // 전사 스킬 리스트
            {
                new Skill("배쉬", 3, 2, 1.5f, false, 250),
                new Skill("슬래쉬", 5, 1, 2.0f, false, 500),
                new Skill("존 어택", 5, 1, 1f, true, 500),
                new Skill("방패 밀치기", 4, 2, 1.5f, false, 1000),
                new Skill("원드밀", 8, 1, 1.5f, true, 2000),
                new Skill("파이널 히트", 10, 3, 1.5f, false, 4000),
                new Skill("글로리 킬", 30, 1, 15f , false, 6000)
				//스킬 추가
			};
            Archer = new List<Skill>() // 궁수 스킬 리스트
            {
                new Skill("해드샷", 3, 5, 1.5f, false, 250),
                new Skill("도탄 사격",5, 1, 0.8f, true, 500),
                new Skill("연속 사격", 5, 5, 2.0f, false, 500),
                new Skill("다중 화살", 10, 5, 1f, true, 1000),
                new Skill("신속 발사", 3, 5, 2.5f, true, 2000),
                new Skill("파이널 샷", 15, 1, 10f, false, 4000), 
                //스킬 추가
            };
            Wizard = new List<Skill>()  // 마법사 스킬 리스트
            {
                new Skill("매직 미사일", 4, 4, 0.5f, false, 250),
                new Skill("신비한 폭발", 5, 4, 0.5f, true, 500),
                new Skill("매직 에로우", 6, 4, 0.8f, false, 500),
                new Skill("매직 스피어", 3, 4, 1.1f, false, 1000),
                new Skill("체인 라이트닝", 7, 4, 1.6f, true, 2000),
                new Skill("파이어 스톰", 10, 4, 2.0f, true, 4000), 
                new Skill("아마게돈", 50, 4, 5f, true, 8000)
                //스킬 추가
            };
            AllSkills = new List<Skill>();
            AllSkills.AddRange(Warrior);
            AllSkills.AddRange(Archer);
            AllSkills.AddRange(Wizard);
        }

        public static Skill GetSkillByName(string name)
        {
            return AllSkills.FirstOrDefault(skill => skill.Name == name);
        }
    }
}
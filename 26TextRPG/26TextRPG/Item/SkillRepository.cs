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
				new("배쉬",3,1,1.5,false),
				//스킬 추가
			};
			Archer = new List<Skill>() // 궁수 스킬 리스트
            {
				new("해드샷",3,1,1.5,false),
                //스킬 추가
            };
			Wizard = new List<Skill>()  // 마법사 스킬 리스트
            {
				new("매직미사일",3,1,1.5,false),
                //스킬 추가
            };
			AllSkills = new List<Skill>();
			AllSkills.AddRange(Warrior);
			AllSkills.AddRange(Archer);
			AllSkills.AddRange(Wizard);
		}

		public static Item GetSkillByName(string name)
		{
			return AllSkills.FirstOrDefault(skill => skill.Name == name);
		}
	}
}
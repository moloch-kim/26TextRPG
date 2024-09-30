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

		// ���� ������ �ַ�� Ž����
		static SkillRepository()
		{
			//Skill(string name, int manaCost,int reference, float multiplier, bool isArea)
			//Reference 1:���ݷ�, 2:����, 3:�ִ�ü��, 4:�ִ븶�� 5:�ӵ�
			Warrior = new List<Skill>() // ���� ��ų ����Ʈ
            {
				new("�转",3,1,1.5,false),
				//��ų �߰�
			};
			Archer = new List<Skill>() // �ü� ��ų ����Ʈ
            {
				new("�ص弦",3,1,1.5,false),
                //��ų �߰�
            };
			Wizard = new List<Skill>()  // ������ ��ų ����Ʈ
            {
				new("�����̻���",3,1,1.5,false),
                //��ų �߰�
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
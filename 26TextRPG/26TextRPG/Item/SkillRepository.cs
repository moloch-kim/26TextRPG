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
				new Skill("�转", 3, 1, 1.5f, false, 250),
				new Skill("������", 5, 1, 2.0f, false, 500),
				new Skill("���� ��ġ��", 4, 2, 1.5f, false, 1000),
				new Skill("�����", 8, 1, 1.5f, true, 2000),
				new Skill("���̳� ��Ʈ", 10, 3, 1.5f, false, 4000),
				//��ų �߰�
			};
			Archer = new List<Skill>() // �ü� ��ų ����Ʈ
            {
				new Skill("�ص弦", 3, 1, 1.5f, false, 250),
				new Skill("���� ���", 5, 1, 2.0f, false, 500), 
				new Skill("���� ȭ��", 5, 1, 1.3f, true, 1000), 
				new Skill("�ż� �߻�", 3, 5, 2.5f, true, 2000), 
				new Skill("���̳� ��", 10, 1, 3.0f, false, 4000), 
                //��ų �߰�
            };
			Wizard = new List<Skill>()  // ������ ��ų ����Ʈ
            {
				new Skill("���� �̻���", 4, 5, 0.5f, false, 250), 
				new Skill("���� ���ο�", 6, 5, 0.8f, false, 500), 
				new Skill("���� ���Ǿ�", 3, 5, 1.1f, false, 1000), 
				new Skill("ü�� ����Ʈ��", 7, 5, 1.6f, true, 2000),
				new Skill("���̾� ����", 10, 5, 2.0f, true, 4000), 
                //��ų �߰�
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
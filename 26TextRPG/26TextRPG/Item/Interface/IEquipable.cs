using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item.Interface
{
    internal interface IEquipable
    {
        void Equip(Player player); // 장착 기능 함수

        void UnEquip(Player player); // 장착 해제 기능 함수
    }
}

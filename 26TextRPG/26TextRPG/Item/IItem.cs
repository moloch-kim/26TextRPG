using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG
{
    public interface Item
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        int Value { get; }

        public void UseItem()
        {

        }
    }

}

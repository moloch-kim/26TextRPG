using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26TextRPG.Item.Interface
{
    internal interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        int Value { get; }

    }

    

}

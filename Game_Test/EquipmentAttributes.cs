using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test
{
    public class EquipmentAttributes
    {
        public string Name { get; }
        public int DamageOrDefense { get; }

        public EquipmentAttributes(string name, int damageOrDefense)
        {
            Name = name;
            DamageOrDefense = damageOrDefense;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceGambling
{
    public class Gamble
    {
        public int Multiplier { get; set; }
        public int Chance { get; set; }

        public Gamble()
        {

        }

        public Gamble(int multiplier, int chance)
        {
            Multiplier = multiplier;
            Chance = chance;
        }
    }
}

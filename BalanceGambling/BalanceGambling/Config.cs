using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceGambling
{
    public class Config : IRocketPluginConfiguration
    {
        public int MaxBet;
        public List<Gamble> gambles;
        public void LoadDefaults()
        {
            MaxBet = 100000;
            gambles = new List<Gamble> { new Gamble(2, 70), new Gamble(3, 60), new Gamble(4, 50), new Gamble(5, 40), new Gamble(6, 30), new Gamble(7, 20), new Gamble(8, 10) };
        }
    }
}

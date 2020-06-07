using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Framework.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceGambling
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Instance = this;

            Logger.Log("BalanceGambling plugin has been loaded");
            Logger.Log("Version: 1.0");
            Logger.Log("Made by Paradox");
        }

        protected override void Unload()
        {
            Logger.Log("BalanceGambling plugin has been unloaded");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "OnlyInteger", "{0} can only be an integer." },
            { "MaxBet", "You can't bet that much amount, maximum amount is {0}" },
            { "NotEnoughBalance", "You don't have enough balance to do this gamble." },
            { "CantMultiplyThatMuch", "You can't multiply that much" },
            { "Won", "You won and earned {0}" },
            { "Lost", "You lost and lost your {0} betted amount" }

        };
        public static Main Instance;
    }
}

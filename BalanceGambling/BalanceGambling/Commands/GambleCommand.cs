using fr34kyn01535.Uconomy;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceGambling.Commands
{
    class GambleCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "gamble";

        public string Help => "Gamble your money away!";

        public string Syntax => "/gamble (amount) (multiplier)";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            // Check Command Syntax
            if (command.Length > 2 || command.Length == 0 || command.Length == 1)
            {
                UnturnedChat.Say(caller, $"Correct Usage: {Syntax}");
                return;
            }

            // Check if both are integer
            if (!int.TryParse(command[0], out int amount))
            {
                UnturnedChat.Say(caller, Main.Instance.Translate("OnlyInteger", "Amount"));
                return;
            }
            if (!int.TryParse(command[1], out int multiplier))
            {
                UnturnedChat.Say(caller, Main.Instance.Translate("OnlyInteger", "Multiplier"));
                return;
            }

            // Check if amount is under the max bet amount
            if (amount > Main.Instance.Configuration.Instance.MaxBet)
            {
                UnturnedChat.Say(caller, Main.Instance.Translate("MaxBet", Main.Instance.Configuration.Instance.MaxBet));
                return;
            }

            // Check if player can afford bet
            if (amount > Uconomy.Instance.Database.GetBalance(player.CSteamID.ToString()))
            {
                UnturnedChat.Say(caller, Main.Instance.Translate("NotEnoughBalance"));
                return;
            }

            // Check if that multiplier is in that config (if it is, store it)
            Gamble gamble = null;
            bool found = false;
            foreach (Gamble temp in Main.Instance.Configuration.Instance.gambles)
            {
                if (temp.Multiplier == multiplier)
                {
                    found = true;
                    gamble = temp;
                    break;
                }
            }
            if (!found)
            {
                UnturnedChat.Say(caller, Main.Instance.Translate("CantMultiplyThatMuch"));
                return;
            }

            // Calculate the chance and multiply the money and give it to the player
            if (gamble.Chance >= UnityEngine.Random.Range(1, 101))
            {
                int multipliedAmount = (amount * multiplier) - amount;
                Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.ToString(), multipliedAmount);
                UnturnedChat.Say(caller, Main.Instance.Translate("Won", multipliedAmount));
                return;
            } else
            {
                Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.ToString(), -amount);
                UnturnedChat.Say(caller, Main.Instance.Translate("Lost",  amount));
                return;
            }
        }
    }
}

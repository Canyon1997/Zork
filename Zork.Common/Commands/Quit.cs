using System;
using System.Collections.Generic;
using System.Text;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class QuitCommand
    {
        [Command("QUIT", new string[] { "QUIT", "Q", "GOODBYE", "BYE"})]
        public static void Quit(Game game, CommandContext comandContext)
        {
            if(Game.ConfirmAction("Are you sure you want to quit? "))
            {
                game.Quit();
            }
        }
    }
}

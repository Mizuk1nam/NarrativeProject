using System;
using System.Runtime.InteropServices;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Shop : Room
    {

        internal override string CreateDescription() =>
@"You now enter the shop. You have " + MoneyCounter.money.Amount.ToString() + "$ You can buy a [heal] for 10$, [sword] 30$, [shield] 40$ or you can choose to [return]  ";



        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "return":
                    Console.WriteLine("You return back to the street");
                    Game.Transition<Street>();
                    return;
                case "heal":
                    MoneyCounter.money.Subtract(10);
                    HPCounter.hp.Add(50);
                    Console.WriteLine("You recieved a HP patch-up, Current HP: " + HPCounter.hp.Amount );
                    Console.WriteLine("You have $" + MoneyCounter.money.Amount);
                    return;
                case "sword":
                    return;
                case "shield":
                    return;
                default:
                    Console.WriteLine("Invalid Command");
                    return;

            }

        }
        
    }
}

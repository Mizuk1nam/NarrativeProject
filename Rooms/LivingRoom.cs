﻿using NarrativeProject.Rooms;
using System;
using static NarrativeProject.Game;

namespace NarrativeProject
{
    internal class LivingRoom : Room
    {
        internal override string CreateDescription() =>
@"In the living room you finally see the [exit].
On a table you see a [wallet]
You can return to your [bedroom]. 

";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "wallet":
                    Wallet.takeWallet();
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "exit":
                    Console.WriteLine("You approach the exit and open the door, leaving your house, you may choose to return at any time.");
                    Game.Transition<Street>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }

    internal class Wallet
    {
        private static bool moneyTaken = false;

        public static void takeWallet()
        {
            Console.WriteLine("You see a wallet, do you take it? [yes] or [no]");
            string answer = Console.ReadLine();

            if (answer == "yes" && !moneyTaken)
            {
                Console.WriteLine("You take the wallet and find $100");
                MoneyCounter.money.Amount += 100;
                Console.WriteLine("You now have: $" + MoneyCounter.money.Amount);
                moneyTaken = true;
            }
            else if (answer == "yes" && moneyTaken)
            {
                Console.WriteLine("You already took the money.");
            }
            else if(answer == "no" ) 
            {
                Console.WriteLine("You put the wallet down and leave it be");
            }
            else
            {
                Console.WriteLine("Invalid Command");
                Wallet.takeWallet();
            }
        }
    }
}

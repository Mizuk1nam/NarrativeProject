﻿using System;
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
                    int hpnow = HPCounter.hp.Amount;
                    if (hpnow = )
                    Console.WriteLine("You recieved a HP patch-up, Current HP: " + HPCounter.hp.Amount );
                    Console.WriteLine("You have $" + MoneyCounter.money.Amount);
                    return;
                case "sword":
                    MoneyCounter.money.Subtract(30);
                    Inventory.AddItem("Sword", 1);
                    Console.WriteLine("You purchased a sword");
                    Console.WriteLine("You have $" + MoneyCounter.money.Amount);
                    return;
                case "shield":
                    MoneyCounter.money.Subtract(40);
                    Inventory.AddItem("Shield", 1);
                    Console.WriteLine("You purchased a shield");
                    Console.WriteLine("You have $" + MoneyCounter.money.Amount);
                    return;
                default:
                    Console.WriteLine("Invalid Command");
                    return;

            }

        }
        
    }
}

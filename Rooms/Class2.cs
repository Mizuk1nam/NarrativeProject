using System;
using System.Runtime.InteropServices;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Shop : Room
    {

        internal override string CreateDescription() =>
@"You now enter the shop. You have " + MoneyCounter.money.Amount.ToString() + "You can buy a [heal] for 10$, [sword] 30$ ";



        internal override void ReceiveChoice(string choice)
        {


        }
        
    }
}

using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Shack : Room
    {
        internal override string CreateDescription() =>
@"You enter the abandoned shack. You smell a familiar smell in the [room] next to you. You may also [exit]";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "exit":
                    Console.WriteLine("You return back to the street");
                    Game.Transition<Street>();
                    break;
                case "room":
                    Console.WriteLine("You feel suspense as you open the door not knowing what to expect");
                    Console.WriteLine("You push the door open");
                    Console.WriteLine("You see, your SISTER turned into a zombie!");
                    Console.WriteLine("This frigthens you.. to the point where you WAKE UP");
                    Console.WriteLine("You realize.. it was all a dreammm.... (Super anticlimatic)");
                    Console.WriteLine("Congratulations, you have completed this game!");
                    Game.Finish();
                    break;

            }
        }
    }
}

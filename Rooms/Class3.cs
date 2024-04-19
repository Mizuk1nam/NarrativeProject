using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Shack : Room
    {
        internal override string CreateDescription() =>
@"You enter the abandoned shack. You smell a familiar smell in the room next to you. You may also [exit]";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "exit":
                    Console.WriteLine("You return back to the street");
                    Game.Transition<Street>();
                    break;
            }
        }
    }
}

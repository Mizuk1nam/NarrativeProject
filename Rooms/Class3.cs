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
                    string[] endLine = {
            "You feel suspense as you open the door not knowing what to expect",
            "You push the door open",
            "You see, your SISTER turned into a zombie!",
            "This frightens you.. to the point where you WAKE UP",
            "You realize.. it was all a dreammm.... (Super anticlimactic)",
            "Congratulations, you have completed this game!"
        };

                    foreach (string line in endLine)
                    {
                        Console.WriteLine(line);
                    }
            
            Game.Finish();
                    break;

            }
        }
    }
}

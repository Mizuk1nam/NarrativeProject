using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Street : Room
    {

        internal override string CreateDescription() =>
@"You now find yourself in the street you can choose to walk [forward] or go [backward]

";
        int count = 0;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "forward":
                    
                        count++;
                        Console.WriteLine("You can continue to walk [forward] or go [backward]");
                    break;
                    
                case "backward":
                    count--;
                    if (count == -1)
                    {
                        Console.WriteLine("You return back to your house");
                        Game.Transition<LivingRoom>();
                    }

                    
                    break;
                default:
                    Console.WriteLine("Invalid command.");

                    break;
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;
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
                    
                        count++ ;
                        Console.WriteLine("You can continue to walk [forward] or go [backward]");
                    Console.WriteLine("You walked " + count + " steps away from the house");
                    if (count == 6)
                    {
                        Console.WriteLine("You see a shop, do you wish to enter? [Enter]");
                    }
                    break;
                    
                case "backward":
                    count--;
                    
                    if (count == -1)
                    {
                        Console.WriteLine("You return back to your house");
                        count = 1;
                        Game.Transition<LivingRoom>();
                    }
                    else
                    {
                        Console.WriteLine("You walked " + count + " steps away from the house");
                    }

                    
                    break;
                default:
                    Console.WriteLine("Invalid command.");

                    break;
            }
        }
    }
}

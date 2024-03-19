using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal class LivingRoom : Room
    {
        internal override string CreateDescription() =>
@"In the living room you find nothing important for your journey.
You can return to your [bedroom]. 
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
               
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }

    
}

using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You are in your bedroom.
You need to save your sister but you are trapped in your house.
Find a way to exit your house
The [door] in front of you leads to your living room.
Your private [bathroom] is to your left.
You know the entrance to your attic is in the bathroom

";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
              
                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");

                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                    
                        Game.Transition<LivingRoom>();
                    }
                    break;
                case "street":
                    Game.Transition<Street>();
                    break;
                case "shop":
                    Game.Transition<Shop>();
                    break;  
               
                default:
                    Console.WriteLine("Invalid command.");
                    
                    break;
            }
           
        }
    }
}

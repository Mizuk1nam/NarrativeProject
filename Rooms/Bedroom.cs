using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to your living room.
Your private [bathroom] is to your left.
You know the entrance to your attic is in the bathroom
Another door leads you to your [living room].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "living room":
                    Console.WriteLine("You enter the living room");
                    Game.Transition<LivingRoom>();
                    break;
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
                        Game.Finish();
                    }
                    break;
               
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

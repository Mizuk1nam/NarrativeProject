using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {

        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom]. You may now acces the [attic].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    Console.WriteLine("You relax in the bath. ");
                    break;
                case "mirror":
                    Console.WriteLine("You see the numbers 6969 written on the fog on your mirror.");
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "attic":
                    Console.WriteLine("You enter the attic");
                    Game.Transition<AtticRoom>();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

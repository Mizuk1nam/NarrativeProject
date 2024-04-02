using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected;

        private string randomCode;

        public AtticRoom()
        {
            codeGen generator = new codeGen();
            randomCode = generator.genCode();
        }

        internal override string CreateDescription() =>
@"In the attic, it's dark and cold.
A chest is locked with the code [????].
You can return to your [bathroom].
You see a [shadow] part of the attic
";

        internal override void ReceiveChoice(string choice)
        {
            if (choice == "bathroom")
            {
                Console.WriteLine("You return to your bathroom.");
                Game.Transition<Bathroom>();
            }
            else if (choice == "shadow")
            {
                Console.WriteLine("You find a note on the floor with the numbers " + randomCode + " written on it");
                Game.Transition<AtticRoom>();
            }
            else if (choice == randomCode)
            {
                Console.WriteLine("The chest opens and you get a key.");
                isKeyCollected = true;
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
using NarrativeProject.Rooms;
using System;
using System.Xml.Serialization;
using static NarrativeProject.Game;
using static NarrativeProject.HP;
using static NarrativeProject.Inventory;

namespace NarrativeProject
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
           
            var game = new Game();
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new LivingRoom());
            game.Add(new Street());
           game.Add(new Shack());



            game.Add(new Shop());
           

            while (!game.IsGameOver())
            {
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();

            //sources : https://stackoverflow.com/questions/7809745/linq-code-to-select-one-item
            // https://www.howtogeek.com/devops/what-are-enums-enumerated-types-in-programming-and-why-are-they-useful/
            //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-8.0
            // save system https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-8.0
        }
    }
}

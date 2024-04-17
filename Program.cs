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
        }
    }
}

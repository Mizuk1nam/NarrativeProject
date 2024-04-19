using System;
using System.Net;
using System.Runtime.InteropServices;
using static NarrativeProject.Game;
using static NarrativeProject.Inventory;

namespace NarrativeProject.Rooms
{
    internal class Street : Room
    {

        internal override string CreateDescription() =>
@"You now find yourself in the street you can choose to walk [forward] or go [backward]. Check your stats? [stats]

";
        int count = 0;
        
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "stats":
                    Console.WriteLine("Player's current HP: " + HPCounter.hp.Amount);
                    Console.WriteLine("Money: " + MoneyCounter.money.Amount.ToString());
                    Console.WriteLine("Items: "  );
                    foreach (var item in Inventory.Items)
                    {
                        Console.WriteLine(item);
                       
                    }

                    break;
                case "forward":
                    
                        count++ ;
                    Random random = new Random();
                    if (random.Next(0, 5) == 0)
                    {
                        HPCounter.hp.Subtract(10);


                        Console.WriteLine("You tripped on a stick and lost 10 HP. Current HP: " + HPCounter.hp.Amount);
                    }
                   
                    Console.WriteLine("You walked " + count + " steps away from the house");

                    if (count == 6)
                    {
                        Console.WriteLine("You see a shop. Do you wish to [enter] or keep going [forward] or go [backward]?");
                        string cho1ce;
                        cho1ce = Console.ReadLine();
                        if (cho1ce == "Enter")
                        {
                            Console.WriteLine("You enter the shop");
                            Game.Transition<Shop>();
                        }
                        else if (cho1ce == "enter")
                            {
                                Console.WriteLine("You enter the shop");
                                Game.Transition<Shop>();
                            }
                        else if (cho1ce == "forward")
                        {
                            count++;
                            Console.WriteLine("You walked " + count + " steps away from the house");
                        }
                        else if (cho1ce == "backward")
                        {
                            count--;
                            Console.WriteLine("You walked " + count + " steps away from the house");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Command");
                        }

                    }
                    if (count == 12)
                    {
                        Console.WriteLine("You see an abandoned shack. Do you wish to [enter] or keep going [forward] or go [backward]? " );
                        string cho1ce;
                        cho1ce = Console.ReadLine();
                        if (cho1ce == "Enter")
                        {
                            Console.WriteLine("You enter the shack");
                            Game.Transition<Shack>();
                        }
                        
                        else if (cho1ce == "enter")
                        {
                            Console.WriteLine("You enter the shack");
                            Game.Transition<Shack>();
                        }
                        else if (cho1ce == "forward")
                        {
                            count++;
                            Console.WriteLine("You walked " + count + " steps away from the house");
                        }
                        else if (cho1ce == "backward")
                        {
                            count--;
                            Console.WriteLine("You walked " + count + " steps away from the house");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Command");
                        }
                        

                    }
                    if (count == 15)
                    {
                        Console.WriteLine("Hey buddy you might want to turn back, it's unsafe from this point");
                    }
                    if (count == 20)
                    {
                        Console.WriteLine("Honestly, you were warned to turn back, A serial killer comes out of a bush and stabs you");
                        HPCounter.hp.Subtract(100);
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

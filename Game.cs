using System;
using System.Collections.Generic;
using static NarrativeProject.Game;
using System.IO;
using System.Linq;

namespace NarrativeProject
{
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();
        private Money money = new Money(0);
        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
        internal class codeGen
        {
            private Random _random = new Random();

            public string genCode()
            {
                int randomInt = _random.Next(1000, 10000);
                return randomInt.ToString();
            }
        }
        internal class Money
        {
            public int Amount { get; set; }


            internal Money(int amount)
            {
                Amount = amount;

            }

            internal void Add(int amount)
            {
                Amount += amount;
            }

            internal bool Subtract(int amount)
            {
                if (Amount - amount < 0)
                {
                    Console.WriteLine("Sorry, you do not have enough money to buy this.");
                    return false;
                }
                else
                {
                    Amount -= amount;
                    return true;
                }
            }

            public override string ToString()
            {
                return $"{Amount}";
            }

        }
        public static class MoneyCounter
        {

            public static Money money = new Money(0);
        }
    }
    public class HP
    {
        public int Amount { get; set; }

        internal HP(int amount)
        {
            Amount = amount;
        }

        internal void Add(int amount)
        {
            Amount += amount;
            if (Amount > 100)
            {

                Amount = 100;
            }

        }


        internal void Subtract(int amount)
        {
            Amount -= amount;
            if (Amount <= 0)
            {
                Console.WriteLine("You died");
                Game.Finish();
            }
        }


        public override string ToString()
        {
            return $"{Amount}";
        }
    }

    public static class HPCounter
    {
        public static HP hp = new HP(100);
    }


    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public void addItem(int amount)
        {
            Quantity += amount;
        }

        public void subItem(int amount)
        {
            Quantity -= amount;
            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Quantity}";
        }
    }
    public enum ItemType
    {
        Sword,
        Shield,
        Stick,
        Cookie,
        Book
    }
    public static class Inventory
    {
        public static List<Item> Items = new List<Item>
    {
        new Item("Sword", 0),
        new Item("Shield", 0),
            new Item ("Stick", 0),
            new Item("Cookie", 0),
             new Item("Book", 0)
    };

        public static void AddItem(string name, int quantity)
        {
            var item = Items.Find(i => i.Name == name);
            if (item != null)
            {
                item.addItem(quantity);
            }
            else
            {
                Items.Add(new Item(name, quantity));
            }
        }

        public static void SubtractItem(string name, int quantity)
        {
            var item = Items.Find(i => i.Name == name);
            if (item != null)
            {
                item.subItem(quantity);
            }
        }

        public static Item GetItem(string name)
        {
            return Items.Find(i => i.Name == name);
        }
    }
    internal static class LoadData
    {
        internal static void LoadPlayerData()
        {
            try
            {
                using (StreamReader reader = new StreamReader("player_data.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("HP: "))
                        {
                            int hp = int.Parse(line.Substring(4));
                            HPCounter.hp.Amount = hp;
                        }
                        else if (line.StartsWith("Money: "))
                        {
                            int money = int.Parse(line.Substring(7));
                            MoneyCounter.money.Amount = money;
                        }
                        else if (line.StartsWith("Items: "))
                        {
                            string[] items = line.Substring(7).Split(',');
                            foreach (string item in items)
                            {
                                string[] parts = item.Trim().Split(':');
                                string itemName = parts[0];
                                int quantity = int.Parse(parts[1]);
                                Inventory.AddItem(itemName, quantity);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Player data file not found. Starting with default values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading player data: " + ex.Message);
            }
        }
    }
}



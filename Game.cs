﻿using System;
using System.Collections.Generic;

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

            internal void Subtract(int amount)
            {
                Amount -= amount;
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
        }

        internal void Subtract(int amount)
        {
            Amount -= amount;
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

    public static class Inventory
    {
        public static List<Item> Items = new List<Item>
    {
        new Item("Sword", 0),
        new Item("Shield", 0)
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

}



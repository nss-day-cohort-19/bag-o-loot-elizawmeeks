﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.CheckChild();
            db.CheckToy();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine("2. Assign toy to a child");
            Console.WriteLine("3. Revoke toy from child");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            ListHelper listMaster = new ListHelper();
            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
            if (choice == 2)
            {
                Console.WriteLine("Assign toy to which child?");
                Dictionary<int, string> childrenList = listMaster.GetChildren();
                int c = 0;
                // KeyValuePair<int, string> number in numberTable
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    Console.WriteLine($"{c}. {thing.Value}");
                }
                Console.Write ("> ");
                // Read in the user's choice
                int assignedChild;
                Int32.TryParse (Console.ReadLine(), out assignedChild);
                Console.WriteLine($"Enter toy to add to this {childrenList[assignedChild]}'s Bag o' Loot");
                Console.Write ("> ");
                string newToy = Console.ReadLine();
                SantaHelper Helper = new SantaHelper();
                Helper.AddToyToBag(newToy, assignedChild);
                Console.WriteLine($"{newToy} has been assigned to {childrenList[assignedChild]}!");
            }
            if (choice == 3)
            {
                Console.WriteLine("Remove toy from which child?");
                Console.WriteLine(">");
                Dictionary<int, string> childrenList = listMaster.GetChildren();
                int c = 0;
                // KeyValuePair<int, string> number in numberTable
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    Console.WriteLine($"{c}. {thing.Value}");
                }
                Console.Write ("> ");
                // Read in the user's choice
                int assignedChild;
                Int32.TryParse (Console.ReadLine(), out assignedChild);
                Console.WriteLine($"Choose toy to revoke from {childrenList[assignedChild]}'s Bag o' Loot");
                List<string> childsToys = listMaster.GetChildsToys(assignedChild);
                int d = 0;
                foreach (string thing in childsToys)
                {
                    d++;
                    Console.WriteLine($"{d}. {thing}");
                }
                Console.Write ("> ");
                int revokedToy;
                Int32.TryParse (Console.ReadLine(), out revokedToy);
            }
        }
    }
}

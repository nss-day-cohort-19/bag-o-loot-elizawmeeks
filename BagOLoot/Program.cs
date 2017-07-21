using System;
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
            Console.WriteLine("4. Review child's toy list");
            Console.WriteLine("5. Child toy delivery complete");
            Console.WriteLine("6. Yuletime Delivery Report");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            ListHelper listMaster = new ListHelper();
            SantaHelper Helper = new SantaHelper();
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
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    if (c == assignedChild)
                    {
                        assignedChild = thing.Key;
                    }
                }
                Console.WriteLine($"Enter toy to add to this {childrenList[assignedChild]}'s Bag o' Loot");
                Console.Write ("> ");
                string newToy = Console.ReadLine();
                
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
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    if (c == assignedChild)
                    {
                        assignedChild = thing.Key;
                    }
                }
                Console.WriteLine($"Choose toy to revoke from {childrenList[assignedChild]}'s Bag o' Loot");
                List<string> childsToys = listMaster.GetChildsToys(assignedChild);
                int d = 0;
                foreach (string thing in childsToys)
                {
                    d++;
                    Console.WriteLine($"{d}. {thing}");
                }
                Console.Write ("> ");
                int revokedIndex;
                int revokedToyId;
                Int32.TryParse (Console.ReadLine(), out revokedIndex);
                List<int> toyIdList = listMaster.GetChildsToyIds(assignedChild);
                d = 0;
                foreach (int thing in toyIdList)
                {
                    d++;
                    if (d == revokedIndex)
                    {
                        revokedToyId = thing;
                        Helper.RemoveToyFromBag(revokedToyId, assignedChild);
                    }
                }
            }
            if (choice == 4)
            {
                Console.WriteLine ("View Bag o' Loot for which child?");
                Dictionary<int, string> childrenList = listMaster.GetChildren();
                int c = 0;
                // KeyValuePair<int, string> number in numberTable
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    Console.WriteLine($"{c}. {thing.Value}");
                }
                Console.Write ("> ");
                int assignedChild;
                Int32.TryParse (Console.ReadLine(), out assignedChild);
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    if (c == assignedChild)
                    {
                        assignedChild = thing.Key;
                    }
                }
                List<string> childsToys = listMaster.GetChildsToys(assignedChild);
                int e = 0;
                foreach (string thing in childsToys){
                    e++;
                    Console.WriteLine($"{e}. {thing}");
                }
            }
            if (choice == 5)
            {
                Console.WriteLine ("Which child had all of their toys delivered?");
                Dictionary<int, string> childrenList = listMaster.GetChildren();
                int c = 0;
                // KeyValuePair<int, string> number in numberTable
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    Console.WriteLine($"{c}. {thing.Value}");
                }
                Console.Write ("> ");
                int assignedChild;
                Int32.TryParse (Console.ReadLine(), out assignedChild);
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    c++;
                    if (c == assignedChild)
                    {
                        assignedChild = thing.Key;
                    }
                }
                Helper.MarkAsDelivered(assignedChild);
            }
            if (choice == 6)
            {
                Console.WriteLine ("Yuletime Delivery Report");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%");
                Dictionary<int, string> childrenList = listMaster.GetGoodChildren();
                // KeyValuePair<int, string> number in numberTable
                foreach (KeyValuePair<int, string> thing in childrenList)
                {
                    Console.WriteLine($"{thing.Value}");
                    List<string> childToys = listMaster.GetChildsToys(thing.Key);
                    foreach (string toy in childToys)
                    {
                        int c = 0;
                        c++;
                        Console.WriteLine($"{c}. {toy}");
                    }
                }
            }
        }
    }
}

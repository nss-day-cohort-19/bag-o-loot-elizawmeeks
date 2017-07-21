using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class AssignToy
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        // Assigns toys to a child
        Console.WriteLine("Assign toy to which child?");
            // Gets dictionary of children's names and ids
        Dictionary<int, string> childrenList = listMaster.GetChildren();
            // Lists children, accepts user input about what child to assign toy to.
        int assignedChild;
        assignedChild = Helper.ListAndAcceptChildren(childrenList, Helper);
            // Accepts user input about what to toy add
        Console.WriteLine($"Enter toy to add to this {childrenList[assignedChild]}'s Bag o' Loot");
        Console.Write ("> ");
        string newToy = Console.ReadLine();
            // Adds toy to database
        Helper.AddToyToBag(newToy, assignedChild);
        Console.WriteLine($"{newToy} has been assigned to {childrenList[assignedChild]}!");
    }
  }
}
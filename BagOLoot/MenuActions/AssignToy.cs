using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class AssignToy
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        Console.WriteLine("Assign toy to which child?");
        Dictionary<int, string> childrenList = listMaster.GetChildren();
        int assignedChild;
        assignedChild = Helper.ListChildrenOnConsoleAndTakeResponse(childrenList);
        Helper.MatchIncrementToChildId(childrenList, assignedChild);
        Console.WriteLine($"Enter toy to add to this {childrenList[assignedChild]}'s Bag o' Loot");
        Console.Write ("> ");
        string newToy = Console.ReadLine();
        
        Helper.AddToyToBag(newToy, assignedChild);
        Console.WriteLine($"{newToy} has been assigned to {childrenList[assignedChild]}!");
    }
  }
}
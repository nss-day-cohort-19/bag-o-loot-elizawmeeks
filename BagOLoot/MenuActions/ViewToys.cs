using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class ViewToys
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        Console.WriteLine ("View Bag o' Loot for which child?");
        Dictionary<int, string> childrenList = listMaster.GetChildren();
        int assignedChild;
        assignedChild = Helper.ListChildrenOnConsoleAndTakeResponse(childrenList);
        List<string> childsToys = listMaster.GetChildsToys(assignedChild);
        int e = 0;
        foreach (string thing in childsToys){
            e++;
            Console.WriteLine($"{e}. {thing}");
        }
    }
  }
}
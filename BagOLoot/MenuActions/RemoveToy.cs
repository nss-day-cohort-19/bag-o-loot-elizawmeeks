using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class RemoveToy
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        Console.WriteLine("Remove toy from which child?");
        Console.WriteLine(">");
        Dictionary<int, string> childrenList = listMaster.GetChildren();
        int assignedChild;
        assignedChild = Helper.ListChildrenOnConsoleAndTakeResponse(childrenList);
        // Making the choice number selected the childId, which is the key in the
        // key/value pair in our child dictionary.
        Helper.MatchIncrementToChildId(childrenList, assignedChild);
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
  }
}
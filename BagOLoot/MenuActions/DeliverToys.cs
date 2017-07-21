using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class DeliverToys
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        Console.WriteLine ("Which child had all of their toys delivered?");
        Dictionary<int, string> childrenList = listMaster.GetChildren();
        int assignedChild;
        assignedChild = Helper.ListChildrenOnConsoleAndTakeResponse(childrenList);
        Helper.MatchIncrementToChildId(childrenList, assignedChild);
        Helper.MarkAsDelivered(assignedChild);
    }
  }
}
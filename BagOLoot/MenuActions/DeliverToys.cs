using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class DeliverToys
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        // Delivers all the toys to one child
        Console.WriteLine ("Which child had all of their toys delivered?");
            // Gets dictionary of child names and Ids
        Dictionary<int, string> childrenList = listMaster.GetChildren();
            // Lists children and accepts user input as to who to deliver toys to
        int assignedChild;
        assignedChild = Helper.ListAndAcceptChildren(childrenList, Helper);
            // Delivers toys
        Helper.MarkAsDelivered(assignedChild);
    }
  }
}
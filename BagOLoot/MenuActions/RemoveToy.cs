using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class RemoveToy
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        // Removes toy from a naughty child
        Console.WriteLine("Remove toy from which child?");
        Console.WriteLine(">");
            // Gets list of children names and ids
        Dictionary<int, string> childrenList = listMaster.GetChildren();
            // Lists children on console and accepts user input for what child to select
        int assignedChild;
        assignedChild = Helper.ListAndAcceptChildren(childrenList, Helper);
            // Lists what toys the child was assigned and allows you to revoke one
        Console.WriteLine($"Choose toy to revoke from {childrenList[assignedChild]}'s Bag o' Loot");
        List<string> childsToys = listMaster.GetChildsToys(assignedChild);
        int d = 0;
        foreach (string thing in childsToys)
        {
            d++;
            Console.WriteLine($"{d}. {thing}");
        }
        Console.Write ("> ");
            // Reads user input about what toy to revoke
        int revokedIndex;
        int revokedToyId;
        Int32.TryParse (Console.ReadLine(), out revokedIndex);
            // Matches number of incremented toy to actual Toy Id then revokes the toy.
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
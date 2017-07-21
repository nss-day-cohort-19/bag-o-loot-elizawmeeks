using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class ViewToys
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
    {
        // View what toys have been assigned to a child
        Console.WriteLine ("View Bag o' Loot for which child?");
            // Gets dictionary of child names and ids
        Dictionary<int, string> childrenList = listMaster.GetChildren();
            // Lists children and accepts user input for what child's toy list to vew
        int assignedChild;
        assignedChild = Helper.ListAndAcceptChildren(childrenList, Helper);
        int choice;
        do
        {
            // Gets list of child's toys and writes it to console
            List<string> childsToys = listMaster.GetChildsToys(assignedChild);
            int e = 0;
            foreach (string thing in childsToys){
                e++;
                Console.WriteLine($"{e}. {thing}");
            }
            // Accepts r to return to main menu
            Console.WriteLine("Press 'r' and then 'enter' to return to menu");
            Console.WriteLine(">");
		    choice = Console.Read();
        }while(choice != 114);
    }
  }
}
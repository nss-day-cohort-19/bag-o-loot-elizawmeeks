using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class YuleReport
  {
    public static void DoAction(ListHelper listMaster, SantaHelper Helper)
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
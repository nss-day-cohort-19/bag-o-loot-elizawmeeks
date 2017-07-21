using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class AddChild
  {
    public static void DoAction()
    {
      Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
    }
  }
}
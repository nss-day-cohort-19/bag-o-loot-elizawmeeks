using System;
using System.Collections.Generic;

namespace BagOLoot.MenuActions
{
  public class AddChild
  {
    public static void DoAction()
    {
      // Add child to database
      Console.WriteLine ("Enter child name");
      Console.Write ("> ");
        // Accepts user input
      string childName = Console.ReadLine();
        // Registers child to database
      ChildRegister registry = new ChildRegister();
      bool childId = registry.AddChild(childName);
    }
  }
}
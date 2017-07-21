using System;
using System.Collections.Generic;
using System.Linq;
using BagOLoot.MenuActions;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check to see if the databases exist, if they don't, create one.
            var db = new DatabaseInterface();
            db.CheckChild();
            db.CheckToy();
            int choice;

            // Creating new instances of our menu, Santa's Helper, and our List Master
            MenuBuilder menu = new MenuBuilder();
            ListHelper listMaster = new ListHelper();
            SantaHelper Helper = new SantaHelper();

            do 
            {
                // Show Main Menu
                choice = menu.ShowMainMenu();
                switch (choice)
                {
                    case 1:
                        AddChild.DoAction();
                    break;
                    case 2:
                        AssignToy.DoAction(listMaster, Helper);
                    break;
                    case 3:
                        RemoveToy.DoAction(listMaster, Helper);
                    break;
                    case 4:
                        ViewToys.DoAction(listMaster, Helper);
                    break;
                    case 5:
                        DeliverToys.DoAction(listMaster, Helper);
                    break;
                    case 6:
                        YuleReport.DoAction(listMaster, Helper);
                    break;
                }

            } while (choice != 7);

        }
    }
}

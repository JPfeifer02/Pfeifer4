/********************************************************************
*** NAME        : Johnny Pfeifer                                  ***
*** CLASS       : CSc 346                                         ***
*** ASSIGNMENT  : 4                                               ***
*** DUE DATE    : 4/3                                             ***
*** INSTRUCTOR  : GAMRADT                                         ***
*********************************************************************
*** DESCRIPTION : This program simulates running an app store.    ***
    You can select an app store, Google or Apple, and purchase apps.*
********************************************************************/

using System;

namespace AppStoreNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name:        Johnny Pfeifer\nClass:       CSC 346\nAssignment:  4\nDue Date:    4/3\n" +
                "Instructor:  Gamradt\nDescription: This program simulates running an app store. You can\n" +
                "             select an app store, Google or Apple, and purchase apps.\n");

            Apple appleStore = new Apple();
            Google googleStore = new Google();
            int selection = 0;
            while(selection != 3)
            {
                Console.WriteLine("(1) Apple App Store");
                Console.WriteLine("(2) Google App Store");
                Console.WriteLine("(3) Exit");
                Console.Write("Select a store or exit (3): ");
                string? input = Console.ReadLine();
                bool success = int.TryParse(input, out selection);
                if ((success == false) || (selection < 1) || (selection > 3))
                {
                    Console.WriteLine("Please input a number 1 to 3\n");
                }
                else if (selection == 1)
                {
                    appleStore.PurchaseApp();
                }
                else if (selection == 2)
                {
                    googleStore.PurchaseApp();
                }
            }
        }

    }
}

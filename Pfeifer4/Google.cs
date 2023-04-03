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
namespace AppStoreNS;

public class Google : AppStore
{
    // Properties

    // Methods
    public Google() : base(3)   // Constructor
    {
        Apps.Add(new App("Cubasis 3", 46, 3));
        Apps.Add(new App("FL Studio Mobile", 50, 5));
        Apps.Add(new App("LumaFusion Pro", 57, 1));
    }
    public Google(Google other) : base(3)  // Copy Constructor
    {
        if (other != null)
        {
            for (int i = 0; i < 3; i++)
            {

                Apps.Add(new App(other.Apps[i]));
            }
            Selected = other.Selected;
            Paid = other.Paid;
        }
    }

    /********************************************************************
    *** METHOD      : WelcomeToStore                                  ***
    *********************************************************************
    *** DESCRIPTION : This method displays a message to the user,     ***
    ***                 thanking them for using the app store         ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    protected override void WelcomeToStore()
    {
        Console.WriteLine("Welcome to the Google App Store!");
    }
    /********************************************************************
    *** METHOD      : ReturnChange                                    ***
    *********************************************************************
    *** DESCRIPTION : This method calculates and displays the change. ***
    ***                 It decides if the app will be purchased       ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    protected override void ReturnChange()
    {
        if (Paid >= Apps[Selected].Price)   //purchase successful
        {
            Paid -= Apps[Selected].Price;
            Console.WriteLine("$5 bill change: " + (Paid/5));
            Paid %= 5;
            Console.WriteLine("$2 bill change: " + (Paid/2));
            Paid %= 2;
            Console.WriteLine("$1 bill change: " + Paid + "\n");
            Paid = 1; 
        }
        else        // purchase unsuccessful
        {
            Console.WriteLine("$5 bill change: " + (Paid/5));
            Paid %= 5;
            Console.WriteLine("$2 bill change: " + (Paid/2));
            Paid %= 2;
            Console.WriteLine("$1 bill change: " + Paid + "\n");
            Paid = 0; 
        }
    }    
}
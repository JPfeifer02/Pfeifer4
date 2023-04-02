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
    private Google(Google other) : base(3)
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
    /********************************************************************
    *** METHOD      : DownloadApp                                     ***
    *********************************************************************
    *** DESCRIPTION : Tells a customer if their app is being downloaded**
    ***                 Thanks customer for using the appstore        ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    protected override void DownloadApp()
    {
        if(Paid == 1)
        {
            Console.WriteLine("App purchased successfully. Downloading. . . ");
            Apps[Selected].Available--;
            Console.WriteLine("Thank you for purchasing " + Apps[Selected].Name + " from the Google App Store!");

        }
        else
        {
            Console.WriteLine("Payment declined: insufficient funds");
        }
        Console.Write("Press enter to continue. . . ");
        Console.ReadLine();
        Console.Clear();
    }
}
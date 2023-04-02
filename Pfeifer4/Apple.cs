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

public class Apple : AppStore
{
    // Properties

    // Methods
    public Apple() : base(4) 
    {
        Apps.Add(new App("Final Cut Pro", 54, 3));
        Apps.Add(new App("Logic Pro", 50, 4));
        Apps.Add(new App("MainStage", 46, 5));
        Apps.Add(new App("Pixelmator Pro", 57, 2));
    }
    private Apple(Apple other) : base(4)
    {
        if(other != null)
        {
            for (int i = 0; i < 4; i++)
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
        Console.WriteLine("Welcome to the Apple App Store!");
    }
    /********************************************************************
    *** METHOD      : PayForApp                                       ***
    *********************************************************************
    *** DESCRIPTION : This method prompts the user for a payment      ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    protected override void PayForApp()
    {
        Paid = 0;

        Console.Write("Amount of $10 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 10;
        Console.Write("Amount of $5 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 5;
        Console.Write("Amount of $1 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
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
            Console.WriteLine("Thank you for purchasing " + Apps[Selected].Name + " from the Apple App Store!");
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
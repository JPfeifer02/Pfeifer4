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

public abstract class AppStore
{
    // Properties
    protected List<App> Apps;
    protected int Selected {get; set;}
    protected int Paid {get; set;}

    // Methods
    // Default Constructor
    public AppStore(int num)
    {
        Apps = new List<App>();
    }
    //Paramaterized Constructor
    public AppStore(List<App> apps, int selected, int paid)
    {
        Apps = apps;
        Selected = selected;
        Paid = paid;
    }
    
    // Copy Constructor
    private AppStore(AppStore other)
    {
        this.Apps = new List<App>(other.Apps);
        this.Selected = other.Selected;
        this.Paid = other.Paid;
    }
    /********************************************************************
    *** METHOD      : PurchaseApp                                     ***
    *********************************************************************
    *** DESCRIPTION : This method calls each method needed in the app ***
    ***                 purchasing process                            ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    public void PurchaseApp()
    {
        WelcomeToStore();
        SelectApp();
        PayForApp();
        ReturnChange();
        DownloadApp();
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
    protected abstract void WelcomeToStore();      //protected?
    /********************************************************************
    *** METHOD      : SelectApp                                       ***
    *********************************************************************
    *** DESCRIPTION : This method displays a menu to selected an app  ***
    ***                  from the desired app store.                  ***
    *** INPUT ARGS  :                                                 ***
    *** OUTPUT ARGS :                                                 ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN      : void                                            ***
    ********************************************************************/
    protected void SelectApp()
    {

        int j = 0;
        foreach (App i in Apps)
        {
            Console.WriteLine("(" + j + ") " + i.Name.PadRight(25) + "Price: $" + i.Price + "\t\tAvailable:" + i.Available);
            j++;
        }
        bool done = false;
        while(!done)
        {
            Console.Write("Choose an App: ");
            string? input = Console.ReadLine();
            int choice;
            bool isInt = int.TryParse(input, out choice);
            Selected = choice;
            if(isInt == false || Selected < 0 || Selected > Apps.Count - 1)
            {
                Console.WriteLine("Number must be between 0 and " + (Apps.Count - 1));
            }
            else if (Apps[Selected].Available <= 0)
            {
                Console.WriteLine(Apps[Selected].Name + " is not currently available");
            }
            else done = true;
        }
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
    protected virtual void PayForApp()  //default: $20 and $10 bills accepted
    {
        Paid = 0;

        Console.Write("Amount of $20 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 20;
        Console.Write("Amount of $10 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 10;
        Console.WriteLine();
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
    protected virtual void ReturnChange()   //default implementation
    {
        if (Paid >= Apps[Selected].Price)   //purchase successful
        {
            Paid -= Apps[Selected].Price;
            Console.WriteLine("$10 bill change: " + (Paid/10));
            Paid %= 10;
            Console.WriteLine("$1 bill change: " + Paid + "\n");
            Paid = 1;
        }
        else        // purchase unsuccessful
        {
            Console.WriteLine("$10 bill change: " + (Paid/10));
            Paid %= 10;
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
    protected void DownloadApp()        //default method - override for each appstore
    {
        if(Paid == 1)
        {
            Console.WriteLine("App purchased successfully! Downloading " + Apps[Selected].Name + ". . .");
            Apps[Selected].Available--;
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


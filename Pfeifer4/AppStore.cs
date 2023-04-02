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
    //public AppStore(List<App> apps, int selected, int paid)
    
    // Copy Constructor
    private AppStore(AppStore other)
    {
        this.Apps = other.Apps;
        this.Selected = other.Selected;
        this.Paid = other.Paid;
    }
    public void PurchaseApp()
    {
        WelcomeToStore();
        SelectApp();
        PayForApp();
        ReturnChange();
        DownloadApp();
    }
    protected abstract void WelcomeToStore();      //protected?

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
    protected virtual void PayForApp()
    {
        Paid = 0;

        Console.Write("Amount of $20 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 20;
        Console.Write("Amount of $10 bills entered: ");
        Paid += Convert.ToInt32(Console.ReadLine()) * 10;
        Console.WriteLine();
    }
    protected virtual void ReturnChange()
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
    protected void DownloadApp()
    {
        if(Paid == 1)
        {
            Console.WriteLine("App purchased successfully. Downloading");
            Apps[Selected].Available--;
        }
        else
        {
            Console.WriteLine("Payment declined: insufficient funds");
        }
        Console.WriteLine(Apps[Selected].Name);
        Console.Write("Press enter to continue. . . ");
        Console.ReadLine();
        Console.Clear();
    }

}

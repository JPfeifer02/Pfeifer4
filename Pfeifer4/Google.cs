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

        protected override void WelcomeToStore()
    {
        Console.WriteLine("Welcome to the Google App Store!");
    }
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
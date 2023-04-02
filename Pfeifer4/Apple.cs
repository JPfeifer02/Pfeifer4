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
    protected override void WelcomeToStore()
    {
        Console.WriteLine("Welcome to the Apple App Store!");
    }
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
}
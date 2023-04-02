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

public class App
{
    // Properties
    public string Name {get; set;} = "";
    public int Price {get; set;} = 0;
    public int Available {get; set;} = 0;
    // Methods
    public App(string name = "", int price = 0, int available = 0)  // default parameterized
    {
        Name = name;
        Price = price;
        Available = available;
    }
    public App(App other)   // copy 
    {
        Name = other.Name;
        Price = other.Price;
        Available = other.Available;
    }
}
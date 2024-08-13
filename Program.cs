/*
 *Dictionary<string, decimal>
empty list of string (cart)

loop
-display menu (kvp)
-ask for input
-if item is in store, add to cart (.ContainsKey())
-if not, don't add to cart
-ask if they want to add more items (similar to if you want to continue loops)

total = 0
foreach the cart
-display item name and price (dictionary[itemName])
-add price onto the total
display total

Task: Make a shopping list application which uses collections to store your items. (You will be using two collections, one for the menu and one for the shopping list.)

What will the application do?
1.Display at least 8 item names and prices.
2.Ask the user to enter an item name
3.If that item exists, display that item and price and add that item to the user’s order.
4.If that item doesn’t exist, display an error and re-prompt the user.  (Display the menu again if you’d like.)
5.After adding one to their order, ask if they want to add another. If so, repeat.  (User can enter an item more than once; we’re not keeping track of quantity at this point.)
6.When they’re done adding items, display a list of all items ordered with prices in columns.
7.Display the sum price of the items ordered.

 */

using System.Collections;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Generic;


bool tryAgain = true;
decimal total = 0.0m;
int counter = 0;
int most = 0;
int least = 0;
decimal tempMax = 0m;
decimal tempMin = 0m;

Dictionary<string, decimal> menu = new Dictionary<string, decimal>()
{
     { "apple" , 0.99m } , {"banana" , 0.59m} ,{ "cauliflower" , 1.59m } , {"dragonfruit" , 2.19m},
     { "elderberry" , 1.79m } , {"figs" , 2.09m}  ,{"grapefruit" , 1.99m } , {"honeydew" , 3.49m},
};

List<string> shopList = new List<string>();

Console.WriteLine("Welcome to Angelos Market!");
Console.WriteLine("Item\t\tPrice");
Console.WriteLine("============================");
foreach (KeyValuePair<string, decimal> kvp in menu)
    {
        Console.WriteLine($"{kvp.Key}\t\t${kvp.Value}");
    }
while (tryAgain == true)
{
    Console.WriteLine("What item would you like to order?");
    string order = Console.ReadLine();
    if (menu.ContainsKey(order))
    {
        
        Console.WriteLine($"Adding {order} to cart at ${menu[order]}");
        total += menu[order];
        shopList.Add(order);
        counter++;
        

    


        Console.WriteLine($"Your current bill is : ${total}.\nWould you like to order anything else y/n?");
        string response = Console.ReadLine().ToLower();
        if (response == "y")
        {
            continue;
        }
        else
        {
            tryAgain = false;
            Console.WriteLine("Here is what you ordered:");
            List<string> ordered = shopList.OrderBy(num => menu[num]).ToList();   //order the shopping list with linq

            foreach (string s in ordered)
            {
                Console.WriteLine($"{s}\t\t{menu[s]}");

            }
            Console.WriteLine($"Your total is: ${total} and the average price per item is ${total/counter}");


            Console.WriteLine($"Least expensive item: {ordered.First()}");
            Console.WriteLine($"Most expensive item: {ordered.Last()}");
            
        }
    }
    else
    {
        Console.WriteLine("Sorry, we don't have those. Please try again.");
    }
}
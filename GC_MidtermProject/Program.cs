using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GC_MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            List<string> inventory = new List<string>
            {
                "stuff" 
            };
            List<string> shoppingCart = new List<string>();


        }
        public static int ShoppingMenu(List<string> inventory, List<string>shoppingCart)
        {
            while (true)
            {

                for (int index = 0; index < inventory.Count; index++)
                {
                    Console.WriteLine($"{(index + 1)} {inventory[index]}");
                }

                Console.WriteLine("Which item would you like to add to your cart?");
                int itemselection = int.Parse(Console.ReadLine()) - 1;
                shoppingCart.Add(inventory[itemselection]);

                Console.WriteLine($"How many {inventory[itemselection]}(s) would you like?");
                int quantity = int.Parse(Console.ReadLine());
                return quantity;
            }

        }
    }
}

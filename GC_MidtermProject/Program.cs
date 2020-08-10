
﻿using System;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
namespace GC_MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>() { };

            StreamReader reader = new StreamReader("../../../ProductList.txt");
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] productProperty = line.Split('|');
                products.Add(new Product(productProperty[0], (Category) Enum.Parse(typeof(Category), productProperty[1]), productProperty[2], double.Parse(productProperty[3])));
                line = reader.ReadLine();
            }
            reader.Close();

            while (true)
            {
                List<Product> shoppingCart = new List<Product>();

                shoppingCart = ShoppingMenu(products);

                CheckOut(shoppingCart);

                Console.WriteLine("Would you like to place another order? Y/N");
                string cont = Console.ReadLine().ToLower();
                while (cont!="n" && cont != "y")
                {
                    Console.WriteLine("Invalid entry. please input Y/N");
                    cont= Console.ReadLine().ToLower();
                }
                if (cont == "n")
                {
                    break;
                }
               

            Console.Clear();
            }

        }
        
        public static void CheckOut(List<Product> shoppingList)
        {
            string[] checkoutOptions = { "Cash", "Credit", "Check" };
            double subTotal = 0;
            double taxRate = .06;
            double taxTotal = 0;

            foreach (var product in shoppingList)
            {
                subTotal += product.Price * product.Quantity;
            }

            taxTotal = subTotal * taxRate;

            Console.WriteLine($"Subtotal = ${subTotal:N2}");
            Console.WriteLine($"Tax (6%) = ${taxTotal:N2}");
            Console.WriteLine($"Grand Total = ${(subTotal + taxTotal):N2}");

            Console.WriteLine("How would you like to pay?");

            for (int i = 0; i < checkoutOptions.Length; i++)
            {
                Console.WriteLine($"{i+1}) {checkoutOptions[i]}");
            }

            int paymentChoice = int.Parse(Console.ReadLine());

            if (paymentChoice == 1)
            {
                
                Console.WriteLine("How much money are you giving us?");
                double tenderedAmount = double.Parse(Console.ReadLine());

                Cash cashPayment = new Cash(tenderedAmount,(subTotal+taxTotal));
                double change = cashPayment.ChangeBack();       //cash receipt

               

                Console.WriteLine($"Your change is ${change:N2}.  Thanks for shopping!");

                cashPayment.Receip(shoppingList, subTotal, taxTotal);
            }
            else if (paymentChoice == 2)
            {
                CreditCard creditPayment = new CreditCard();
                //double change = 
                creditPayment.ChangeBack();
                creditPayment.Receip(shoppingList,subTotal,taxTotal);       //credit receipt
            }
            else if (paymentChoice == 3)
            {
                Check check = new Check();
                check.ChangeBack();
            }

        }

        
        public static List<Product> ShoppingMenu(List<Product> inventory)//, List<Product> shoppingCart)
        {
            int shoppingcartIndex = 0;
            List<Product> shoppingCart = new List<Product>() { };

            while (true)
            {
                
                for (int index = 0; index < inventory.Count; index++)  //displays all products available to purchase
                {
                    Console.Write($"{index + 1}) ");
                    inventory[index].PrintList();
                }

                Console.WriteLine("Which item would you like to add to your cart?");  //finds index in inventory of what product we want to purchase
                int itemselection = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine($"How many {inventory[itemselection].Name}(s) would you like?");  //asks user for how much of said product they'd like to buy
                int quantity = int.Parse(Console.ReadLine());

                
                shoppingCart.Add(inventory[itemselection]);  //adds selected product to shopping cart

                shoppingCart[shoppingcartIndex].Quantity = quantity;  //updates qty of product in shopping cart
                
                shoppingCart[shoppingcartIndex].PrintList();
                
                shoppingcartIndex++;  //iterates shopping cart index

                

                Console.Write("Would you like to purchase another item? (y/n) ");
                string input = Console.ReadLine().ToLower();

                while (input != "n" && input != "y")
                {
                    Console.Write("Invalid response.  Please enter (y/n) ");
                    input = Console.ReadLine().ToLower();
                }

                if (input == "n")
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
            return shoppingCart;

        }
         
     
    }
}


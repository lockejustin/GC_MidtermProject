
using System;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GC_MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                List<Product> products = new List<Product>() { };

                StreamReader reader = new StreamReader("../../../ProductList.txt");
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] productProperty = line.Split('|');
                    products.Add(new Product(productProperty[0], productProperty[1], productProperty[2], double.Parse(productProperty[3]), int.Parse(productProperty[4])));
                    line = reader.ReadLine();
                }
                reader.Close();


                Console.WriteLine("Press 0: For user");
                Console.WriteLine("Press 1: For Admin");
                Console.WriteLine("Press 2: To exit");

                int choice = -1;

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Entry-Please enter 0 or 1 or 2");
                }

                if (choice == 0)
                {

                    while (true)
                    {
                        List<Product> shoppingCart = new List<Product>();

                        shoppingCart = ShoppingMenu(products);

                        CheckOut(shoppingCart);

                        Console.WriteLine("Would you like to place another order? Y/N");
                        string cont = Console.ReadLine().ToLower();
                        while (cont != "n" && cont != "y")
                        {
                            Console.WriteLine("Invalid entry. please input Y/N");
                            cont = Console.ReadLine().ToLower();
                        }
                        if (cont == "n")
                        {
                            break;
                        }

                        Console.Clear();
                    }
                }
                else if (choice == 1)
                {
                    while (true)
                    {


                        StreamWriter writer = new StreamWriter("../../../ProductList.txt");
                        Console.WriteLine("Please enter a name");
                        string name = Console.ReadLine();
                        for (int i = name.Length; i < 15; i++)
                        {
                            name += " ";
                        }
                        Console.WriteLine("Please enter a description");
                        string description = Console.ReadLine();
                        for (int i = description.Length; i < 15; i++)
                        {
                            description += " ";
                        }
                        Console.WriteLine("Please enter a category");
                        Console.WriteLine($"1 for Drink 2 for Food 3 for HardGood 4 for SoftGood");

                        string _category = "";
                        int category = -1;
                        while (true)
                        {

                            while (!int.TryParse(Console.ReadLine(), out category))
                            {
                                Console.WriteLine("Please enter a numerical value 1 - 4");
                            }
                            if (category == 1)
                            {
                                _category = "Drink   ";
                                break;
                            }
                            else if (category == 2)
                            {
                                _category = "Food    ";
                                break;
                            }
                            else if (category == 3)
                            {
                                _category = "HardGood";
                                break;
                            }
                            else if (category == 4)
                            {
                                _category = "SoftGood";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry - Please try again");
                            }
                        }
                        Console.WriteLine("Please enter a price");
                        double price = 0;// double.Parse(Console.ReadLine());
                        while (!double.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Please enter a numerical value");
                        }

                        Console.WriteLine($"How many you want to add to inventory?");
                        int Inventory = 0;// double.Parse(Console.ReadLine());
                        while (!int.TryParse(Console.ReadLine(), out Inventory))
                        {
                            Console.WriteLine("Please enter a numerical value");
                        }

                        //Console.ReadKey();
                        products.Add(new Product(name, _category, description, price, Inventory));

                        foreach (Product product in products)
                        {
                            writer.WriteLine($"{product.Name}|{product.Category}|{product.Description}|{product.Price}|{product.Inventory}");
                        }
                        writer.Close();

                        Console.WriteLine("Would you like to add another item (Y/N)?");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "y")
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Thank you - Bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid - Entry");
                }



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

            for (int i = 0; i < shoppingList.Count; i++)
            {
                shoppingList[i].PrintLineTotal();
            }
            Console.WriteLine($"Subtotal = ${subTotal:N2}");
            Console.WriteLine($"Tax (6%) = ${taxTotal:N2}");
            Console.WriteLine($"Grand Total = ${(subTotal + taxTotal):N2}");

            Console.WriteLine("How would you like to pay?");

            for (int i = 0; i < checkoutOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {checkoutOptions[i]}");
            }
            //string input3 = Console.ReadLine();
            int paymentChoice = 0;//int.Parse(Console.ReadLine());
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out paymentChoice))
                {
                    Console.WriteLine("Please enter a numerical value");
                }

                if (paymentChoice == 1)
                {
                    Console.WriteLine("How much money are you giving us?");

                    double tenderedAmount = 0;

                    while (!double.TryParse(Console.ReadLine(), out tenderedAmount))
                    {
                        Console.WriteLine("Please enter a valid dollar amount");
                    }

                    Cash cashPayment = new Cash(tenderedAmount, (subTotal + taxTotal));
                    double change = cashPayment.ChangeBack();       //cash receipt

                    Console.WriteLine($"Your change is ${change:N2}.  Thanks for shopping!");

                    cashPayment.Receip(shoppingList, subTotal, taxTotal);
                    break;
                }
                else if (paymentChoice == 2)
                {
                    CreditCard creditPayment = new CreditCard();
                    creditPayment.ChangeBack();
                    creditPayment.Receip(shoppingList, subTotal, taxTotal);       //credit receipt
                    break;
                }
                else if (paymentChoice == 3)
                {
                    Check check = new Check();
                    check.ChangeBack();
                    check.Receip(shoppingList, subTotal, taxTotal);  //check receipt
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry - Please try again!");
                }
            }
        }


        public static List<Product> ShoppingMenu(List<Product> inventory)//, List<Product> shoppingCart)
        {
            int shoppingcartIndex = 0;
            List<Product> shoppingCart = new List<Product>() { };

            string input2 = "";


            while (true)
            {

                for (int index = 0; index < inventory.Count; index++)  //displays all products available to purchase
                {
                    Console.Write($"{index + 1}) ");
                    inventory[index].PrintList();
                }

                Console.WriteLine("Which item would you like to add to your cart?");  //finds index in inventory of what product we want to purchase
                int itemselection = 0; //int.Parse(Console.ReadLine()) - 1;

                while (true) //validation for menu entry
                {
                    input2 = Console.ReadLine();
                    try
                    {
                        itemselection = int.Parse(input2);
                        if (itemselection > 0 && itemselection <= inventory.Count)
                        {
                            itemselection = itemselection - 1;
                            break;
                        }
                        else
                        {
                            Console.Write($"That is not a valid choice.  Please input a number between 1 and {inventory.Count} ");
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("That choice wasn't a number.  Please try again.");
                    }
                }

                Console.WriteLine($"How many would you like?");  //asks user for how much of said product they'd like to buy


                int quantity = 0;

                while (true) //validation for quantity entry
                {
                    input2 = Console.ReadLine();
                    try
                    {
                        quantity = int.Parse(input2);
                        if (quantity > inventory[itemselection].Inventory)
                        {
                            Console.WriteLine($"Not enough in stock - please enter a quantity less than {inventory[itemselection].Inventory}");
                            continue;
                        }
                        else if (quantity > 0)
                        {
                            inventory[itemselection].Inventory -= quantity;
                            break;
                        }

                        else
                        {
                            Console.WriteLine($"That is not a valid choice.  Please input a quantity greater than 0.");
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("That choice wasn't a number.  Please try again.");
                    }
                }


                shoppingCart.Add(inventory[itemselection]);  //adds selected product to shopping cart

                shoppingCart[shoppingcartIndex].Quantity = quantity;  //updates qty of product in shopping cart

                shoppingCart[shoppingcartIndex].PrintLineTotal();

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
            StreamWriter writer = new StreamWriter("../../../ProductList.txt");
            foreach (Product product in inventory)
            {

                writer.WriteLine($"{product.Name}|{product.Category}|{product.Description}|{product.Price}|{product.Inventory}");
            }

            writer.Close();

            return shoppingCart;

        }


    }
}


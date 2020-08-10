using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class Check : Payment
    {
        //Property
        int RoutingNumber { get; set; }
        double AccountNumber { get; set; }

        //Constructor

        public Check()
        {
            //this.RoutingNumber = RoutingNumber;
            //this.AccountNumber = AccountNumber;
        }

        //method
        public override double ChangeBack()
        {
            Console.Write("Please Enter your 7-digit routing number: ");
            RoutingNumber = int.Parse(Console.ReadLine());
            while (true)
            {

                if (RoutingNumber > 999999 && RoutingNumber <= 9999999)
                {
                    Console.Write("Please Enter your 8-digit account number: ");
                    AccountNumber = double.Parse(Console.ReadLine());
                    if (AccountNumber > 9999999 && AccountNumber <= 99999999)
                    {

                        Console.WriteLine("\nPayment Processes - Thank you for using our service");
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid account number - Please try again");
                        AccountNumber = double.Parse(Console.ReadLine());
                    }

                }
                else
                {
                    Console.WriteLine("Invalid - routing number, Please try again");
                    RoutingNumber = int.Parse(Console.ReadLine());
                }
            }
            return -1;
        }
        public override void Receip(List<Product> shoppingList, double subTotal, double taxTotal)
        {
            base.Receip(shoppingList, subTotal, taxTotal);
            Console.WriteLine("Payment Type: Check");

        }

    }
}

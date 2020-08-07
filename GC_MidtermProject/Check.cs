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
            Console.Write("Please Enter your routing number: ");
            RoutingNumber = int.Parse(Console.ReadLine());
            while (true)
            {


                if (RoutingNumber > 999999 && RoutingNumber < 10000000)
                {
                    Console.Write("Please Enter your account number: ");
                    AccountNumber = double.Parse(Console.ReadLine());
                    if (AccountNumber > 99999999 && AccountNumber < 10000000000000)
                    {

                        Console.WriteLine("\nPayment Processes - Thank you for using our service");
                        break;
                    }
                    else
                    {
                        Console.Write("invalid account number - Please try again");
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
    }
}

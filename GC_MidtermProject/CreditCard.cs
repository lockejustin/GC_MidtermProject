using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class CreditCard:Payment
    {
        //properties
        public double CreditCardNumber {get;set;}
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }

        //Constructor
        public CreditCard() { }
        public CreditCard (double CreditCardNumber, DateTime ExpirationDate, int CVV)
        {
            this.CreditCardNumber = CreditCardNumber;
            this.ExpirationDate = ExpirationDate;
            this.CVV = CVV;
        }

        //method
        public override double ChangeBack()
        {
            //Prompt for card number
            Console.Write("Please enter your credit card number: ");
            double creditCardNumber = double.Parse(Console.ReadLine());

            if (creditCardNumber < 9999999999999999 && creditCardNumber > 999999999999999)
            {
                //Prompt for expiration date
                Console.Write("Please enter your credit card expiration date: ");
                DateTime date;

                while (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Please enter a correct date: ");
                }

                Console.WriteLine("Please enter your CVV: ");
                int CVV = int.Parse(Console.ReadLine());

                while (true)
                {
                    if (CVV < 1000 && CVV > 99)
                    {
                        Console.WriteLine("Payment Processing Please Wait");
                        Console.WriteLine("\nPayment Processed - Thank you!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid CVV.  Please try again: ");
                        CVV = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                Console.Write("Invalid Credit Card number entered.  Please try again: ");
                creditCardNumber = double.Parse(Console.ReadLine());
            }
            return -1;
        }
    }
}

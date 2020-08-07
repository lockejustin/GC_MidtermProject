using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class CreditCard:Payment
    {
        //properties
        public int CreditCardNumber {get;set;}
        public DateTime ExpirationDate { get; set; }
        public int CW { get; set; }

        //Constructor
        public CreditCard() { }
        public CreditCard (int CreditCardNumber, DateTime ExpirationDate, int CW)
        {
            this.CreditCardNumber = CreditCardNumber;
            this.ExpirationDate = ExpirationDate;
            this.CW = CW;
        }

        //method
        public override double ChangeBack()
        {
            Console.WriteLine("Payment Processing Please Wait");
            Console.WriteLine("\nPayment Processes - Thank you for using our service");
            return -1;
        }
    }
}

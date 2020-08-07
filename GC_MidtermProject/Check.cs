using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class Check:Payment
    {
        //Property
        int CheckNumber { get; set; }

        //Constructor
        public Check (int checkNumber)
        {
            this.CheckNumber = checkNumber;
        }

        //method
        public override double ChangeBack()
        {
            Console.WriteLine($"Processing your check number {CheckNumber}");
            Console.WriteLine("\nPayment Processes - Thank you for using our service");
            return -1;
        }
   

    }
}

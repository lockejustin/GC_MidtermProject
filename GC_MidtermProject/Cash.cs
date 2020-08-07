using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class Cash:Payment
    {
        //Properties
        double TenderedAmount { get; set; }
        double TotalPrice { get; set; }

        //constructor
        public Cash() { }
        public Cash(double TenderedAmount, double TotalPrice)
        {
            this.TenderedAmount = TenderedAmount;
            this.TotalPrice = TotalPrice;
        }

        //Method
        public override double ChangeBack()
        {
            double ChangeBack = TenderedAmount - TotalPrice;
            return ChangeBack;
        }
    }
}

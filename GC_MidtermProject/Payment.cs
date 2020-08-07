using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    abstract class Payment
    {

        public Payment() { }

        //method
        public abstract double ChangeBack();

        public virtual void Receip (List<Product> shoppingList,double subTotal, double taxTotal)
        {
            Console.WriteLine("Your receipt");
            Console.WriteLine($"ITEM\tName\tQTY\tUnit Price\tLine Total");
            for (int i =0;i<shoppingList.Count;i++)
            {
                
                Console.WriteLine($"{i+1}\t{shoppingList[i].Name}\t{shoppingList[i].Quantity}\t\t{shoppingList[i].Price:N2}\t{(shoppingList[i].Quantity* shoppingList[i].Price):N2}");                
            }
            Console.Write($"The Total = {(subTotal + taxTotal):N2}");
        }

    }
}

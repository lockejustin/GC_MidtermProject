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
            Console.WriteLine($"Item\tName\t\tQTY\tUnit Price\tLine Total");


            for (int i =0;i<shoppingList.Count;i++)
            {
                string price = shoppingList[i].Price.ToString();
                double total = shoppingList[i].Quantity * shoppingList[i].Price;
                string lineTotal = total.ToString();

                if (price.Length <= 10)  //truncates name if longer than 10 characters
                {
                    for (int j = price.Length; j < 10; j++)
                    {
                        price += " ";
                    }
                }

                Console.WriteLine($"{i+1}\t{shoppingList[i].Name}\t{shoppingList[i].Quantity}\t${price}\t${lineTotal}");                
            }
            Console.WriteLine($"The Total = ${(subTotal + taxTotal):N2}");
        }

    }
}

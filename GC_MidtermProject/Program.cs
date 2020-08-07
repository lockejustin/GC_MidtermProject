﻿using System;
using System.Collections.Generic;
using System.IO;

namespace GC_MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() { };
            products.Add(new Product("Cheese", Category.Food, "Delicious Wisonsin Cheddar", 4.99));
            products.Add(new Product("Milk", Category.Drink, "2% Milk - Super Fresh!", 3.49));
            products.Add(new Product("Beef", Category.Food, "1 lb 100% Grass Fed Beef", 6.99));
            products.Add(new Product("Television", Category.HardGood, "85\" 8k 5G Enabled with 10 free Nic Cage movies", 4999.00));
            products.Add(new Product("Stuffed Penguin", Category.HardGood, "Stuffed Friend Always Dressed for the Occasion", 14.99));
            products.Add(new Product("Polka Dot Rain Coat", Category.SoftGood, "Stay dry, in style!", 19.99));


            StreamWriter writer = new StreamWriter("../../../ProductList.txt");

            foreach (Product product in products)
            {
                writer.WriteLine(product);
            }
            writer.Close();

        }
    }
}

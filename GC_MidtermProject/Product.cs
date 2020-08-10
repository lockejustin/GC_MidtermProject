using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    public enum Category
    {
        Food,
        Drink,
        HardGood,
        SoftGood,

    }

    class Product
    {
        //Properties
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int Inventory { get; set; }

        //End Properties

        //Constructors
        public Product(string name, Category category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = 0;

        }
        public Product(string name, Category category, string description, double price, int Inventory)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            this.Inventory = Inventory;
            Quantity = 0;

        }
        //End Constructors

        public void PrintList() 
        {
            if (Quantity == 0)
            {
                Console.WriteLine($"{Name} {Category} {Description} ${Price:N2}");
            }
            else
            {
                Console.WriteLine($"Line Total: {Name} {Quantity} ${Price:N2} ${(Quantity*Price):N2}");
            }

        }
    }
}

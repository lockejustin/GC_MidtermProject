using System;
using System.Collections.Generic;
using System.Text;

namespace GC_MidtermProject
{
    class Product
    {
        //Properties
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int Inventory { get; set; }

        //End Properties

        //Constructors
        public Product(string name, string category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = 0;

        }
        public Product(string name, string category, string description, double price, int Inventory)
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

                Console.WriteLine($"{Name}\t {Category}\t {Description} \t${Price:N2}");
            


        }
        public void PrintLineTotal()
        {
            Console.WriteLine($"Line Total: {Name.Trim()} \t QTY: {Quantity} \t Unit Price: ${Price:N2} \t Total Price: ${(Quantity * Price):N2}");
        }
    }
}

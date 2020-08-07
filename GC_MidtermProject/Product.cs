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
        //End Properties

        //Constructors
        public Product (string name, Category category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
        //End Constructors


    }
}

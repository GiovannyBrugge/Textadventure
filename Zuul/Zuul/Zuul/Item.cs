using System;
using System.Collections.Generic;

namespace Zuul
{
	public class Item
	{
        public string description;

        public int weight;

        public Item(string description, int weight)
        {
            this.description = description;
            this.weight = weight;
        }

        // this method is executed when called on a subclass.
        public string showItem()
        {
            return "I see a " + this.description + ".\n";
           
        }
        public string showInventoryItem()
        {
            return  this.description + " ~ " +  this.weight + "kg.\n";
        }

        // this method is 'virtual', and should be 'override' in subclasses.

        public virtual void Use(Object o)
        {
            System.Console.WriteLine("Item::Use(Object o)");
        }

        public virtual void Use()
        {
            System.Console.WriteLine("Item::Use()");
        }
      



    }

}
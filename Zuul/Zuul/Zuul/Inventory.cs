using System;
using System.Collections.Generic;

namespace Zuul
{
	public class Inventory
	{
		public List<Item> items = new List<Item>();
		private int max_kg = 0;

		public Inventory(int mk)
        {
			this.max_kg = mk;
        }
		public int addItem(Item item)
        {
			
			if (this.totalWeight() + item.weight < this.max_kg)
			{
				items.Add(item);
				//Console.WriteLine(item.description + " succesfully added to Inventory");
				return 1;
			}
			return 0;
		}
        public Item removeItem(Item item)
        {
            
            if (items.Remove(item))
            {
               
            }
          
            return null;
        }
        public Item removeItem(string desc)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].description == desc)
                {
                    Item item = items[i];
                    this.removeItem(item);
                    return item;
                }
            }
            Console.WriteLine("Could not find '" + desc + "' in Inventory");
            return null;
        }

        public string showItem()
        {
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                str += items[i].showItem();
            }
            return str;
        }

        public string showInventoryItem()
        {
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                str += items[i].showInventoryItem();
            }
            return str;
        }
        public void tradeItem(Inventory trader, string item)
        {
            Item trade = this.removeItem(item);

            if (trade != null)
            {
                trader.addItem(trade);
            }
        }
        public void dropItem(Inventory trader, string item)
        {
            Item trade = this.removeItem(item);

            if (trade != null)
            {
                trader.addItem(trade);
            }
        }
       
        private int totalWeight()
		{
			int t = 0;
			for (int i = 0; i < items.Count; i++ )
			{
				t += items[i].weight;
			}
			return t;
		}

      









	}

}
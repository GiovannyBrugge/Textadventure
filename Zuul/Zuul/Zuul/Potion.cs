using System;
using System.Collections.Generic;

namespace Zuul
{
    public class Potion : Item
    {
        public Potion(string description, int weight) : base(description, weight)
        {
            this.description = description;
            this.weight = weight;
        }
		public override void Use(Object o)
		{
			if (o.GetType() == typeof(Player))
			{
				Player p = (Player)o; // must cast
				p.healthHealed(0);
			}
			else
			{
				// Object o is not a Person
				System.Console.WriteLine("Can't use a Potion on Object " + o.GetType());
			}
		}

		public override void Use()
		{
			System.Console.WriteLine("Potion::Use()");
		}
	}

}
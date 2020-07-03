using System;
using System.Collections.Generic;

namespace Zuul
{
    public class Key : Item
    {
        public Key(string description, int weight) : base (description, weight)
        {
            this.description = description;
            this.weight = weight;
        }
		public override void Use(Object o)
		{
			if (o.GetType() == typeof(Room))
			{
				
				Room r = (Room)o; // must cast
				r.Unlock();
			}
			else
			{
				// Object o is not a Room
				System.Console.WriteLine("Can't use a Key on Object " + o.GetType());
			}
		}

		public override void Use()
		{
			System.Console.WriteLine("Key::Use()");
		}

	}

}
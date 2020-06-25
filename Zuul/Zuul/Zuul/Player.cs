using System;

namespace Zuul
{
	public class Player
	{
		public Room currentRoom;
		public int health;
		
		public Player()
		{
			health = 100;
			isAlive();
		}

		public int damageTaken(int amount) 
		{
			health = health - amount;
			//Console.WriteLine(health);
			return amount;
		}

		public int healthHealed(int amount)
		{
			health = health + amount;
			//Console.WriteLine(health);
			return amount;
		}
		public bool isAlive() 
        {

			if (health <= 0)
			{
				return false;
			}
			else
			{
				return true;
			}			
        }

		
	}
}

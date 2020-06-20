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
				//Console.WriteLine("you died");
				die();
				return false;
			}
			else
			{
				return true;
			}			
        }

		public void die()
        {
			Console.WriteLine("You died, press enter to exit.");
			Console.ReadLine();
			System.Environment.Exit(1);
		}
	}
}

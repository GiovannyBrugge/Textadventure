using System;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		public Player player;

		public Game ()
		{
			parser = new Parser();
			player = new Player();
			createRooms();
			
		}

		private void createRooms()
		{
			Room frontYard, lobby, basement, kitchen, livingRoom, attic;
			if (player.health > 0)
			{
				// create the rooms
				frontYard = new Room("at the front yard.");
				lobby = new Room("in a lobby.");
				basement = new Room("in a basement.");
				livingRoom = new Room("in a living room.");
				kitchen = new Room("in a kitchen.");
				attic = new Room("in an attic");

				// initialise room exits
				frontYard.setExit("north", lobby);

				lobby.setExit("south", frontYard);
				lobby.setExit("down", basement);
				lobby.setExit("up", attic);
				lobby.setExit("west", kitchen);

				basement.setExit("up", lobby);

				attic.setExit("down", lobby);

				kitchen.setExit("south-east", lobby);
				kitchen.setExit("north-east", livingRoom);

				livingRoom.setExit("west", kitchen);


				player.currentRoom = frontYard;  // start game outside

			}
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);

				if (player.health <= 0)
				{
					finished = true;
					
				}
			}


			if (player.health > 0)
			{
				Console.WriteLine("Thank you for playing, press 'enter' again to quit.");
			}
			else if (player.health <= 0)
            {
				Console.WriteLine("You died, press 'enter' again to quit.");
            }
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Giovanny's textadventure game.");
			Console.WriteLine("This is a horror textadventure game.");
			Console.WriteLine("If you see a name before a sentence then that person is talking. ");
			Console.WriteLine("If not, then something is being said by a narrator (like me).");
			Console.WriteLine();
			Console.WriteLine("If you need help, type 'help'.");
			Console.WriteLine();
			Console.WriteLine("You have arrived at your destination.");
			Console.WriteLine("As you enter the front yard, the gates behind you start to close.");
			Console.WriteLine();
			Console.WriteLine("Health:" + player.health);
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription()); 
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;
		
			if (command.isUnknown()) {
				Console.WriteLine("I can't do that");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
				case "look":
					checkRoom();
					break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Where do you want to go?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("You: I don't see a door in the direction "+direction+".");
			} else {
				player.currentRoom = nextRoom;
				Console.WriteLine();
				Console.WriteLine("You went " + direction);
				Console.WriteLine("You lost: " + player.damageTaken(25) + " health" );
				Console.WriteLine("Health:" + player.health);
				Console.WriteLine();
				player.isAlive();
				if (player.health > 0) {
					Console.WriteLine(player.currentRoom.getLongDescription());
				}
			}
		}

        private void checkRoom()
        {
			Console.WriteLine("You: It seems like I am currently " + player.currentRoom.getShortDescription());
        }
	}
}

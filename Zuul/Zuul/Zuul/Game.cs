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
			Room outside, theatre, pub, lab, office;

			// create the rooms
			outside = new Room("at the front yard.");
			theatre = new Room("in a campus pub.");
			pub = new Room("in the campus pub.");
			lab = new Room("in the computing lab.");
			office = new Room("in computing admin office.");

			// initialise room exits
			outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);

			theatre.setExit("west", outside);

			pub.setExit("east", outside);

			lab.setExit("north", outside);
			lab.setExit("east", office);

			office.setExit("west", lab);

			player.currentRoom = outside;  // start game outside

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
			}
			Console.WriteLine("Thank you for playing, press 'enter' again to quit.");
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

			if(command.isUnknown()) {
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
				Console.WriteLine(player.currentRoom.getLongDescription());
				
			}
		}
        private void checkRoom()
        {
			Console.WriteLine("You: It seems like I am currently " + player.currentRoom.getShortDescription());
        }

	}
}

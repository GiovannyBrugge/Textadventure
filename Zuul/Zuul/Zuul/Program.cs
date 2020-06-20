﻿using System;

namespace Zuul
{
    class Program
    {
        /**
		 * Create and play the Game.
		 */
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.play();
           
            // close the window with 'enter'
            Console.ReadLine();
        }
    }
}

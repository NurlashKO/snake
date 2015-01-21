using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SnakeConsoleApplication;

namespace SnakeConsoleApplication
{
	class Food
	{
		public Cell c;
		public Food()
		{
			c = new Cell (1, 1);
			Random r;
			do {	
				r = new Random (DateTime.Now.Second);
				c = new Cell (r.Next (1, MainProgram.H - 1), r.Next (1, MainProgram.W - 1));
			} while (MainProgram.snake.onSnake (c));

		}

		public void Draw() {
			MainProgram.EditCell (c, ConsoleColor.Red, "0");
		}
	}
}

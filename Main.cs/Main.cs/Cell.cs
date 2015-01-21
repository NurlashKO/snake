
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SnakeConsoleApplication;

namespace SnakeConsoleApplication
{
	class Cell
	{
		public int x, y;
		public Cell(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
			
		public bool equal(Cell c)
		{
			return c.x == this.x && c.y == this.y;
		}

		public static Cell operator + (Cell c1, Cell c2)
		{
			Cell buf = new Cell (c1.x + c2.x, c1.y + c2.y);
			return buf;
		}
	}
}

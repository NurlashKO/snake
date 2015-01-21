using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeConsoleApplication
{
	class Snake
	{
		public List<Cell> body;
		public Cell dir = MainProgram.Map[ConsoleKey.RightArrow];
		public Snake(List<Cell> body){
			this.body = body;
		}

		public void Draw() {
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (Cell s in body)
				MainProgram.EditCell(s, ConsoleColor.Green, "+");
			MainProgram.EditCell(body[0], ConsoleColor.DarkMagenta, "%");
		}

		public void eat(Cell c) {
			body.Insert(0, c);
			Console.Beep(50, 100);
			MainProgram.food = new Food ();
			MainProgram.score += 5;
		}

		public bool Change(Cell c) {
			Cell head = (new Cell(body[0].x, body[0].y)) + c;
			if (onSnake (head))//ON SNAKE, DIE!
				return false;
			if (MainProgram.onWall (head)) {//ON WALL, TELEPORTATION!
				if (head.x == MainProgram.H) {
					head.x = 1;
					dir = MainProgram.Map [ConsoleKey.RightArrow];
				}
				if (head.x == 0) {
					head.x = MainProgram.H - 1;
					dir = MainProgram.Map [ConsoleKey.LeftArrow];
				}
				if (head.y == MainProgram.W) {	
					head.y = 1;
					dir = MainProgram.Map [ConsoleKey.DownArrow];
				}
				if (head.y == 0) {
					head.y = MainProgram.W - 1;
					dir = MainProgram.Map [ConsoleKey.UpArrow];
				}
			}

			if (head.equal(MainProgram.food.c)) { //FRESH MEAT
				eat(MainProgram.food.c);
				return true;
			}
			for (int i = body.Count () - 1; i > 0; i--) //I like to MOVE IT MOVE IT
				body [i] = body [i - 1];
			body [0] = head;
			return true;
		}

		public bool Move(ConsoleKey b) {
			if (MainProgram.Map.ContainsKey (b)) {
				Cell buf = MainProgram.Map [b];
				if (buf.x * dir.x + buf.y * dir.y == 0) // (-1, 0) * (1, 0) = IGNORE, (0, 1) * (1, 0) = ACCEPT;
					dir = buf;

			}
			return Change (dir);
		}

		public bool onSnake(Cell c) {
			foreach (Cell s in body) {
				if (c.equal(s))
					return true;
			}
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeConsoleApplication
{
	class MainProgram
	{
		public static int W = 20, H = 50;
		public static List<Cell> walls = new List<Cell>();
		public static int score = 0;
		public static Dictionary<ConsoleKey, Cell> Map = 
			new Dictionary<ConsoleKey, Cell>();
		public static Food food;
		public static Snake snake;

		public static void EditCell(Cell c, ConsoleColor f, String ch) {
			Console.SetCursorPosition(c.x, c.y);
			Console.ForegroundColor = f;
			Console.Write(ch);
			Console.SetCursorPosition (H + 10, W / 2 + 5);
		}
			
		public static void DrawBorder() {
			for (int i = 0; i <= W; i++) {
				EditCell (new Cell (0, i), ConsoleColor.White, "#");
				EditCell (new Cell (H, i), ConsoleColor.White, "#");
				walls.Add (new Cell (0, i));walls.Add (new Cell (H, i));
			}
			for (int i = 0; i <= H; i++) {
				EditCell (new Cell (i, 0), ConsoleColor.White, "#");
				EditCell (new Cell (i, W), ConsoleColor.White, "#");
				walls.Add (new Cell(i, 0));walls.Add (new Cell(i, W));
			}
		}

		public static bool onWall(Cell c) {
			foreach (Cell w in walls) {
				if (w.equal (c))
					return true;
			}
			return false;
		}

		static List<Cell> InitialBody() {
			List<Cell> sn = new List<Cell>();
			sn.Add(new Cell(30, 10));
			sn.Add(new Cell(29, 10));
			sn.Add(new Cell(28, 10));
			sn.Add(new Cell(27, 10));
			return sn;
		}

		public static void Initiate() {

			Map[ConsoleKey.LeftArrow] = new Cell(-1, 0);
			Map[ConsoleKey.UpArrow] = new Cell(0, -1);
			Map[ConsoleKey.RightArrow] = new Cell(1, 0);
			Map[ConsoleKey.DownArrow] = new Cell(0, 1);
			snake = new Snake (InitialBody());
			food = new Food ();
			showTime ();
		}

		public static void drawScore(Cell c) {
			EditCell (c, ConsoleColor.White, "YOUR SCORE : " + score.ToString());
		}

		public static void showTime() {
			Console.Clear ();
			Console.CursorVisible = false;
			Console.BackgroundColor = ConsoleColor.Black;
			DrawBorder ();
			snake.Draw();
			food.Draw ();
			drawScore (new Cell(H + 10, W / 2));
		}

		static void Main(string[] args) {
			Initiate ();

			ConsoleKeyInfo pressed = Console.ReadKey(true);

			while (true) {
				showTime ();
				if (!snake.Move (pressed.Key))
					break;
				Thread.Sleep (100);
				if(Console.KeyAvailable)  pressed = Console.ReadKey(); 
			}
			Thread.Sleep(1000);
			Console.Clear ();
			EditCell(new Cell(Console.WindowWidth / 2 - 5, 10), ConsoleColor.Cyan, "GGWP EZ!!!");
			drawScore (new Cell(Console.WindowWidth / 2 - 5, 12));
			Console.Beep (10000, 1000);
			//Console.Beep (200, 1000);
			Console.ReadKey();
		}
	}
}

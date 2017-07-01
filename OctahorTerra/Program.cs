using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    class Program
    {
        static RenderWindow gameWin;
        public static RenderWindow Window { get { return gameWin; } }
        public static Game Game { private set; get; }
        static void Main(string[] args)
        {
            gameWin = new RenderWindow(new SFML.Window.VideoMode(800, 600),"OctahorTerra");
            gameWin.SetVerticalSyncEnabled(true);

            gameWin.Closed += GameWin_Closed;
            gameWin.Resized += GameWin_Resized;

            Contetn.Load();
            Game = new Game();

            while (gameWin.IsOpen)
            {
                gameWin.DispatchEvents();

                Game.Update();

                gameWin.Clear(Color.Black);

                Game.Draw();

                gameWin.Display();
            }
        }

        private static void GameWin_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            gameWin.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void GameWin_Closed(object sender, EventArgs e)
        {
            gameWin.Close();
        }
    }
}

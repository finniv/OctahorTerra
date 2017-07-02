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
        public static Random Rand { private set; get; }
        static void Main(string[] args)
        {
            //размеры окна по умолчанию
            gameWin = new RenderWindow(new SFML.Window.VideoMode(800, 600),"OctahorTerra");
            gameWin.SetVerticalSyncEnabled(true);

            gameWin.Closed += GameWin_Closed;
            gameWin.Resized += GameWin_Resized;

            Content.Load();
            Rand = new Random();//Новый обьект рандома
            Game = new Game();//Создаем новый обьект класса игры
            

            /*ожидание действий пока окно открыто
             * отрисовка игровых обьектов
             * заливка фона черным
             */
            while (gameWin.IsOpen)
            {
                gameWin.DispatchEvents();

                Game.Update();

                gameWin.Clear(Color.Black);

                Game.Draw();

                gameWin.Display();
            }
        }
        /// <summary>
        /// Срабатывает при изменении размера окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void GameWin_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            gameWin.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        /*закрытие окна*/
        private static void GameWin_Closed(object sender, EventArgs e)
        {
            gameWin.Close();
        }
    }
}

using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    class Game
    {
        /// <summary>
        /// Мир
        /// </summary>
        World world;
        Player player;
        public Game()
        {
            //создаем новый мир и генерируем его
            world = new World();
            world.GenerateWorld();

            //Player
            player = new Player(world);
            player.StartPosition= new Vector2f(300, 150);
            player.Spawn();
        }
        /// <summary>
        /// Обновление логики игры
        /// </summary>
        public void Update()
        {
            player.Update();
        }
        /// <summary>
        /// Прорисовка игры
        /// </summary>
        public void Draw()
        {
            Program.Window.Draw(world);
            Program.Window.Draw(player);

        }
    }
}

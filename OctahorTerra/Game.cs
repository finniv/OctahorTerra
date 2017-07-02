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

        public Game()
        {
            //создаем новый мир и генерируем его
            world = new World();
            world.GenerateWorld();
        }
        /// <summary>
        /// Обновление логики игры
        /// </summary>
        public void Update()
        {

        }
        /// <summary>
        /// Прорисовка игры
        /// </summary>
        public void Draw()
        {
            Program.Window.Draw(world);
        }
    }
}

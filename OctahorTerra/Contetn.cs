using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    class Contetn
    {
        public const string CONTENT_DIR = "..\\Content\\";
        public static Texture groundTile;
        public static Texture grassGroundTile;

        /// <summary>
        /// Загрузка текстур
        /// </summary>
        public static void Load()
        {
            groundTile = new Texture(CONTENT_DIR +"Textures\\Tiles_0.png");
            grassGroundTile = new Texture(CONTENT_DIR + "Textures\\Tiles_2.png");
        }
    }
}

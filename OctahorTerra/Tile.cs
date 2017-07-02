using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    /// <summary>
    /// Счетчик существующих на данный момент плиток
    /// </summary>
    enum TileType
    {
        NONE,     //ничего
        GROUND,  //земля
        GRASS   //трава
    }

    class Tile : Transformable, Drawable
    {
        /// <summary>
        /// Размер плитки равен 16 единицам
        /// </summary>
        public const int TILE_SIZE = 16;

        /*тип плитки по умолчанию*/
        /// <summary>
        /// тип плитки по умолчанию
        /// <param name="GROUND"></param>
        /// </summary>
        TileType type = TileType.GROUND;
        RectangleShape rectShape;

        public Tile(TileType type)
        {
            this.type = type; 

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE,TILE_SIZE));

            switch (type)
            {
                case TileType.GROUND:
                    rectShape.Texture = Contetn.groundTile;//блок с землей
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Contetn.grassGroundTile;//блок с травой
                    break;
            }
            rectShape.TextureRect = new IntRect(0, 0, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}

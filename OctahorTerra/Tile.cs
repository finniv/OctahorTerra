using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    enum TileType
    {
        NONE,     //ничего
        GROUND,  //земля
        GRASS   //трава
    }
    class Tile : Transformable, Drawable
    {
        //размер плитки по ширине и высоте
        public const int TILE_SIZE = 16;

        TileType type = TileType.GROUND;
        RectangleShape rectShape;

        public Tile(TileType type)
        {
            this.type = type; 

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE,TILE_SIZE));

            switch (type)
            {
                case TileType.GROUND:
                    rectShape.Texture = Contetn.texTile0;//блок с землей
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Contetn.texTile1;//блок с травой
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

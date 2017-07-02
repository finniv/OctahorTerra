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
        /// <summary>
        /// Форма плитки
        /// </summary>
        RectangleShape rectShape;

        //Соседи
        Tile upTile = null;//Верхний
        Tile downTile = null;//Нижний
        Tile leftTile = null;//Левый
        Tile rightTile = null;//Правый

        internal Tile UpTile
        {
            get
            {
                return upTile;
            }

            set
            {
                upTile = value;
                UpdateView();
            }
        }

        internal Tile DownTile
        {
            get
            {
                return downTile;
            }

            set
            {
                downTile = value;
                UpdateView();
            }
        }

        internal Tile LeftTile
        {
            get
            {
                return leftTile;
            }

            set
            {
                leftTile = value;
                UpdateView();
            }
        }

        internal Tile RightTile
        {
            get
            {
                return rightTile;
            }

            set
            {
                rightTile = value;
                UpdateView();
            }
        }

        public Tile(TileType type,Tile upTile,Tile downTile,Tile leftTile,Tile rightTile)
        {
            this.type = type;

            if (upTile!=null)
            {
                this.upTile = upTile;
                this.upTile.downTile = this;//Для верхнего соседа,эта плитка нижняя
            }

            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.upTile = this;//Для нижнего соседа,эта плитка верхняя
            }

            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.rightTile = this;//Для левого соседа,эта плитка правая
            }

            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.leftTile = this;//Для правого соседа,эта плитка левая
            }

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
            UpdateView();
        }
        /// <summary>
        /// Обновление внешнего вида плитки в зависимости от соседей
        /// </summary>
        public void UpdateView()
        {
            //есть все соседи
            if (upTile != null && downTile != null && leftTile != null && rightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 1);
            }
          
            
        }

        /// <summary>
        /// размер импортируемой плитки
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public IntRect GetTextureRect(int i,int j)
        {
            int x = i * TILE_SIZE + i * 2;
            int y = j * TILE_SIZE + j * 2;
            return new IntRect(x,y, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}

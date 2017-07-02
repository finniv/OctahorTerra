using SFML.Graphics;
using SFML.System;

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

        public Tile UpTile
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

        public Tile DownTile
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

        public Tile LeftTile
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

        public Tile RightTile
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

        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            // Присваиваем соседей, а соседям эту плитку
            if (upTile != null)
            {
                this.upTile = upTile;
                this.upTile.DownTile = this;    // Для верхнего соседа эта плитка будет нижним соседом
            }
            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.UpTile = this;    // Для нижнего соседа эта плитка будет верхним соседом
            }
            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.RightTile = this;    // Для левого соседа эта плитка будет правым соседом
            }
            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.LeftTile = this;    // Для правого соседа эта плитка будет левым соседом
            }

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            switch (type)
            {
                case TileType.GROUND:
                    rectShape.Texture = Content.groundTile;//блок с землей
                    break;
                case TileType.GRASS:
                    rectShape.Texture = Content.grassGroundTile;//блок с травой
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
            if (UpTile != null && DownTile != null && LeftTile != null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 1);
            }

            //нет соседей
            else if (UpTile == null && DownTile == null && LeftTile == null && RightTile == null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(9 + i, 3);
            }//----------------------------------------------------------------------
            //нет соседа сверху
            else if (UpTile == null && DownTile != null && LeftTile != null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 0);
            }
            //нет соседа снизу
            else if (UpTile != null && DownTile == null && LeftTile != null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i, 2);
            }
            //нет соседа слева
            else if (UpTile != null && DownTile != null && LeftTile == null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0, i);
            }
            //нет соседа справа
            else if (UpTile != null && DownTile != null && LeftTile != null && RightTile == null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(4, i);
            }//----------------------------------------------------------------------
            //нет соседа сверху слева
            else if (UpTile == null && DownTile != null && LeftTile == null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0 + i * 2, 3);
            }
            //нет соседа сверху справа
            else if (UpTile == null && DownTile != null && LeftTile != null && RightTile == null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i * 2, 3);
            }
            //нет соседа слева снизу
            else if (UpTile != null && DownTile == null && LeftTile == null && RightTile != null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(0 + i * 2, 4);
            }
            //нет соседа справа снизу
            else if (UpTile != null && DownTile == null && LeftTile != null && RightTile == null)
            {
                int i = Program.Rand.Next(0, 3);
                rectShape.TextureRect = GetTextureRect(1 + i * 2, 4);
            }
        }

        /// <summary>
        /// адресс импортируеммой плитки
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * TILE_SIZE + i * 2;
            int y = j * TILE_SIZE + j * 2;
            return new IntRect(x, y, TILE_SIZE, TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}
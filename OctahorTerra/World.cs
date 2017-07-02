using System;
using SFML.Graphics;
using SFML.System;

namespace OctahorTerra
{
    class World : Transformable,Drawable
    {
        /// <summary>
        /// Кол-во чанков по ширине и высоте
        /// </summary>
        public const int WORLD_SIZE = 25;
        /*мир представлен двумерным массивом чанков*/
        Chunk[][] chunks;

        /*Конструктор класса*/
        public World()
        {
            chunks = new Chunk[WORLD_SIZE][];

            for (int i = 0; i < WORLD_SIZE; i++)
            {
                chunks[i] = new Chunk[WORLD_SIZE];
            }
        }

        /// <summary>
        /// Генерация мира с различными плитками
        /// </summary>
        public void GenerateWorld()
        {
            for (int x = 5; x < 13; x++)
            {
                for (int y = 5; y < 12; y++)
                {
                    SetTile(TileType.GROUND, x, y);
                }
            }
        }

        public void SetTile(TileType type, int x, int y)
        {
            var chunk = GetChunk(x, y);
            var tilePos = GetTilePosFromChunk(x, y);

            //Соседи
            Tile upTile =       GetTile(x, y - 1);//Верхний
            Tile downTile =     GetTile(x, y + 1);//Нижний
            Tile leftTile =     GetTile(x - 1, y);//Левый
            Tile rightTile =    GetTile(x + 1, y);//Правый

            chunk.SetTile(type, tilePos.X, tilePos.Y, upTile, downTile, leftTile, rightTile);
        }

        /// <summary>
        /// получаем плитку
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tile GetTile(int x, int y)
        {
            var chunk = GetChunk(x, y);
            if (chunk==null)
            {
                return null;
            }

            //позиция плитки в массивах чанков
            var tilePos = GetTilePosFromChunk(x, y);
            //возвращаем плитку даже если она пустая
            return chunk.GetTile(tilePos.X, tilePos.Y);
        }
        
        /// <summary>
        /// Получить тип плитки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Chunk GetChunk(int x,int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            if (chunks[X][Y]==null)
            {
                chunks[X][Y] = new Chunk(new Vector2i(X, Y));
            }

            return chunks[X][Y];
        }
        /// <summary>
        /// Возвращает позицию плитки внутри чанка
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector2i  GetTilePosFromChunk(int x, int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            return new Vector2i(x- X*Chunk.CHUNK_SIZE, y - Y * Chunk.CHUNK_SIZE);
        }
        /// <summary>
        /// Рисует чанк
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int x = 0; x < WORLD_SIZE; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    if (chunks[x][y] == null)
                    {
                        continue;
                    }
                        target.Draw(chunks[x][y]);
                }
            }
        }
    }
}

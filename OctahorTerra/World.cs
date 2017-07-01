using System;
using SFML.Graphics;
using SFML.System;

namespace OctahorTerra
{
    class World : Transformable,Drawable
    {
        public const int WORLD_SIZE = 25;

        Chunk[][] chunks;

        public World()
        {
            chunks = new Chunk[WORLD_SIZE][];

            for (int i = 0; i < WORLD_SIZE; i++)
            {
                chunks[i] = new Chunk[WORLD_SIZE];
            }
            for (int x = 0; x < Chunk.CHUNK_SIZE; x++)
            {
                for (int y = 0; y < Chunk.CHUNK_SIZE; y++)
                {
                    SetTile(TileType.GROUND, x, y);
                }
            }
            for (int x = Chunk.CHUNK_SIZE; x < Chunk.CHUNK_SIZE*2; x++)
            {
                for (int y = 0; y < Chunk.CHUNK_SIZE; y++)
                {
                    SetTile(TileType.GRASS, x, y);
                }
            }
        }

        public void SetTile(TileType type, int x, int y)
        {
            var chunk = GetChunk(x, y);
            var tilePos = GetTilePosFromChunk(x, y);

            chunk.SetTile(type, tilePos.X, tilePos.Y);
        }
        
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

        public Vector2i  GetTilePosFromChunk(int x, int y)
        {
            int X = x / Chunk.CHUNK_SIZE;
            int Y = y / Chunk.CHUNK_SIZE;

            return new Vector2i(x- X*Chunk.CHUNK_SIZE, y - Y * Chunk.CHUNK_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            //рисуем чанки
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

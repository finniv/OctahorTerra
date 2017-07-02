﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctahorTerra
{
    class Chunk : Transformable, Drawable
    {
        /// <summary>
        /// количество плиток в одном чанке
        /// </summary>

        public const int CHUNK_SIZE = 25;
        Tile[][] tiles;
        Vector2i chunkPos;

        public Chunk(Vector2i chunkPos)
        {
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * CHUNK_SIZE*Tile.TILE_SIZE,chunkPos.Y*CHUNK_SIZE*Tile.TILE_SIZE);
            tiles = new Tile[CHUNK_SIZE][];

            for (int i = 0; i < CHUNK_SIZE; i++)
            {
                tiles[i] = new Tile[CHUNK_SIZE];
            }
        }
        /// <summary>
        /// рассположение плиток
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTile(TileType type,int x, int y)
        {
            tiles[x][y] = new Tile(type);
            tiles[x][y].Position = new Vector2f(x*Tile.TILE_SIZE,y*Tile.TILE_SIZE);
        }
        /// <summary>
        /// рисуем плитки
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    if (tiles[x][y]==null)
                    {
                        continue;
                    }
                    target.Draw(tiles[x][y],states);
                }
            }
        }
    }
}

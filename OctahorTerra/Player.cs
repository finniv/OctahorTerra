using System;
using SFML.Graphics;
using SFML.System;

namespace OctahorTerra
{
    class Player : Transformable,Drawable
    {
        public Vector2f StartPosition;
        RectangleShape rect;
        RectangleShape rectDirection;
        /// <summary>
        /// Ускорение игрока
        /// </summary>
        Vector2f velocity;

        World world;

        public Player(World World)
        {
            rect = new RectangleShape(new Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 2.8f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            rectDirection = new RectangleShape(new Vector2f(50, 3));
            rectDirection.FillColor = Color.Red;
            rectDirection.Position = new Vector2f(0, rect.Size.Y / 2 - 1);
            this.world = world;
        }

        public void Spawn()
        {
            Position = StartPosition;
        }

        internal void Update()
        {
            updatePhysics();
        }

        private void updatePhysics()
        {
            
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rect, states);
            target.Draw(rectDirection, states);

        }
    }
}
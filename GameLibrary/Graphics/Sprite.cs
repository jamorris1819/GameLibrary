using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameLibrary.Graphics
{
    /// <summary>
    /// A class for drawing a sprite.
    /// </summary>
    public class Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle region;
        private Color color;

        /// <summary>
        /// The texture drawn by the sprite.
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// Location on screen to draw the sprite.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Region covered by the sprite.
        /// </summary>
        public Rectangle Region
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height); }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Constructor for the sprite.
        /// </summary>
        /// <param name="texture">Texture to be drawn</param>
        /// <param name="position">Location on screen to draw the sprite</param>
        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Region, Color.White);
        }
    }
}

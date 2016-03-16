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
    public class ScrollSprite : Sprite
    {
        private int offset;
        private bool enabled;

        public ScrollSprite(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            offset = 0;
            enabled = true;
        }

        /// <summary>
        /// Updates the scroll sprite.
        /// </summary>
        /// <param name="gameTime">Time since last update</param>
        public void Update(GameTime gameTime)
        {
            if (!enabled)
                return;
            offset += 2;
            if (offset >= texture.Height)
                offset = 0;
        }
        /// <summary>
        /// Draws the scroll sprite.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, offset, texture.Width, texture.Height - offset), Color.White);
            spriteBatch.Draw(texture, position + new Vector2(0, texture.Height - offset), new Rectangle(0, 0, texture.Width, offset), Color.White);
        }

        /// <summary>
        /// Stops the sprite from scrolling.
        /// </summary>
        public void Stop()
        {
            enabled = false;
        }
    }
}

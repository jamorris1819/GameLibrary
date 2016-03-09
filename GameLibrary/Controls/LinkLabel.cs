using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GameLibrary.Controls
{
    /// <summary>
    /// An interactable label.
    /// </summary>
    public class LinkLabel : Control
    {
        Color selectedColor = Color.Gray;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        /// <summary>
        /// Constructor for LinkLabel.
        /// </summary>
        public LinkLabel()
        {
            HasFocus = false;
            Position = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            hasFocus = Region.Intersects(InputHandler.Mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColor);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput()
        {
            if (!HasFocus)
                return;
            if (InputHandler.MouseReleased(ButtonPressed.Left))
                base.OnSelected(null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using GameLibrary;
using GameLibrary.Controls;

namespace ExampleGame
{
    public class MainScreen : BaseGameState
    {
        Label title;
        Textbox tb;
        Texture2D tex;

        public MainScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            ContentManager Content = Game.Content;

            Tileset t = new Tileset(GraphicsDevice, Content.Load<Texture2D>("Sprites"), new Vector2(16, 16));
            tex = t.GetTile(0, 0);
            title = new Label();
            title.Text = "Space Cheese Mining";
            title.SpriteFont = mainFont;
            title.Position = new Vector2(200, 100);
            ControlManager.Add(title);

            tb = new Textbox()
            {
                Position = new Vector2(300, 100),
                Font = mainFont,
                BorderSize = 2
            };
            ControlManager.Add(tb);
        }

        void classicGame_Selected(object sender, EventArgs e)
        {
        }

        void playAgain_Selected(object sender, EventArgs e)
        {
        }

        void exitToMenu_Selected(object sender, EventArgs e)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.spriteBatch);
            GameRef.spriteBatch.Draw(tex, new Rectangle(240, 0, 16, 16), Color.White);
            GameRef.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime);
            base.Update(gameTime);
        }
    }
}

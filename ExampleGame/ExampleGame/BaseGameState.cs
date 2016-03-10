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
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 GameRef;
        protected ControlManager ControlManager;
        protected SpriteFont mainFont;

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            // Load in all data, ie sounds, graphics, etc
            mainFont = Content.Load<SpriteFont>("mainFont");
            ControlManager = new ControlManager(mainFont);
            base.LoadContent();
        }

        protected override void StateChange(object sender, EventArgs e)
        {
            base.StateChange(sender, e);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}

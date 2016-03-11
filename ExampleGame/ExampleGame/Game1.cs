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

using System.Drawing;
using System.Windows.Forms;

using GameLibrary;
using GameLibrary.Controls;
namespace ExampleGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        GameStateManager manager;
        public MainScreen MainScreen;

        RenderTarget2D target;

        int scale = 4;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 224;
            graphics.PreferredBackBufferWidth = 256;
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            Components.Add(new InputHandler(this));
            manager = new GameStateManager(this);
            Components.Add(manager);
            MainScreen = new MainScreen(this, manager);
            manager.ChangeState(MainScreen);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            IntPtr ptr = this.Window.Handle;
            Form form = (Form)System.Windows.Forms.Control.FromHandle(ptr);
            form.Size = new Size(graphics.PreferredBackBufferWidth * scale, graphics.PreferredBackBufferHeight * scale);
            form.Location = new System.Drawing.Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - (graphics.PreferredBackBufferWidth * scale)) / 2,
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - (graphics.PreferredBackBufferHeight * scale)) / 2);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            target = new RenderTarget2D(graphics.GraphicsDevice,
                     400, //Same width as backbuffer
                     100);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

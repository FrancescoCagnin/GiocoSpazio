using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GiocoSpazio
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundSprite;
        private Texture2D navicellaSprite;

        private SpriteFont gameFont;
        private Vector2 navicellaCoord = new Vector2(300, 350);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Console.WriteLine($"width: {_graphics.PreferredBackBufferWidth}, height: {_graphics.PreferredBackBufferHeight}");
        }

        protected override void Initialize()
        {
            // Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // use this.Content to load your game content here

            backgroundSprite = Content.Load<Texture2D>("spaziosfondo");
            navicellaSprite = Content.Load<Texture2D>("navicella");
            
            gameFont = Content.Load<SpriteFont>("galleryFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            KeyboardState controls = Keyboard.GetState();

            if (controls.IsKeyDown(Keys.A))
            {
                if (navicellaCoord.X >= 0)
                    navicellaCoord.X -= 4;
            }

            if (controls.IsKeyDown(Keys.D))
            {
                if (navicellaCoord.X <= (_graphics.PreferredBackBufferWidth - 72))
                    navicellaCoord.X += 4;
            }

            if (controls.IsKeyDown(Keys.W))
            {
                if (navicellaCoord.Y >= 0)
                    navicellaCoord.Y -= 3;
            }

            if (controls.IsKeyDown(Keys.S))
            {
                if (navicellaCoord.Y <= (_graphics.PreferredBackBufferHeight - 64))
                    navicellaCoord.Y += 3;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            // _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - targetRadius, targetPosition.Y - targetRadius), Color.White);
            _spriteBatch.Draw(navicellaSprite, navicellaCoord, Color.White );
            _spriteBatch.End();    
            
            base.Draw(gameTime);
        }
    }
}

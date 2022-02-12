using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D targetSprite;
        private Texture2D crosshairsSprite;
        private Texture2D backgroundSprite;
        private Texture2D PokemonSprite;

        private SpriteFont gameFont;

        static Random randNum = new Random();
        private const int targetRadius = 45;
        private Vector2 targetPosition = new Vector2(250, 200);


        private MouseState mState;
            private bool mReleased = true;

        private int score = 0;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            targetSprite = Content.Load<Texture2D>("target");
            crosshairsSprite = Content.Load<Texture2D>("crosshairs");
            backgroundSprite = Content.Load<Texture2D>("sky");
            PokemonSprite = Content.Load<Texture2D>("PokemonPlayer");
            
            gameFont = Content.Load<SpriteFont>("galleryFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();
            
            

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                float mouseTargetDist = Vector2.Distance(targetPosition, mState.Position.ToVector2());

                if (mouseTargetDist < targetRadius)
                {
                    score++;
                    targetPosition = new Vector2(randNum.Next(targetRadius, _graphics.PreferredBackBufferWidth), randNum.Next(targetRadius, _graphics.PreferredBackBufferHeight));
                }
                mReleased = false;

            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            if (mState.Position == Point.Zero)
            {    
                score = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - targetRadius, targetPosition.Y - targetRadius), Color.White);
            _spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(0, 0), Color.White );
            _spriteBatch.End();    
            
            base.Draw(gameTime);
        }
    }
}

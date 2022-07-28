using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameOpenGLPong
{
    public class Game1 : Game
    {
        /// <summary>
        /// for ball display
        /// </summary>
        Texture2D ballTexture;
        /// <summary>
        /// for ball vector
        /// </summary>
        Vector2 ballPosition;
        /// <summary>
        /// ball speed
        /// </summary>
        float ballSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);

            ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
        }

        Random rnd = new Random();
         
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //user input
            var kstate = Keyboard.GetState();

            //random movement
            int sec = (int)gameTime.ElapsedGameTime.TotalSeconds;
            int speed = rnd.Next(1, 9);
            int where = rnd.Next(1, 4);
            if (sec % 3 == 0)
            {
                if (where == 1)
                {
                    ballPosition.X += speed;
                }
                else if (where == 2)
                {
                    ballPosition.X -= speed;
                }
                else if (where == 3)
                {
                    ballPosition.Y -= speed;
                }
                else if (where == 4)
                {
                    ballPosition.Y += speed;
                }

                if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                {
                    ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                }
                else if (ballPosition.X < ballTexture.Width / 2)
                {
                    ballPosition.X = ballTexture.Width / 2;
                }

                if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                {
                    ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                }
                else if (ballPosition.Y < ballTexture.Height / 2)
                {
                    ballPosition.Y = ballTexture.Height / 2;
                }

            }
            if (kstate.IsKeyDown(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
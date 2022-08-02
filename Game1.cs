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
        /// for ball display
        /// </summary>
        Texture2D pirateTexture;

        /// <summary>
        /// for ball vector
        /// </summary>
        Vector2 ballPosition;

        /// <summary>
        /// for ball vector
        /// </summary>
        Vector2 piratePosition;
        /// <summary>
        /// ball speed
        /// </summary>
        float ballSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //8 координат с пиратом
        int p_LeftTopX = 0;
        int p_LeftTopY = 0;
        int p_LeftBottomX = 0;
        int p_LeftBottomY = 0;

        int p_RightTopX = 0;
        int p_RightTopY = 0;
        int p_RightBottomX = 0;
        int p_RightBottomY = 0;

        int pX = -150;
        int pY = -250;

        int BallX = 0;
        int BallY = 0;
        //8 координат с мячом
        int BalllefttopX = 0;
        int BalllefttopY = 0;
        int BallleftbottomX = 0;
        int BallleftbottomY = 0;
        int BallrightbottomX = 0;
        int BallrighttopX = 0;
        int BallrightbottomY = 0;
        int BallrighttopY = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1200;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //начальная поизиция мяча
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
            
            BallX = _graphics.PreferredBackBufferWidth / 2;
            BallY = _graphics.PreferredBackBufferHeight / 2;
            
            

            piratePosition = new Vector2(pX, pY);

            ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");

            BalllefttopX = BallX - ballTexture.Width / 2;
            BalllefttopY = BallY - ballTexture.Height / 2;

            //текстура пирата
            pirateTexture = Content.Load<Texture2D>("3_3-PIRATE_IDLE_001");
            //width
            p_LeftTopX = pX - pirateTexture.Width / 2;
            p_LeftTopY = pY - pirateTexture.Height / 2; 

            p_LeftBottomX = pX - pirateTexture.Width / 2;
            p_LeftBottomY = pY + pirateTexture.Height / 2;

            p_RightTopX = pX + pirateTexture.Width / 2;
            p_RightTopY = pY -pirateTexture.Height / 2;

            p_RightBottomX = pX + pirateTexture.Width / 2;  
            p_RightBottomY = pY + pirateTexture.Height / 2;

        }
        public Rectangle PlayerRectangle(Texture2D player)
        {
            
                int left = (int)p_LeftTopX;
                int top = (int)p_LeftTopY;

                return new Rectangle(left, top, player.Width, player.Height);
            
        }
        public Rectangle BallRectangle(Texture2D ball)
        {

            int left = (int)BalllefttopX;
            int top = (int)BalllefttopY;

            return new Rectangle(left, top, ball.Width, ball.Height);

        }
        Random rnd = new Random();
         
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //user input
            var kstate = Keyboard.GetState();

            //случайное движения мячика
            int sec = (int)gameTime.ElapsedGameTime.TotalSeconds;
            int speed = rnd.Next(1, 9);
            int where = rnd.Next(1, 4);

            //MoveBall(sec, speed, where);

            //управление мячиком клавишами
            if (kstate.IsKeyDown(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                BalllefttopY -= (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                BalllefttopY += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                BalllefttopX -= (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                BalllefttopX += (int)(ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            //что будет если мяч "нанесет урон" пирату
            if ( BallRectangle(ballTexture).Intersects(PlayerRectangle(pirateTexture)))
            {

                //throw new Exception("collide");
                //OnPlayerKilled(enemy);
            }
            base.Update(gameTime);
        }
        private void MoveBall(int sec, int speed, int where)
        {
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

            Rectangle rect = new Rectangle(1, 1, 255, 255);
            //_spriteBatch.Draw(pirateTexture, piratePosition, rect, Color.White , 0 , piratePosition, 0.3f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(pirateTexture, piratePosition, Color.White);
            //отрисовка пирата
            //float scale = .5f; //50% smaller
            //Vector2 pos2 = new Vector2(0, 0);
            //Vector2 scale2 = new Vector2(10, 10);
            //float rot = 0;
            //Rectangle rect = new Rectangle(10, 10, 100, 100);
            //_spriteBatch.Draw(pirateTexture, rect, rect, Color.Red , rot, scale2, SpriteEffects.None, 0f);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
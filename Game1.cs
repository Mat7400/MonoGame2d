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
        /// pirate idle 001
        /// </summary>
        Texture2D pirateTexture;

        Texture2D piratewalk00;
        Texture2D piratewalk01;
        Texture2D piratewalk02;
        Texture2D piratewalk03;
        Texture2D piratewalk04;
        Texture2D piratewalk05;
        Texture2D piratewalk06;

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

        /// <summary>
        /// Глобальная переменнная GraphicsDeviceManager graphics позволяет получить доступ 
        /// к графическому устройству компьютера, смартфона, планшета, игровой консоли. 
        /// Объект GraphicsDeviceManager является проводником между игрой и видеокартой, 
        /// и вся отрисовка в игре будет проходить через этот объект.
        /// </summary>
        private GraphicsDeviceManager _graphics;

        /// <summary>
        /// spriteBatch служит для отрисовки спрайтов - изображений, которые используются в игре.
        /// </summary>
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

        /// <summary>
        /// конструктор - запускаем графическое устройство и разрешение экрана
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1200;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// инициализация начальных позиций
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //начальная поизиция мяча
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
            
            BallX = _graphics.PreferredBackBufferWidth / 2;
            BallY = _graphics.PreferredBackBufferHeight / 2;



           

            ballSpeed = 100f;

            base.Initialize();
        }
        /// <summary>
        /// загружаем текстуры
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ballknight");

            BalllefttopX = BallX - ballTexture.Width / 2;
            BalllefttopY = BallY - ballTexture.Height / 2;

            //текстура пирата
            pirateTexture = Content.Load<Texture2D>("3_3-PIRATE_IDLE_001");
            piratePosition = new Vector2(
               (Window.ClientBounds.Width / 2) - (pirateTexture.Width / 2),
               (Window.ClientBounds.Height / 2) - (pirateTexture.Height / 2));

            piratewalk00 = Content.Load<Texture2D>("3_3-PIRATE_WALK_000");
            piratewalk01 = Content.Load<Texture2D>("3_3-PIRATE_WALK_001");
            piratewalk02 = Content.Load<Texture2D>("3_3-PIRATE_WALK_002");
            piratewalk03 = Content.Load<Texture2D>("3_3-PIRATE_WALK_003");
            piratewalk04 = Content.Load<Texture2D>("3_3-PIRATE_WALK_004");
            piratewalk05 = Content.Load<Texture2D>("3_3-PIRATE_WALK_005");
            piratewalk06 = Content.Load<Texture2D>("3_3-PIRATE_WALK_006");

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
         
        /// <summary>
        /// главный цикл игры повторяющийся
        /// </summary>
        /// <param name="gameTime"></param>
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

        int counterPirateWalk = 0;
        int prevsec = 0;
        /// <summary>
        /// вызывается 60 раз в секунду
        /// Метод Draw() выполняет перерисовку экрана. Например, в методе Update обновляется позиция персонажа, 
        /// а в методе Draw() происходит перерисовка персонажа на основе новой позиции. 
        /// При этом важно учитывать, что все вычисления должны находиться 
        /// в методе Update. Задача метода Draw - только перерисовка.
        /// </summary>
        /// <param name="gameTime"></param>
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
            float scale = 0.3f;
            //рисование с масштабом в 0.3 (30%)
            
            //стоящий неподвижно пират
            //_spriteBatch.Draw(pirateTexture,
            //piratePosition,
            //null,
            //Color.White,
            //0,
            //Vector2.Zero,
            //scale,
            //SpriteEffects.None,
            //0);

            int sec = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (sec>0  )
            {
                piratePosition = new Vector2(
                    (Window.ClientBounds.Width / 2) - (pirateTexture.Width / 2) + sec*5,
                    (Window.ClientBounds.Height / 2) - (pirateTexture.Height / 2));

                if (counterPirateWalk == 0)
                {
                    _spriteBatch.Draw(piratewalk00,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 1)
                {
                    _spriteBatch.Draw(piratewalk01,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 2)
                {
                    _spriteBatch.Draw(piratewalk02,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 3)
                {
                    _spriteBatch.Draw(piratewalk03,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 4)
                {
                    _spriteBatch.Draw(piratewalk04,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 5)
                {
                    _spriteBatch.Draw(piratewalk05,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                if (counterPirateWalk == 6)
                {
                    _spriteBatch.Draw(piratewalk06,
                    piratePosition,
                    null,
                    Color.White,
                    0,
                    Vector2.Zero,
                    scale,
                    SpriteEffects.None,
                    0);
                }
                counterPirateWalk++;
                if (counterPirateWalk > 6) counterPirateWalk = 0;
             }
           
            prevsec = sec;

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
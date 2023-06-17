using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1Mono
{
    public class Game1 : Game
    {
        private List<Clue> clues;
        private Car _car;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _carRight, _carLeft;
        private Texture2D surprise;
        private SpriteFont font;
        private SpriteFont font2;
        private SpriteFont font3;
        private SpriteFont font4;
        private SpriteFont font5;
        private int carX, carY;
        private bool carFacingRight;
        private Random _rng;
        private int _timer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            clues= new List<Clue>();
            carX = 50;
            carY = 350;
            carFacingRight = true;
            _rng= new Random();
            _timer = 300;
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _carRight = Content.Load<Texture2D>("MonoCarR");
            _carLeft = Content.Load<Texture2D>("MonoCarL");
            _car = new Car(carX, carY,4,_carLeft,_carRight);
            surprise = Content.Load<Texture2D>("Smile");
            font = Content.Load<SpriteFont>("HelloFont");
            font2 = Content.Load<SpriteFont>("Font2");
            font3 = Content.Load<SpriteFont>("Font3");
            font4 = Content.Load<SpriteFont>("Font4");
            font5 = Content.Load<SpriteFont>("Font5");
            for(int i = 0; i < 10; i++) 
            {
                clues.Add(new Clue("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red));
            }


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _timer--;
            _car.Update();
            if (clues.Count!=0)
            {
                if (clues[0].ShowMe(_car.GetPosition()))
                {
                    clues.RemoveAt(0);
                }
            }
                       // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _car.Draw(_spriteBatch);
            if (_timer <= 0)
            {
                if (clues.Count != 0)
                    clues[0].Draw(_spriteBatch);
            }

            _spriteBatch.Begin();
            if(_timer>0)
                _spriteBatch.DrawString(font, "AWSD to move.", new Vector2(250, 200), Color.White);

            if (clues.Count == 0)
                _spriteBatch.Draw(surprise, new Vector2(10, 0), Color.White);
            _spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
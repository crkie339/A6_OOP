using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private Texture2D _carRight, _carLeft, _TrapSprite;
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
        private Texture2D _bomba;
        private Texture2D _hwy;

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
            _hwy = Content.Load<Texture2D>("Carretera");
            _bomba = Content.Load<Texture2D>("Animated-Bomb-PNG");
            _TrapSprite = Content.Load<Texture2D>("MonoCarR");
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
           
                if (_rng.NextDouble() < 0.7)
                    clues.Add(new Clue("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red));
                else
                { 
                    clues.Add(new Trap("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red, _bomba));
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
                foreach (Clue clue in clues)
                {
                    if (clue.ShowMe(_car.GetPosition()))
                    {

                        if (clue.GetType() == typeof(Trap))
                        {
                            _car.GetDamage();
                        }
                    }
                }
            }
            for (int i = 0; i < clues.Count; i++)
            {
                 if (clues[i].ShowMe(_car.GetPosition()))
                {
                    
                    if (clues[i].GetType() != typeof(Trap))
                    {
                        if (_rng.NextDouble() < 0.7)
                            clues.Add(new Clue("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red));
                        else
                        {
                            clues.Add(new Trap("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red, _bomba));
                            clues.Add(new Clue("Go here", new Vector2(_rng.Next(0, 650), _rng.Next(0, 400)), 40, font2, Color.Red));
                        }

                    }
                    clues.RemoveAt(i);
                }
            }
                       // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_hwy, new Rectangle(0, 0, 800, 600), Color.White);
            _spriteBatch.DrawString(font5, $"Health Left: {_car.GetHp()}", new Vector2(10,10),Color.White);
            _spriteBatch.End();
            _car.Draw(_spriteBatch);
            if (_timer <= 0)
            {
                foreach(Clue clue in clues)
                    { clue.Draw(_spriteBatch); }
            }

            _spriteBatch.Begin();
            if(_timer>0)
                _spriteBatch.DrawString(font, "AWSD to move.", new Vector2(250, 200), Color.White);

            if (_car.GetHp() <= 0)
                _spriteBatch.Draw(surprise, new Vector2(10, 0), Color.White);
            _spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
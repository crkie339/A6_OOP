using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1Mono
{
    internal class Car
    {
        private Texture2D _carSpriteLeft, _carSpriteRight;
        private int _x,_y,_speed;
        private bool _carFacingRight;
        
        public Car(int x, int y, int speed, Texture2D carSpriteL, Texture2D carSpriteR)        // argumented contructor
        { 
            _x = x;
            _y = y;
            _speed = speed;
            _carSpriteLeft = carSpriteL;
            _carSpriteRight = carSpriteR;
        }
        //getters
        public int GetX() { return _x;}
        public int GetY() { return _y;} 
        public Vector2 GetPosition()
        {
            return new Vector2(_x, _y);
        }

        //muthators
        public void Update ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _x -= _speed;
                _carFacingRight = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _x += _speed;
                _carFacingRight = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _y -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _y += _speed;
            }
         
        }
        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (_carFacingRight)
            {
                spriteBatch.Draw(_carSpriteRight, new Vector2(_x, _y), Color.White);
            }
            else
            {
                spriteBatch.Draw(_carSpriteLeft, new Vector2(_x, _y), Color.White);
            }
            
            spriteBatch.End();

        }
    }
}

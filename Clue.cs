using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1Mono
{
    internal class Clue
    {
        private string _text;
        private Color _color;
        private SpriteFont _font;
        private Vector2 _position;
        private Vector4 _area;
        private int _radio;
        
        public Clue(string text, Vector2 position, int radio, SpriteFont font, Color color)
        {
            _text = text;
            _position = position;
            _area = new Vector4(position.X-radio,position.Y-radio,position.X+radio,position.Y+radio);
            _radio = radio;
            _font = font;
            _color = color;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, _text, _position, _color);
            spriteBatch.End();
        }
        public bool ShowMe (Vector2 carPosition)
        {
            if (carPosition.X > _area.X && carPosition.X < _area.Z && carPosition.Y > _area.Y && carPosition.Y < _area.W)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

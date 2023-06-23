using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1Mono
{
    internal class Trap : Clue
    {
        private Texture2D _Texture;
        public Trap(string text, Vector2 position, int radio, SpriteFont font, Color color,Texture2D texture): base(text, position, radio, font, color) 
        {
            _Texture = texture;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this._Texture, new Rectangle((int)_position.X, (int)_position.Y, 100, 100), Color.White);
            spriteBatch.End();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Model;

namespace Game1.GUI
{
    class gameOver
    {

        private Texture2D texture;
        private SpriteFont spriteFont;
        private Vector2 position;
        private Vector2 textPosition;


        public gameOver(Texture2D texture, SpriteFont spriteFont, Vector2 position)
        {

            this.texture = texture;
            this.spriteFont = spriteFont;
            this.position = position;

            textPosition = new Vector2(50, position.Y + 20);

        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);

            string text = string.Format("Game Over!");
            spriteBatch.DrawString(spriteFont, text, textPosition, Color.White);

        }

    }
}

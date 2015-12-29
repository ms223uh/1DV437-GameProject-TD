using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Model;

namespace Game1.GUI
{
    class Toolbar
    {

        private Texture2D texture;
        private SpriteFont spriteFont;
        private Vector2 position;
        private Vector2 textPosition;


        public Toolbar(Texture2D texture, SpriteFont spriteFont, Vector2 position)
        {

            this.texture = texture;
            this.spriteFont = spriteFont;
            this.position = position;

            textPosition = new Vector2(7, position.Y + 10);

        }


        public void Draw(SpriteBatch spriteBatch, playerModel player, waveManagerModel waveManager)
        {

            spriteBatch.Draw(texture, position, Color.White);

            string text = string.Format("Gold: {0} Lives: {1} Wave: {2}", player.Money, player.Lives, waveManager.Round);
            spriteBatch.DrawString(spriteFont, text, textPosition, Color.White);

        }

    }
}

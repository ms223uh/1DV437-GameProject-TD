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
        playerModel player;
        
        waveManagerModel waveManager;
        
        
        private Texture2D texture;
        private SpriteFont spriteFont;
        private Vector2 position;
        private Vector2 textPosition;
        waveModel wave = new waveModel(waveNumber, numberOfEnemies, player2, level, enemyTexture);

        public static object enemyTexture { get; private set; }
        public static levelModel level { get; private set; }
        public static int numberOfEnemies { get; private set; }
        public static int waveNumber { get; private set; }
        public static playerModel player2 { get; private set; }

        internal waveModel Wave
        {
            get
            {
                return Wave1;
            }

            set
            {
                Wave1 = value;
            }
        }

        internal waveModel Wave1
        {
            get
            {
                return wave;
            }

            set
            {
                wave = value;
            }
        }

        

        

        

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

             

            {
                string text = string.Format("Gold: {0} Lives: {1} Wave: {2}", player.Money, player.Lives, waveManager.Round);
                spriteBatch.DrawString(spriteFont, text, textPosition, Color.White);
            }

            if (player.Lives <= 0)
            {
                
                string text1 = string.Format("Game Over! \n Press ESC to exit or R to restart.");
                spriteBatch.DrawString(spriteFont, text1, textPosition, Color.White);


            }
            if (player.Lives >= 1 && wave.WaveNumber == 24)
            {
                string text2 = string.Format("You Won! \n Press ESC to exit or R to restart.");
                spriteBatch.DrawString(spriteFont, text2, textPosition, Color.White);

            }


        }

            

            
        }

    }


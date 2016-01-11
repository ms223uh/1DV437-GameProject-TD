using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TanksVsZombie.Model;

namespace TanksVsZombie.GUI
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

           
            


        }

            

            
        }

    }


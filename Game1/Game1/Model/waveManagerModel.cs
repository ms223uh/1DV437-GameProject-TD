using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1.Model
{
    class waveManagerModel
    {

        playerModel player;

        private int numberOfWaves;
        private float timeSinceLastWave;
        
        private Texture2D[] enemyTexture;

        private Queue<waveModel> waves = new Queue<waveModel>();

        private bool waveFinished = false;

        private levelModel level;


        public waveModel CurrentWave
        {
            get { return waves.Peek(); }
        }

        public List<enemyModel> Enemies
        {
            get { return CurrentWave.Enemies; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }


        


        public waveManagerModel(playerModel player, levelModel level, int numberOfWaves, Texture2D[] enemyTexture)
        {
            this.numberOfWaves = numberOfWaves;
            this.enemyTexture = enemyTexture;
            this.level = level;
            
            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 16;
                int numberModifier = (i / 2) + 1;

                

                waveModel wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[0]);


                


                if (i == 4)
                {
                    wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[1]);
                }

                if (i == 6)
                {
                    wave = new waveModel(i, 1 * 1,
                    player, level, enemyTexture[2]);
                }

                if (i == 11)
                {
                    wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[1]);
                }

                if (i == 13)
                {
                    wave = new waveModel(i, 1 * 2,
                    player, level, enemyTexture[2]);
                }

                if (i == 17)
                {
                    wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[1]);
                }

                if (i == 17)
                {
                    wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[1]);
                }

                if (i == 21)
                {
                    wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    player, level, enemyTexture[1]);
                }

                if (i == 23)
                {
                    wave = new waveModel(i, 4 * 1,
                    player, level, enemyTexture[2]);
                }
                if (i == 24)
                {
                    wave = new waveModel(i, 0 * 0,
                    player, level, enemyTexture[2]);
                }





                waves.Enqueue(wave);
                
            }
            
            StartNextWave();
        }


        public void StartNextWave()
        {
            if (waves.Count > 0)
            {
                waves.Peek().Start();

                timeSinceLastWave = 0;
                waveFinished = false;
                
            }
            
        }


        public void Update(GameTime gameTime)
        {
            CurrentWave.Update(gameTime);

            if (CurrentWave.RoundOver)
            {
                waveFinished = true;
                
            }

            if (waveFinished)
            {
                timeSinceLastWave += (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }

            if (timeSinceLastWave > 2.5f)
            {
                
                waves.Dequeue();
                StartNextWave();
            }

            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentWave.Draw(spriteBatch);
        }

    }


}
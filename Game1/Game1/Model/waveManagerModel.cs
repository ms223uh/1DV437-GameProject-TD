using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Model
{
    class waveManagerModel
    {

        private int numberOfWaves;
        private float timeSinceLastWave;
        private bool waveFinished = false;
        private Texture2D enemyTexture;

        private Queue<waveModel> waves = new Queue<waveModel>();
        
        private levelModel level;


        public waveModel CurrentWave
        {
            get { return waves.Peek();}
        }

        public List<enemyModel> Enemies
        {
            get { return CurrentWave.Enemies; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }


        public waveManagerModel(levelModel level, int numberOfWaves, Texture2D enemyTexture)
        {
            this.numberOfWaves = numberOfWaves;
            this.enemyTexture = enemyTexture;
            this.level = level;

            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 6;
                int numberModifier = (i / 6) + 1;

                waveModel wave = new waveModel(i, initialNumberOfEnemies * numberModifier,
                    level, enemyTexture);

                waves.Enqueue(wave);
                StartNextWave();
            }

            
        }


        private void StartNextWave()
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

            if (timeSinceLastWave > 2.0f) 
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


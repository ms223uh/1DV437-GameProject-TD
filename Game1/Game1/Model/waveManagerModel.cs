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

        private List<waveModel> waves = new List<waveModel>();
        int currentWaveIndex;
        private levelModel level;


        public waveModel CurrentWave
        {
            get { return waves[currentWaveIndex];}
        }

        public List<enemyModel> Enemies
        {
            get { return CurrentWave.Enemies; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 2; }
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

                waves.Add(wave);
            }

            StartNextWave();
        }


        private void StartNextWave()
        {
            if (currentWaveIndex < waves.Count) 
            {
                waves[currentWaveIndex].Start(); 

                timeSinceLastWave = 0; 
                waveFinished = false;
            }
        }


        public void Update(GameTime gameTime)
        {
            for (int i = 0; i <= currentWaveIndex; i++)
            {
                if (waves[i].RoundOver == false)
                    waves[i].Update(gameTime);
            }

            if (CurrentWave.RoundOver)
            {
                waveFinished = true;
            }

            if (waveFinished)
            {
                timeSinceLastWave = (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (timeSinceLastWave > 5.0f)
            {
                currentWaveIndex += 1;
                StartNextWave(); 

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= currentWaveIndex; i++)
            {
                if (waves[i].RoundOver == false)
                    waves[i].Draw(spriteBatch);
}
        }


    }
}

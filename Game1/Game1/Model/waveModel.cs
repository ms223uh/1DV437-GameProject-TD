using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Model
{
    class waveModel
    {

        playerModel player;
        private int numberOfEnemies;
        private int waveNumber;
        private float spawnTimer;
        private int enemiesHasSpawned = 0;
        waveManagerModel waveManger;

        private bool enemyAtEnd;
        private bool spawningEnemies;

        private levelModel level;
        private Texture2D enemyTexture;
        public List<enemyModel> enemies = new List<enemyModel>();



        public bool RoundOver
        {
            get
            {
                return enemies.Count == 0 && enemiesHasSpawned == numberOfEnemies;
            }
        }

        public int RoundNumber
        {
            get { return waveNumber; }
        }

        public bool EnemyAtEnd
        {
            get { return enemyAtEnd; }
            set { enemyAtEnd = value; }
        }

        public List<enemyModel> Enemies
        {
            get { return enemies; }
        }



        public waveModel(int waveNumber, int numberOfEnemies, playerModel player, levelModel level, Texture2D enemyTexture)
        {

            this.waveNumber = waveNumber;
            this.numberOfEnemies = numberOfEnemies;
            this.player = player;
            this.level = level;
            this.enemyTexture = enemyTexture;

        }

        private void AddEnemy()
        {
            enemyModel enemy = new enemyModel(enemyTexture,
            level.Waypoints.Peek(), 100, 2, 1.5f);

            if (waveNumber == 1)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 100, 1, 1.0f);
            }

            

            enemy.setWaypoints(level.Waypoints);
            enemies.Add(enemy);
            spawnTimer = 0;

            enemiesHasSpawned++;

        }

        public void Start()
        {
            spawningEnemies = true;
        }


        public void Update(GameTime gameTime)
        {
            if (enemiesHasSpawned == numberOfEnemies)
            {
                spawningEnemies = false;
            }

            if (spawningEnemies)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer > 1.0f) // time between enemies
                
                    AddEnemy();
                

            }


            for (int i = 0; i < enemies.Count; i++)
            {

                enemyModel enemy = enemies[i];
                enemy.Update(gameTime);

                if (enemy.IsDead)
                {
                    if (enemy.CurrentHealth > 0)
                    {
                        enemyAtEnd = true;
                        player.Lives -= 1;
                    }
                    else
                    {
                        player.Money += enemy.BountyGiven;
                    }


                    enemies.Remove(enemy);
                    i--;

                }

            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (enemyModel enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

    }
}
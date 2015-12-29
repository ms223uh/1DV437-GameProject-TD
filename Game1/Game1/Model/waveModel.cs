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
            level.Waypoints.Peek(), 85, 1, 1.0f);

            if (waveNumber == 1)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 50, 1, 1.0f);
            }

            if (waveNumber == 2)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 100, 1, 1.0f);
            }

            if (waveNumber == 3)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 120, 1, 1.0f);
            }

            if (waveNumber == 4)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 130, 2, 1.0f);
            }

            if (waveNumber == 5)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 1200, 40, 1.0f);
            }

            if (waveNumber == 6)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 145, 2, 1.1f);
            }

            if (waveNumber == 7)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 155, 2, 1.1f);
            }

            if (waveNumber == 8)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 165, 5, 1.8f);
            }

            if (waveNumber == 9)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 175, 2, 1.1f);
            }

            if (waveNumber == 10)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 185, 2, 1.1f);
            }

            if (waveNumber == 11)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 195, 3, 1.1f);
            }

            if (waveNumber == 12)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 200, 3, 1.1f);
            }

            if (waveNumber == 13)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 225, 4, 1.85f);
            }

            if (waveNumber == 14)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 260, 3, 1.2f);
            }

            if (waveNumber == 15)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 310, 5, 2.0f);
            }

            if (waveNumber == 16)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 365, 3, 1.2f);
            }

            if (waveNumber == 17)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 3200, 155, 1.5f);
            }

            if (waveNumber == 18)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 375, 4, 1.2f);
            }

            if (waveNumber == 19)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 500, 4, 1.2f);
            }

            if (waveNumber == 20)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 600, 6, 1.4f);
            }

            if (waveNumber == 21)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 650, 15, 2.2f);
            }

            if (waveNumber == 22)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 750, 10, 1.3f);
            }

            if (waveNumber == 23)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 7500, 250, 1.3f);
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
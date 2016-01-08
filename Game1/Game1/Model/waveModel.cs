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
        public int numberOfEnemies;
        public int waveNumber;
        public float spawnTimer;
        private int enemiesHasSpawned = 0;
        waveManagerModel waveManger;

        private bool enemyAtEnd;
        public bool spawningEnemies;

        private levelModel level;
        private Texture2D enemyTexture;
        public List<enemyModel> enemies = new List<enemyModel>();
        private playerModel players;
        private object enemyTexture1;

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

        public int WaveNumber
        {
            get { return waveNumber; }
            set { waveNumber = value; }

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

        public waveModel(int waveNumber, int numberOfEnemies, playerModel players, levelModel level, object enemyTexture1)
        {
            this.waveNumber = waveNumber;
            this.numberOfEnemies = numberOfEnemies;
            this.players = players;
            this.level = level;
            this.enemyTexture1 = enemyTexture1;
        }

        private void AddEnemy()
        {
            enemyModel enemy = new enemyModel(enemyTexture,
            level.Waypoints.Peek(), 85, 1, 1.0f);

            if (waveNumber == 0)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 52, 1, 1.0f);
            }

            if (waveNumber == 1)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 60, 1, 1.0f);
                
            }

            if (waveNumber == 2)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 70, 1, 1.0f);
            }

            if (waveNumber == 3)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 75, 1, 1.0f);
            }

            if (waveNumber == 4)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 55, 1, 1.4f);
            }

            if (waveNumber == 5)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 100, 1, 1.0f);
            }

            if (waveNumber == 6)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 400, 30, 1.0f);
            }

            if (waveNumber == 7)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 140, 2, 1.1f);
            }

            if (waveNumber == 8)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 145, 2, 1.1f);
            }

            if (waveNumber == 9)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 155, 2, 1.2f);
            }

            if (waveNumber == 10)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 165, 2, 1.2f);
            }

            if (waveNumber == 11)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 165, 4, 2.0f);
            }

            if (waveNumber == 12)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 175, 2, 1.2f);
            }

            if (waveNumber == 13)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 950, 120, 1.2f);
            }

            if (waveNumber == 14)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 200, 4, 1.25f);
            }

            if (waveNumber == 15)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 200, 3, 1.2f);
            }

            if (waveNumber == 16)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 225, 4, 1.25f);
            }

            if (waveNumber == 17)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 220, 5, 2.05f);
            }

            if (waveNumber == 18)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 380, 4, 1.2f);
            }

            if (waveNumber == 19)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 400, 4, 1.2f);
            }

            if (waveNumber == 20)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 425, 4, 1.25f);
            }

            if (waveNumber == 21)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 425, 5, 2.2f);
            }

            if (waveNumber == 22)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 450, 6, 1.3f);
            }

            if (waveNumber == 23)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 7500, 250, 1.4f);
            }
            if (waveNumber == 24)
            {
                enemy = new enemyModel(enemyTexture,
                level.Waypoints.Peek(), 1, 0, 1.4f);
            }




            enemy.setWaypoints(level.Waypoints);
            enemies.Add(enemy);
            spawnTimer = 0;

            enemiesHasSpawned++;

            

        }

        public void Start()
        {
            player.Money += 6;
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

                if (player.Lives <= 0)
                {
                    enemies.Remove(enemy);
                    enemyAtEnd = true;
                    spawningEnemies = false;
                }
                if (player.Lives >= 1 && waveNumber == 24)
                {
                    enemies.Remove(enemy);
                    enemyAtEnd = true;
                    spawningEnemies = false;
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
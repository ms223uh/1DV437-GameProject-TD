﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Tower;

namespace Game1.Model
{
    class playerModel
    {
        private levelModel level;

        private int money = 50;
        private int lives = 30;

        private Texture2D towerTexture;

        private List<towerModel> towers = new List<towerModel>();

        private MouseState mouseState;
        private MouseState oldState;

        private Viewport vp;

        private Texture2D bulletTexture;


        public int Money
        {
            get { return money; }
        }

        public int Lives
        {
            get { return lives; }
        }


        public playerModel(levelModel level, Texture2D towerTexture, Viewport vp, Texture2D bulletTexture)
        {
            this.vp = vp;
            this.level = level;
            this.towerTexture = towerTexture;
            this.bulletTexture = bulletTexture;
        }



        private int cellX;
        private int cellY;
        private int tileX;
        private int tileY;


        public void Update(GameTime gameTime, List<enemyModel> enemies)
        {
            mouseState = Mouse.GetState();

            float x = (float)mouseState.X / Game1.WindowObject.ClientBounds.Width;
            float y = (float)mouseState.Y / Game1.WindowObject.ClientBounds.Height;

            cellX = (int)(x * level.Width);
            cellY = (int)(y * level.Height);
            tileX = cellX * 60;
            tileY = cellY * 60;


            if (mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                if (isCellClear())
                {
                    ashTower tower = new ashTower(towerTexture,
                        bulletTexture, new Vector2(tileX, tileY));

                    towers.Add(tower);
                }
            }


            foreach (towerModel tower in towers)
            {
                if (tower.Target == null)
                {
                    tower.getTheClosestTarget(enemies);
                }

                tower.Update(gameTime);
            }


            oldState = mouseState;
        }


        private bool isCellClear()
        {
            bool inBounds = cellX >= 0 && cellY >= 0 && cellX < level.Width && cellY < level.Height;

            bool spaceClear = true;

            foreach (towerModel tower in towers)
            {
                spaceClear = (tower.Position != new Vector2(tileX, tileY));

                if (!spaceClear)
                    break;
            }

            bool onPath = (level.getIndex(cellX, cellY) == 0);

            return inBounds && spaceClear && onPath;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (towerModel tower in towers)
            {
                tower.Draw(spriteBatch);
            }
        }

    }
}
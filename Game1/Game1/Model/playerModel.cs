using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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


        public int Money
        {
            get { return money; }
        }

        public int Lives
        {
            get { return lives; }
        }


        public playerModel(levelModel level, Texture2D towerTexture)
        {
            this.level = level;
            this.towerTexture = towerTexture;
        }



        private int cellX;
        private int cellY;
        private int tileX;
        private int tileY;


        public void Update(GameTime gameTime, List<enemyModel> enemies)
        {
            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 85);
            cellY = (int)(mouseState.Y / 85);
            tileX = cellX * 85;
            tileY = cellY * 85;


            if(mouseState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                if (isCellClear())
                {
                    towerModel tower = new towerModel(towerTexture, new Vector2(tileX, tileY));
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
            bool inBounds = cellX >= -1 && cellY >= -1 && cellX < level.Width && cellY < level.Height;

            bool spaceClear = true;

            foreach (towerModel tower in towers)
            {
                spaceClear = (tower.Position != new Vector2(tileX, tileY));

                if (!spaceClear)
                    break;
            }

            bool onPath = (level.getIndex(cellX, cellY) != 1);

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

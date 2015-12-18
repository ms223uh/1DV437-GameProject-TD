using Game1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Model
{
    public class towerModel : camera
    {
        protected enemyModel target;

        protected int cost;
        protected int attackDamage;
        protected float attackRadius;
        protected Texture2D bulletTexture;
        protected float bulletTimer;
        protected List<bulletModel> bulletList = new List<bulletModel>();  



        public enemyModel Target
        {
            get { return target; }
        }



        public int Cost
        {
            get { return cost; }
        }

        public int AttackDamage
        {
            get { return attackDamage; }
        }

        public float AttackRadius
        {
            get { return attackRadius; }
        }



        public towerModel(Texture2D texture, Texture2D bulletTexture ,Vector2 position) : base(texture, position)
        {
            this.bulletTexture = bulletTexture;
        }


        public bool isInRange(Vector2 position)
        {
            if (Vector2.Distance(center, position) <= attackRadius)
                return true;

            return false;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            foreach(bulletModel bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }


            base.Draw(spriteBatch);
        }


        public void getTheClosestTarget(List<enemyModel> enemies)
        {
            target = null;

            float smallestRange = attackRadius;

            foreach (enemyModel enemy in enemies)
            {
                if (Vector2.Distance(center, enemy.Center) < smallestRange)
                {
                    smallestRange = Vector2.Distance(center, enemy.Center);
                    target = enemy;
                }
            }
        }


        protected void faceTarget()
        {
            Vector2 direction = center - target.Center;
            direction.Normalize();

         rotation = (float)Math.Atan2(-direction.X, direction.Y);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (target != null)
            {
                if (!target.IsDead) 
                faceTarget();

                if (!isInRange(target.Center) || target.IsDead)
                {
                    
                    target = null;
                    bulletTimer = 0;
                }
            }
        }



    }

}
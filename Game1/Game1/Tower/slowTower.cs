using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TanksVsZombie.Model;

namespace TanksVsZombie.Tower
{
    public class slowTower : towerModel
    {

        private float speedModifier;
        private float modifierDuration;

        public slowTower(Texture2D texture, Texture2D bulletTexture, Vector2 position)
            : base(texture, bulletTexture, position)
        {
            this.speedModifier = 0.5f;
            this.modifierDuration = 2.1f;
            this.attackDamage = 2;
            this.cost = 30;
            this.attackRadius = 150;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (bulletTimer >= 0.75f && target != null)
            {
                bulletModel bullet = new bulletModel(bulletTexture, Vector2.Subtract(center,
                    new Vector2(bulletTexture.Width / 2)), rotation, 6, attackDamage);

                bulletList.Add(bullet);
                bulletTimer = 0;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletModel bullet = bulletList[i];

                bullet.setRotation(rotation);
                bullet.Update(gameTime);

                if (!isInRange(bullet.Center))
                    bullet.Kill();

                if (target != null && Vector2.Distance(bullet.Center, target.Center) < 12)
                {

                    

                    target.CurrentHealth -= bullet.Damage;
                    bullet.Kill();

                    if (target.SpeedModifier <= speedModifier)
                    {
                        target.SpeedModifier = speedModifier;
                        target.ModifierDuration = modifierDuration;
                    }


                }

                if (bullet.isDead())
                {
                    bulletList.Remove(bullet);
                    i--;
                }
            }
        }

    }
}

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

        protected int cost;
        protected int attackDamage;
        protected float attackRadius;


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



        public towerModel(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
                Color color = new Color();
                base.Draw(spriteBatch, color);
        }


        }

    }


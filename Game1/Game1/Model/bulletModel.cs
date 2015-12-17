﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.View;

namespace Game1.Model
{
    public class bulletModel : camera
    {

        private int damage;
        private int age;
        private int speed;


        public int Damage
        {
            get { return damage; }
        }

        public bool isDead()
        {
            return age > 100;
        }


        public bulletModel(Texture2D texture, Vector2 position, float rotation, int speed, int damage)
               : base(texture, position)
        {
            this.rotation = rotation;
            this.damage = damage;
            this.speed = speed;
        }


        public void Kill()
        {
            this.age = 200;
        }

        public override void Update(GameTime gameTime)
        {
            age++;
            position += velocity;

            base.Update(gameTime);
        }

        public void setRotation(float value)
        {
            rotation = value;

            velocity = Vector2.Transform(new Vector2(0, -speed), Matrix.CreateRotationZ(rotation));
        }


    }
}

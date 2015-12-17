﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.View
{
    public class camera
    {

        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 center;
        protected Vector2 origin;
        protected float rotation;

        public camera(Texture2D Texture, Vector2 Position)
        {

            texture = Texture;
            position = Position;
            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2,
                                 position.Y + texture.Height / 2 );

            origin = new Vector2(texture.Width / 2, texture.Height / 2);

        }


        public Vector2 Center
        {
            get
            {
                return center;
            }
        }


        public Vector2 Position
        {
            get
            {
                return position;
            }
        }


        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + texture.Width / 2,
                                      position.Y + texture.Height / 2
                );

        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White,
                             rotation, origin, 1.0f, SpriteEffects.None, 0);
        }


    }
}

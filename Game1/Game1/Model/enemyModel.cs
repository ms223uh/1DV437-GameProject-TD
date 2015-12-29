using Game1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Model
{
    public class enemyModel : camera
    {
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        protected float startHealth;
        protected float currentHealth;
        protected bool alive = true;
        protected float speed = 2.5f;
        protected int bountyGiven;

        private float speedModifier;
        private float modifierDuration;
        private float modifierCurrentTime;


        public float SpeedModifier
        {
            get { return speedModifier; }
            set { speedModifier = value;  }
        }

        public float ModifierDuration
        {
            get { return modifierDuration; }
            set
            {
                modifierDuration = value;
                modifierCurrentTime = 0;
            }
        }

        

        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public bool IsDead
        {
           // get { return currentHealth <= 0; }

           get { return !alive; }
        }

        public int BountyGiven
        {
            get { return bountyGiven; }
        }

        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }


        public enemyModel(Texture2D texture, Vector2 position, float health, int bountyGiven, float speed)
                          : base(texture, position)
        {

            this.startHealth = health;
            this.currentHealth = startHealth;
            this.bountyGiven = bountyGiven;
            this.speed = speed;

        }


        public void setWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            this.position = this.waypoints.Dequeue();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < 1f)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();

                    
                    float temporarySpeed = speed;

                    
                    if (modifierCurrentTime > modifierDuration)
                    {
                        
                        speedModifier = 0;
                        modifierCurrentTime = 0;
                    }

                    if (speedModifier != 0 && modifierCurrentTime <= modifierDuration)
                    {
                        
                        temporarySpeed *= speedModifier;
                        
                        modifierCurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                    velocity = Vector2.Multiply(direction, temporarySpeed);

                    position += velocity;
                }
            }

            else
                alive = false;

            if (currentHealth <= 0)
                alive = false;
        }


        public override void Draw(SpriteBatch spriteBatch )
        {
            if (alive)
            {
                float healthPercentage = (float)currentHealth / (float)startHealth;

                Color color = new Color(new Vector3(3 - healthPercentage,
                    3 - healthPercentage, 3 - healthPercentage));

                base.Draw(spriteBatch);
            }
            



        }
    }
}
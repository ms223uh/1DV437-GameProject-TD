using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Model
{
    class levelModel
    {

        private List<Texture2D> tileTexture = new List<Texture2D>();
        private Queue<Vector2> waypoints = new Queue<Vector2>();


        public levelModel()
        {
            waypoints.Enqueue(new Vector2(0, 1) * 60);
            waypoints.Enqueue(new Vector2(1, 1) * 60);
            waypoints.Enqueue(new Vector2(10, 1) * 60);
            waypoints.Enqueue(new Vector2(10, 3) * 60);
            waypoints.Enqueue(new Vector2(3, 3) * 60);
            waypoints.Enqueue(new Vector2(3, 6) * 60);
            waypoints.Enqueue(new Vector2(1, 6) * 60);
            waypoints.Enqueue(new Vector2(1, 8) * 60);
            waypoints.Enqueue(new Vector2(8, 8) * 60);
            waypoints.Enqueue(new Vector2(8, 9) * 60);
            waypoints.Enqueue(new Vector2(12, 9) * 60);
        }


        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }


        int[,] map = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {2,1,1,1,1,1,1,1,1,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,0,0,1,1,1,1,1,1,1,1,0,0},
            {0,0,0,1,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,0,0,0,0,0,0,0,0,0},
            {0,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,1,1,1,1,3},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},

        };


        public int getIndex(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > Width  -1 || cellY < 0 || cellY > Height -1)
            {
                return 0;
            }

            return map[cellY, cellX];
        }

        public void setIndex(int cellX, int cellY, int index)
        {
            if (cellX < 0 || cellX > Width - 1 || cellY < 0 || cellY > Height - 1)
            {
                return;
            }

            map[cellY, cellX] = index;
        }



        public void addTexture(Texture2D texture)
        {
            tileTexture.Add(texture);
        }


        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;
                    
                    Texture2D texture = tileTexture[textureIndex];
                    spriteBatch.Draw(texture, new Rectangle(
                        x * 60, y * 60, 60, 60), Color.White);
                }
            }
        }

    }
}
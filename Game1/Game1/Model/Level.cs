using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Model
{
    class Level
    {

        private List<Texture2D> tileTexture = new List<Texture2D>();


        public Level()
        {

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
                        x * 85, y * 85, 85, 85), Color.White);
                }
            }
        }

    }
}

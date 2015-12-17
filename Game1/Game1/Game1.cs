﻿using Game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        levelModel level = new levelModel();
        enemyModel enemy1;
       // towerModel tower;
        playerModel player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = level.Height * 85;
            graphics.PreferredBackBufferWidth = level.Width * 85;

            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");
            Texture2D redPath = Content.Load<Texture2D>("redPath");
            Texture2D whitePath = Content.Load<Texture2D>("whitePath");
            level.addTexture(grass);
            level.addTexture(path);
            level.addTexture(whitePath);
            level.addTexture(redPath);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy2");
            enemy1 = new enemyModel(enemyTexture, level.Waypoints.Peek(), 100, 10, 2.5f);
            enemy1.setWaypoints(level.Waypoints);

            Texture2D towerTexture = Content.Load<Texture2D>("tower1");
            //tower = new towerModel(towerTexture, Vector2.Zero);
            player = new playerModel(level, towerTexture);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //enemy1.Update(gameTime);


            //if (tower.Target == null)
            //{
            //    List<enemyModel> enemies = new List<enemyModel>();

            //    enemies.Add(enemy1);
            //    tower.getTheClosestTarget(enemies);
            //}
            //tower.Update(gameTime);

            //base.Update(gameTime);


            enemy1.Update(gameTime);

            List<enemyModel> enemies = new List<enemyModel>();
            enemies.Add(enemy1);

            player.Update(gameTime, enemies);

            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            level.Draw(spriteBatch);
            enemy1.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}